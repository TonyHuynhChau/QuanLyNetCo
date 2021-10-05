namespace QLTN.DAO
{
    using QLTN.DTO;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static QLTN.DTO.BillDTO;

    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        /// <summary>
        /// Thành công: bill ID
        /// thất bại: -1
        /// </summary>
        /// <param n></param>
        /// <returns></returns>
        public int GetUncheckBillIDByClientID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE IDMAY = " + id + " AND status = 0");

            if (data.Rows.Count > 0)
            {
                BillDTO bill = new BillDTO(data.Rows[0]);
                return bill.ID;
            }

            return -1;
        }
        public void insertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @ClientID", new object[] { id });
        }
        public int MaxBillID()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(ID) FROM Bill ");
            }
            catch
            {
                return 1;
            }
        }
        public void CheckOut(int id)
        {
            string query = "UPDATE BILL SET DATECHECKOUT = GETDATE(),[STATUS] = 1 WHERE  ID = " + id;
            DataProvider.Instance.ExecuteQuery(query);

        }
        public void DeteleBill(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.Bill WHERE IDMAY = " + id);
        }
    }
}
