using QLTN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }
        private AccountDAO() { }

        public int Get(string Acc)
        {

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM ACCOUNT WHERE AccountName = N'"+ Acc +"'");

            if (data.Rows.Count > 0)
            {
                Account account = new Account(data.Rows[0]);
                return account.ID ;
            }

            return -1;
        }
        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });
            return result.Rows.Count > 0;

        }
        public bool InsertNV(string AccountName, string Password, string UserName, string Sex, int GroupUser, string PhoneNumber, string Email)
        {
            string query = string.Format("INSERT INTO ACCOUNT(AccountName,Password,UserName,Sex,GroupUser,PhoneNumber,Email)VALUES(N'{0}',N'{1}',N'{2}',N'{3}',{4},N'{5}',N'{6}')", AccountName, Password, UserName, Sex, GroupUser, PhoneNumber, Email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteNV(int id)
        {
            string query = string.Format("DELETE FROM ACCOUNT WHERE ID = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteNV2(int id)
        {
            string query = string.Format("DELETE FROM ACCOUNT WHERE GroupUser = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateNV(string AccountName, string Password, string UserName, string Sex, int GroupUser, string PhoneNumber, string Email, int id)
        {
            string query = string.Format("UPDATE ACCOUNT SET AccountName = N'{0}',Password = N'{1}',UserName = N'{2}',Sex = N'{3}',GroupUser = {4},PhoneNumber = N'{5}',Email = N'{6}' WHERE ID = {7}", AccountName, Password, UserName, Sex, GroupUser, PhoneNumber, Email, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateNV2(string Password , string AccountName)
        {
            string query = string.Format("UPDATE ACCOUNT SET Password = N'{0}' WHERE  AccountName = N'{1}' ", Password, AccountName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Reset(int id)
        {
            string query = string.Format("UPDATE ACCOUNT SET Password = N'0' WHERE  ID = {0} ", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public Account GetAccount(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM  ACCOUNT where AccountName = N'" + userName+"'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public Account GetAccount2(string userName,string pass)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM  ACCOUNT where AccountName = N'" + userName + "' AND Password = N'"+ pass +"'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public bool UpdateNV3(string UserName, string Sex,string PhoneNumber,string Email,string AccountName)
        {
            string query = string.Format("UPDATE ACCOUNT SET UserName = N'{0}',Sex = N'{1}',PhoneNumber = N'{2}',Email = N'{3}' WHERE AccountName = N'{4}' ", UserName,  Sex,  PhoneNumber,  Email,  AccountName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
