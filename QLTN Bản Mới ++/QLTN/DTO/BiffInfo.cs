using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DTO
{
    public class BiffInfo
    {
        public BiffInfo(int id,  int BillID, int FoodID, int DrinkID, int Count)
        {
            this.ID = iD;
            this.BillID = billID;
            this.FoodID = foodID;
            this.DrinkID = drinkID;
            this.Count = count;
        }

        public BiffInfo(DataRow row1)
        {
            this.ID = (int)row1["id"];
            this.BillID = (int)row1["billID"];
            this.FoodID = (int)row1["foodID"];
            this.DrinkID = (int)row1["drinkID"];
            this.Count = (int)row1["count"];
        }



        public int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public int billID;

        public int BillID
        {
            get { return billID; }
            set
            {
                billID = value;
            }
        }

        public int foodID;

        public int FoodID
        {
            get { return foodID; }
            set { foodID = value; }
        }

        public int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }


        public int drinkID;

        public int DrinkID
        {
            get { return drinkID; }
            set { drinkID = value; }
        }
    }
}
