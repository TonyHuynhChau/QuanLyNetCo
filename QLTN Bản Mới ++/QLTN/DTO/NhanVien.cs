using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DTO
{
    class NhanVien
    {
        public NhanVien(int id, string accountName, string password, string userName, string sex, int groupUser, string phoneNumber, string email)
        {
            this.ID = id;
            this.AccountName = accountName;
            this.Password = password;
            this.UserName = userName;
            this.Sex = sex;
            this.GroupUser = groupUser;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }
        public NhanVien(DataRow row)
        {

            this.ID = (int)row["ID"];
            this.AccountName = row["AccountName"].ToString(); ;
            this.Password = row["Password"].ToString();
            this.UserName = row["UserName"].ToString();
            this.Sex = row["Sex"].ToString();
            this.GroupUser = (int)row["GroupUser"];
            this.PhoneNumber = row["PhoneNumber"].ToString();
            this.Email = row["Email"].ToString();
        }
        private int id;
        private string accountName;
        private string password;
        private string userName;
        private string sex;
        private int groupUser;
        private string phoneNumber;
        private string email;


        public int ID { get => id; set => id = value; }
        public string AccountName { get => accountName; set => accountName = value; }
        public string Password { get => password; set => password = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Sex { get => sex; set => sex = value; }
        public int GroupUser { get => groupUser; set => groupUser = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }

    }
}
