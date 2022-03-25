using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application_Project.Areas.Admin.ViewModel
{
    public class UserDataViewModel
    {
        public int User_Id { get; set; }
        public string User_FirstName { get; set; }
        public string User_LastName { get; set; }
        public string User_UserName { get; set; }
        public string User_Password { get; set; }
        public string User_Address { get; set; }
        public string User_PhoneNo { get; set; }
        public string User_Email { get; set; }
        public string User_City { get; set; }
        public string User_State { get; set; }
    }
}
