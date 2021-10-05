using QLTN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DAO
{
    public class DSMenuDAO
    {
        private static DSMenuDAO instance;
        private DataRow item;

        public static DSMenuDAO Instance
        {
            get { if (instance == null) instance = new DSMenuDAO(); return DSMenuDAO.instance; }
            private set { DSMenuDAO.instance = value; }
        }

        private DSMenuDAO() { }

        public List<DSMenu> GetListMenuByComp(int id)
        {
            List<DSMenu> listMenu = new List<DSMenu>();

            string query = "SELECT f.FoodName,b2.[COUNT],f.PriceUnit ,f.PriceUnit * b2.[COUNT] AS totalPrice FROM Food AS f, BILL AS b, BILLINFO AS b2 WHERE f.FoodID = b2.FoodID AND b2.IDBILL = b.ID AND b.STATUS = 0 AND b.IDMAY = " + id;
            
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DSMenu menu = new DSMenu(item);
                listMenu.Add(menu);
            }
            
            return listMenu;
        }
        public List<DSMenu2> GetList()
        {
            List<DSMenu2> listMenu = new List<DSMenu2>();

            string query = "SELECT m.NAME, b.PriceTime,b.PriceFodd,b.TotalPrice,b.Usetime ,b2.DATECHECKIN,b2.DATECHECKOUT FROM BILLMonney AS b,MAY AS m,BILL AS b2 WHERE m.ID=b.IDMAY AND b2.ID=b.IDBILL";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DSMenu2 menu = new DSMenu2(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
