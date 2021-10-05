using QLTN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DAO
{
    class CategoryDAO
    {
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }
        private CategoryDAO() { }
        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();
            string query = "SELECT * FROM  FOODCATEGORY ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }
            return list;
        }
        public Category GetListCategory2(int id)
        {
            Category category1 = null;
            string query = "SELECT * FROM  FOODCATEGORY Where ID =" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category1 = new Category(item);
                return category1;
                
            }
            return category1;
        }
        public bool InsertCategory(string name)
        {
            string query = string.Format("INSERT INTO FOODCATEGORY(NAME)VALUES(N'{0}') ", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteCategory(int id)
        {
            MenuDAO.Instance.DeteleFoodByIDCategory(id);
            string query = string.Format("DELETE FROM FOODCATEGORY WHERE ID ={0} ", id);           
            int result = DataProvider.Instance.ExecuteNonQuery(query);          
            return result > 0;
        }
    }
}
