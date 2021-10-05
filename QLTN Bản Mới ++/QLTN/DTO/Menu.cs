using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DTO
{
    class Menu
    {
        public Menu(int id, string name, int categoryID, float price, string unitLot, int inventoryNumber)
        {
            this.ID = id;
            this.Name = name;
            this.CategoryID = categoryID;
            this.Price = price;
            this.UnitLot = unitLot;
            this.InventoryNumber = inventoryNumber;
        }

        public Menu(DataRow row)
        {
          
            this.ID = (int)row["FoodID"];
            this.Name = row["FoodName"].ToString();
            this.CategoryID = (int)row["idFOODCATEGORY"];
            this.Price = (float)Convert.ToDouble(row["PriceUnit"].ToString());
            this.UnitLot = row["UnitLot"].ToString();
            this.InventoryNumber = (int)row["InventoryNumber"];



        }



        private int id;
        private string name;
        private int categoryID;
        private float price;
        private string unitlot;
        private int inventoryNumber;


        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public float Price { get => price; set => price = value; }
        public string UnitLot { get => unitlot; set => unitlot = value; }
        public int InventoryNumber { get => inventoryNumber; set => inventoryNumber = value; }

    }
}
