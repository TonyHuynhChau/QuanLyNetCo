using QLTN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DAO
{
    public class BillInfoDAO
    {
        
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }

        public List<BiffInfo> GetListBillInfo(int id)
        {
            List<BiffInfo> listBillInfo = new List<BiffInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo WHERE BillID = " + id);

            foreach (DataRow item in data.Rows)
            {
                BiffInfo info = new BiffInfo(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }
        public void insertBillinfo(int BillID, int MenuID, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillinfo @BillID , @MenuID , @count ", new object[] { BillID , MenuID, count });
        }
        public void DeteleBillinfo(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE FROM dbo.BillInfo WHERE FoodID = " + id);
        }
        public void DeteleBillinfoByBill(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE b2 FROM BILL AS b1 LEFT JOIN BILLINFO AS b2 ON b1.ID=b2.IDBILL WHERE b1.IDMAY = " + id);
        }
    }
}
