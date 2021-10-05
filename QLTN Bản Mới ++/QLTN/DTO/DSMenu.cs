using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DTO
{
    public class DSMenu
    {
        public DSMenu(string name, int count , float price, float totalPrice=0)
        {
            this.Name = name;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }

        public DSMenu(DataRow row)
        {
            this.Name = row["FoodName"].ToString();
            this.Count =(int)row["COUNT"];
            this.Price = (float)Convert.ToDouble((row["PriceUnit"]).ToString());
            this.TotalPrice =(float)Convert.ToDouble((row["totalPrice"]).ToString());
        }



        
        private float totalPrice;
        private int count;
        private float price;
        private string name;

        public string Name { get => name; set => name = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
        
    }
}
