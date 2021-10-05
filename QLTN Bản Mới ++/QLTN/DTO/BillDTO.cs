namespace QLTN.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BillDTO
    {
        public BillDTO(int id, DateTime? dateCheckIn, DateTime? dateCheckOut,int idMay, int status)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.IDMAY = idMay;
            this.Status = status;
        }


        public BillDTO(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.DateCheckIn = (DateTime?)row["DATECHECKIN"];
            var dateCheckOutTemp = row["DATECHECKOUT"];
            if(dateCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;
            this.IDMAY = (int)row["IDMAY"];
            this.Status = (int)row["STATUS"];

        }


        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }       

        private DateTime? dateCheckOut;
        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }

        public int IDMAY { get { return idMay; } set { idMay = value; } }

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        private DateTime? dateCheckIn;
        private int idMay;

        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }
    }
}

