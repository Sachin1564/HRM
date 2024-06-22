using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Messages.Identity
{
    public static class Identitymessages
    {
        public static string CheckEmailAddress(string propName)
        {
            return "value should be in email format! ";
        }
        //public static string CheckEmail()
        //{
        //    return "value should be in email format! ";
        //}

        public static string ComaparePassword()
        {
            return "  must be same with the Password ";
        }
    }
}
