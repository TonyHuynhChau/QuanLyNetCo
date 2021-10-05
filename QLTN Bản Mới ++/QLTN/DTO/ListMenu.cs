using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DTO
{
    public class ListMenu
    {
        public ListMenu(string name, int count , float price, float totalPrice=0)
        {
            this.Name = name;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }

        public ListMenu(DataRow row)
        {
            //this.FoodName = row["foodname"].ToString();
            //this.Count = (int)row["count"];
            //this.Price = (float)Convert.ToDouble((row["price"]).ToString());
            //this.TotalPrice = (float)Convert.ToDouble(row["totalprice"].ToString());

            Console.WriteLine($"{row[0]}, {row[1]} , {row[2]} , {row[3]}");
            this.Name = row[0].ToString();
            this.Count = (int)Convert.ToDouble((row[1]).ToString());
            this.Price = (float)Convert.ToDouble((row[2]).ToString());
            this.TotalPrice = (float)Convert.ToDouble(row[3].ToString());
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
