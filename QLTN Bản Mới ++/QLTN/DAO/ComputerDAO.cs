using QLTN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DAO
{
    class ComputerDAO
    {
        private static ComputerDAO instance;

        public static ComputerDAO Instance
        {
            get { if (instance == null) instance = new ComputerDAO(); return ComputerDAO.instance; }
            private set { ComputerDAO.instance = value; }
        }

        public static int ComputerWidth = 145;
        public static int ComputerHeight = 70;

        private ComputerDAO() { }

        public List<Computer> LoadComputerList()
        {
            List<Computer> ComputerList = new List<Computer>();

            DataTable data = DataProvider.Instance.ExecuteQuery("Exec dbo.USP_GetComputerList");

            foreach (DataRow item in data.Rows)
            {
                Computer Comp = new Computer(item);
                ComputerList.Add(Comp);
            }

            return ComputerList;
        }
        public List<Computer2> LoadComputer()
        {
            List<Computer2> ComputerList = new List<Computer2>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM MAY AS m");

            foreach (DataRow item in data.Rows)
            {
                Computer2 Comp = new Computer2(item);
                ComputerList.Add(Comp);
            }

            return ComputerList;
        }
        public int GetStatusByClientID(int id)
        {

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM MAY AS m WHERE status = N'Có Người' AND ID = " + id);

            if (data.Rows.Count > 0)
            {
                Computer comp = new Computer(data.Rows[0]);
                return comp.ID;
            }

            return -1;
        }
        public List<Computer2> SearchComByName(string name)
        {
            List<Computer2> ComputerList = new List<Computer2>();
            string query = string.Format("select * FROM MAY where NAME like N'%{0}%' ", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Computer2 Comp = new Computer2(item);
                ComputerList.Add(Comp);
            }
            return ComputerList;
        }
        public bool InsertCom(string name)
        {
            string query = string.Format("INSERT INTO MAY (NAME, [STATUS])VALUES(N'{0}',N'Trống')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeteleCom(int id)
        {
            BillInfoDAO.Instance.DeteleBillinfoByBill(id);
            MoneyTimeDAO.Instance.DeteleBillMoney(id);
            BillDAO.Instance.DeteleBill(id);           
            string query = string.Format("DELETE FROM MAY WHERE ID = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateCom(string name, int id)
        {
            string query = string.Format("UPDATE MAY SET NAME = N'{0}' where ID = {1}", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
