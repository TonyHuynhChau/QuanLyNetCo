using QLTN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DAO
{
     class GroupUserDAO
    {
        private static GroupUserDAO instance;
        public static GroupUserDAO Instance
        {
            get { if (instance == null) instance = new GroupUserDAO(); return GroupUserDAO.instance; }
            private set { GroupUserDAO.instance = value; }
        }
        private GroupUserDAO() { }
        public List<GroupUser> GetList()
        {
            List<GroupUser> list = new List<GroupUser>();
            string query = "SELECT* FROM GruopACCOUNT";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                GroupUser group = new GroupUser(item);
                list.Add(group);
            }
            return list;
        }
        public List<GroupUser> GetListByID(int id)
        {
            List<GroupUser> list = new List<GroupUser>();
            string query = "SELECT* FROM GruopACCOUNT WHERE GroupUser =" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                GroupUser group = new GroupUser(item);
                list.Add(group);
            }
            return list;
        }
        public GroupUser GetGruopByID(int id)
        {
            GroupUser group = null;
            string query = "SELECT* FROM GruopACCOUNT WHERE GroupUser =" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                group = new GroupUser(item);
                return group;

            }
            return group;
        }
        public bool InsertChucVu(string name)
        {
            string query = string.Format("INSERT INTO GruopACCOUNT(GroupName)VALUES(N'{0}') ", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DelChucVu(int id)
        {
            AccountDAO.Instance.DeleteNV2(id);
            string query = string.Format("DELETE FROM GruopACCOUNT WHERE GroupUser ={0} ", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
