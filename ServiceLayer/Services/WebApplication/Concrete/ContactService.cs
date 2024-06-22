using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ContactVM;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Services.WebApplication.Abstract;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Contact> _repository;

        public ContactService(IUnitOfWorks unitOfWorks, IMapper mapper, IGenericRepositories<Contact> repository)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ContactListVM>> GetAllListAsync()
        {
            var contactListVM = await _repository.GetAlltEntityList().ProjectTo<ContactListVM>
                (_mapper.ConfigurationProvider).ToListAsync();

            return contactListVM;
        }
        public async Task AddContactAsync(ContactAddVM request)
        {
            var contact = _mapper.Map<Contact>(request);
            await _repository.AddEntityAsync(contact);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await _repository.GetEntityByIdAsync(id);
            _repository.DeletetEntity(contact);
            await _unitOfWorks.CommitAsnyc();
        }

        public async Task<ContactUpdateVM> GetContactById(int id)
        {
            var contact = await _repository.Where(x => x.Id == id).ProjectTo<ContactUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return contact;
        }

        public async Task UpdateContactAsync(ContactUpdateVM request)
        {
            var contact = _mapper.Map<Contact>(request);
            _repository.UpdatetEntity(contact);
            await _unitOfWorks.CommitAsnyc();

        }
    }
}
