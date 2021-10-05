using QLTN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DAO
{
    class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }

        public List<DTO.Menu> GetFoodByCategoryID(int id)
        {
            List<DTO.Menu> list = new List<DTO.Menu>();

            string query = "select * FROM Food AS f where f.idFOODCATEGORY =  " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO.Menu food = new DTO.Menu(item);
                list.Add(food);
            }

            return list;
        }
        public List<DTO.Menu2> GetFood()
        {
            List<DTO.Menu2> list = new List<DTO.Menu2>();

            string query = "SELECT f.FoodID,f.FoodName,f2.NAME,f.PriceUnit,f.UnitLot,f.InventoryNumber  FROM Food AS f,FOODCATEGORY AS f2 WHERE f2.ID=f.idFOODCATEGORY ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO.Menu2 food = new DTO.Menu2(item);
                list.Add(food);
            }

            return list;
        }
        public List<Menu> GetMenus()
        {
            List<DTO.Menu> list = new List<DTO.Menu>();

            string query = "SELECT * FROM Food AS f";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO.Menu food = new DTO.Menu(item);
                list.Add(food);
            }

            return list;
        }
        public int GetMenus2(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Food AS f where FoodID =  " + id);

            if (data.Rows.Count > 0)
            {
                Menu list = new Menu(data.Rows[0]);
                return list.InventoryNumber;
            }

            return -1;
        }
        public List<Menu> SearchFoodByName(string name)
        {
            List<DTO.Menu> list = new List<DTO.Menu>();

            string query = string.Format("select * FROM Food where FoodName like N'%{0}%' ", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO.Menu food = new DTO.Menu(item);
                list.Add(food);
            }

            return list;
        }
        public bool InsertFood(string name, int id, int price, string unitlot, int inven)
        {
            string query = string.Format("INSERT INTO Food (FoodName, idFOODCATEGORY, PriceUnit, UnitLot, InventoryNumber)VALUES(N'{0}',{1},{2},N'{3}',{4})", name, id, price, unitlot, inven);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateFood(string name, int id, int price, string unitlot, int inven, int foodid)
        {
            string query = string.Format("UPDATE Food SET FoodName = N'{0}', idFOODCATEGORY = {1}, PriceUnit = {2}, UnitLot = N'{3}', InventoryNumber = {4} WHERE FoodID = {5}", name, id, price, unitlot, inven, foodid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeteleFood(int foodid)
        {
            BillInfoDAO.Instance.DeteleBillinfo(foodid);
            string query = string.Format("DELETE Food Where FoodID = {0}", foodid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public void DeteleFoodByIDCategory(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE Food Where idFOODCATEGORY = " + id);
        }
        public void UPFoodBySL(int SL,int id)
        {
            string query = string.Format("UPDATE Food SET	InventoryNumber = (InventoryNumber - {0}) WHERE FoodID = {1}", SL , id);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
