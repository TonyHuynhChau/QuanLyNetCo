using QLTN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DAO
{
    class AgainDAO
    {
        private static AgainDAO instance;
        private DataRow item;

        public static AgainDAO Instance
        {
            get { if (instance == null) instance = new AgainDAO(); return AgainDAO.instance; }
            private set { AgainDAO.instance = value; }
        }

        private AgainDAO() { }

        public List<Again> GetList(int id)
        {
            List<Again> listMenu = new List<Again>();

            string query = "SELECT * FROM BILLMonney WHERE id=(SELECT max(id) FROM BILLMonney) AND (SELECT TOP 1 IDMAY FROM BILLMonney ORDER BY ID DESC) = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Again menu = new Again(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
