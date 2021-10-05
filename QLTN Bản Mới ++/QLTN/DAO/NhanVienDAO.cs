using QLTN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DAO
{
    class NhanVienDAO
    {
        private static NhanVienDAO instance;
        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return NhanVienDAO.instance; }
            private set { NhanVienDAO.instance = value; }
        }
        private NhanVienDAO() { }
        public List<NhanVien> GetNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();
            string query = "SELECT * FROM ACCOUNT ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhanVien category = new NhanVien(item);
                list.Add(category);
            }
            return list;
        }
        public List<NhanVien2> GetNhanVien2()
        {
            List<NhanVien2> list = new List<NhanVien2>();
            string query = "	SELECT a.AccountName,a.[Password],a.UserName,a.Sex,ga.GroupName,a.PhoneNumber,a.Email  FROM ACCOUNT AS a, GruopACCOUNT AS ga WHERE ga.GroupUser=a.GroupUser ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhanVien2 category = new NhanVien2(item);
                list.Add(category);
            }
            return list;
        }
        public List<NhanVien> SearchStaffByName(string name)
        {
            List<NhanVien> list = new List<NhanVien>();
            string query = string.Format("SELECT * FROM  ACCOUNT where UserName like N'%{0}%' ", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhanVien category = new NhanVien(item);
                list.Add(category);
            }
            return list;
        }
        public List<NhanVien> SearchStaffByPhone(string Phone)
        {
            List<NhanVien> list = new List<NhanVien>();
            string query = string.Format("SELECT * FROM  ACCOUNT where PhoneNumber like N'%{0}%' ", Phone);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhanVien category = new NhanVien(item);
                list.Add(category);
            }
            return list;
        }



    }
}
