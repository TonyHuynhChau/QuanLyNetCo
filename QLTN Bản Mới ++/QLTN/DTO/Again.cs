using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DTO
{
    class Again
    {
        public Again(int iD , int iDMAY , int iDBILL ,float  priceTime , float priceFodd , float totalPrice , string  usetime)
        {
            
            
            this.ID = iD;
            this.IDMAY = iDMAY;
            this.IDBILL = iDBILL;
            this.PriceTime = priceTime;
            this.PriceFodd = priceFodd;
            this.TotalPrice = totalPrice;
            this.Usetime = usetime;
        }
        //ID	IDMAY	IDBILL	PriceTime	PriceFodd	TotalPrice	Usetime
        public Again(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.IDMAY = (int)row["IDMAY"];
            this.IDBILL = (int)row["IDBILL"];
            this.PriceTime = (float)Convert.ToDouble(row["PriceTime"].ToString());
            this.PriceFodd = (float)Convert.ToDouble(row["PriceFodd"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["TotalPrice"].ToString());
            this.Usetime = row["Usetime"].ToString();
        }
        private int iD;
        private int iDMAY;
        private int iDBILL;
        private float priceTime;
        private float priceFodd;
        private float totalPrice;
        private string usetime;

        //iD  iDMAY , iDBILL   priceTime   priceFodd  totalPrice   usetime
        public int ID { get => iD; set => iD = value; }
        public int IDMAY { get => iDMAY; set => iDMAY = value; }
        public int IDBILL { get => iDBILL; set => iDBILL = value; }
        public float PriceTime { get => priceTime; set => priceTime = value; }
        public float PriceFodd { get => priceFodd; set => priceFodd = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string Usetime { get => usetime; set => usetime = value; }


    }
}
