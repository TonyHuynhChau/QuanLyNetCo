using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DTO
{
    class NhanVien2
    {
        public NhanVien2(string accountName, string password, string userName, string sex, string groupName, string phoneNumber, string email)
        {
            this.AccountName = accountName;
            this.Password = password;
            this.UserName = userName;
            this.Sex = sex;
            this.GroupName = groupName;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }
        public NhanVien2(DataRow row)
        {

            this.AccountName = row["AccountName"].ToString(); ;
            this.Password = row["Password"].ToString();
            this.UserName = row["UserName"].ToString();
            this.Sex = row["Sex"].ToString();
            this.GroupName =row["GroupName"].ToString();
            this.PhoneNumber = row["PhoneNumber"].ToString();
            this.Email = row["Email"].ToString();
        }
        private string accountName;
        private string password;
        private string userName;
        private string sex;
        private string groupName;
        private string phoneNumber;
        private string email;


        public string AccountName { get => accountName; set => accountName = value; }
        public string Password { get => password; set => password = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Sex { get => sex; set => sex = value; }
        public string GroupName { get => groupName; set => groupName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }

    }
}
