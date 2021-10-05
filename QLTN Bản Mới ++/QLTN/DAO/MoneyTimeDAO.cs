using QLTN.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DAO
{
    class MoneyTimeDAO
    {
        private static MoneyTimeDAO instance;


        public static MoneyTimeDAO Instance
        {
            get { if (instance == null) instance = new MoneyTimeDAO(); return MoneyTimeDAO.instance; }
            private set { MoneyTimeDAO.instance = value; }
        }

        private MoneyTimeDAO() { }

        public List<DTO.MoneyTime> GetMoneyTimes(int id)
        {
            List<DTO.MoneyTime> moneyTimes = new List<DTO.MoneyTime>();

            string query = "SELECT m.NAME,DATEPART(hour,(b.DATECHECKOUT - b.DATECHECKIN)) AS Gio ,DATEPART(mi,(b.DATECHECKOUT-b.DATECHECKIN)) AS Phut FROM BILL AS b, MAY AS m WHERE m.ID = b.IDMAY AND m.ID = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MoneyTime moneyTime = new MoneyTime(item);
                moneyTimes.Add(moneyTime);

            }

            return moneyTimes;
        }
        public void insert(int IDmay , int idBill , int priceTime , int priceFodd , int totalPrice , string Usetime)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertMonneyTime @IDmay , @idBill , @priceTime , @priceFodd , @totalPrice , @Usetime ", new object[] { IDmay,  idBill,  priceTime,  priceFodd,  totalPrice,  Usetime });
        }

        public DataTable GetBillListByDate(string CheckIn, string CheckOut)
        {
            return DataProvider.Instance.ExecuteQuery("Exec USP_GetListBill @checkIn , @checkOut ", new object[] { CheckIn, CheckOut });
        }
        public void DeteleBillMoney(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE FROM BILLMonney WHERE IDMAY = " + id);
        }
    }
}
