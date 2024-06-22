using AutoMapper;
using EntityLayer.Identity;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using ServiceLayer.Helpers.Identity.EmailHelper;
using ServiceLayer.Helpers.Identity.ModelStateHelper;

namespace HRM.Web.Controllers
{

    public class AuthenticationController : Controller
    {
       private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IValidator<SignUpVM> _signUpValidator;
        private readonly IValidator<LogInVM> _logInValidator;
        private readonly IValidator<ForgotPasswordVM> _forgotPasswordValidator;
        private readonly IMapper _imapper;
        private readonly IEmailSendMethod _emailSendMethod;

        public AuthenticationController(UserManager<AppUser> userManager, IValidator<SignUpVM> signUpValidator, IMapper imapper, IValidator<LogInVM> logInValidator, SignInManager<AppUser> signInManager, IValidator<ForgotPasswordVM> forgotPasswordValidator, IEmailSendMethod emailSendMethod)
        {
            _userManager = userManager;
            _signUpValidator = signUpValidator;
            _imapper = imapper;
            _logInValidator = logInValidator;
            _signInManager = signInManager;
            _forgotPasswordValidator = forgotPasswordValidator;
            _emailSendMethod = emailSendMethod;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM request)
        {
            var validation = await _signUpValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View();
            }

            var user = _imapper.Map<AppUser>(request);
            var userCreateResult = await _userManager.CreateAsync(user , request.Password);
            if(!userCreateResult.Succeeded)
            {
                ViewBag.Result = "NotSucceed";
                ModelState.AddModelErrorList(userCreateResult.Errors);
                return View();
            }

            return RedirectToAction("LogIn", "Authentication");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInVM request, string? returnUrl= null )
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Dashboard", new { Area = " Admin" });

            var validation = await  _logInValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                ViewBag.Result = "NotSucceed";
                validation.AddToModelState(this.ModelState);
                return View();
            }

            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            if (hasUser == null)
            {
                ViewBag.Result = "NotSucceed";
                ModelState.AddModelErrorList(new List<string> { " Email or Password is wrong" });
                return View();
            }

            var logInResult = await _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, true);
            if (logInResult.Succeeded)
            {
                return RedirectToAction(returnUrl!);
            }

            if(logInResult.IsLockedOut)
            {
                ViewBag.Result = "LockedOut";
                ModelState.AddModelErrorList(new List<string> { " Your account is locked Out for 60 Seconds.  " });
                return View();
            }
            ViewBag.Result = "Filed Attempt";
            ModelState.AddModelErrorList(new List<string> { $"Email or Password is wrong !Filed Attempt{ await
                    _userManager.GetAccessFailedCountAsync(hasUser)  }" });
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
       {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM request)
        {
                var validation = await _forgotPasswordValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View();
            }
            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            if (hasUser == null)
            {
                ViewBag.Result = "UserDoesNotexit";
                ModelState.AddModelErrorList(new List<string> { "User does not exit!" });
                return View();
            }
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(hasUser);
            var passwordResetLink = Url.Action("ResetPassword", "Authentication", new {UserId = hasUser.Id, Token = resetToken, HttpContext.Request.Scheme});

            await _emailSendMethod.SendResetPasswordLinkWithEmailToken(passwordResetLink! , request.Email);
           
            return RedirectToAction("LogIn", "Authentication");
            
        }

    }
}
