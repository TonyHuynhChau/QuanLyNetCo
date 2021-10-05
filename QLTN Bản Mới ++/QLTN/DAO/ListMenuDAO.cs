using QLTN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;
        private DataRow item;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }

        public List<ListMenu> GetListMenuByComp(int id)
        {
            List<ListMenu> listMenu = new List<ListMenu>();

            string query = "SELECT m.Name,bi.Count,m.PriceUnit,m.PriceUnit* bi.count AS totalPrice FROM BillInfo AS bi , Bill AS b, Menu AS m WHERE bi.BillID = b.BillID AND bi.MenuID = m.MenuID  AND status = 0 AND bi.count= bi.count AND b.ClientID =  " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ListMenu menu = new ListMenu(item);
                listMenu.Add(menu);
            }
            
            return listMenu;
        }
    }
}
