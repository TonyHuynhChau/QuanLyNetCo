using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DTO
{
    class Menu2
    {
        public Menu2(int id, string name, string category, float price, string unitLot, int inventoryNumber)
        {
            
            this.FoodID = id;
            this.FoodName = name;
            this.NAME = category;
            this.PriceUnit = price;
            this.UnitLot = unitLot;
            this.InventoryNumber = inventoryNumber;
        }

        public Menu2(DataRow row)
        {
            //STT Tên Loại món    Đơn Giá Đồ Đựng Tồn Kho
            this.FoodID = (int)row["FoodID"];
            this.FoodName = row["FoodName"].ToString();
            this.NAME = row["NAME"].ToString();
            this.PriceUnit = (float)Convert.ToDouble(row["PriceUnit"].ToString());
            this.UnitLot = row["UnitLot"].ToString();
            this.InventoryNumber = (int)row["InventoryNumber"];



        }
        private int id;
        private string name;
        private string category;
        private float price;
        private string unitlot;
        private int inventoryNumber;
        private DataRow item;

        //FoodID	FoodName	NAME	PriceUnit	UnitLot	InventoryNumber
        public int FoodID { get => id; set => id = value; }
        public string FoodName { get => name; set => name = value; }
        public string NAME { get => category; set => category = value; }
        public float PriceUnit { get => price; set => price = value; }
        public string UnitLot { get => unitlot; set => unitlot = value; }
        public int InventoryNumber { get => inventoryNumber; set => inventoryNumber = value; }

    }
}
