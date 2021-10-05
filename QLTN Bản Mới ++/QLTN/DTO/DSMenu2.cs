using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DTO
{
    public class DSMenu2
    {
        public DSMenu2(string name, float priceTime, float priceFodd, float totalPrice, string usetime, DateTime? dATECHECKIN, DateTime? dATECHECKOUT)
        {


            this.NAME = name;
            this.PriceTime = priceTime;
            this.PriceFodd = priceFodd;
            this.TotalPrice = totalPrice;
            this.Usetime = usetime;
            this.DATECHECKIN = dATECHECKIN;
            this.DATECHECKOUT = dATECHECKOUT;
        }

        public DSMenu2(DataRow row)
        {
            this.NAME = row["NAME"].ToString();
            this.PriceTime = (float)Convert.ToDouble((row["PriceTime"]).ToString());
            this.PriceFodd = (float)Convert.ToDouble((row["PriceFodd"]).ToString());
            this.TotalPrice = (float)Convert.ToDouble((row["TotalPrice"]).ToString());
            this.Usetime = row["Usetime"].ToString();
            this.DATECHECKIN = (DateTime?)row["DATECHECKIN"];
            this.DATECHECKOUT = (DateTime?)row["DATECHECKOUT"];

        }

        private string name;
        private float priceTime;
        private float priceFodd;
        private float totalPrice;
        private string usetime;
        private DateTime? dATECHECKIN;
        private DateTime? dATECHECKOUT;

        public string NAME { get => name; set => name = value; }

        public float PriceTime { get => priceTime; set => priceTime = value; }
        public float PriceFodd { get => priceFodd; set => priceFodd = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string Usetime { get => usetime; set => usetime = value; }
        public DateTime? DATECHECKIN
        {
            get { return dATECHECKIN; }
            set { dATECHECKIN = value; }
        }
        public DateTime? DATECHECKOUT
        {
            get { return dATECHECKOUT; }
            set { dATECHECKOUT = value; }
        }
    }
}
