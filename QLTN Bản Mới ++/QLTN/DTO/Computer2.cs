using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DTO
{
    class Computer2
    {
        public Computer2(int iD, string clientName, string statusClient)
        {
            
            this.ID = iD;
            this.NAME = clientName;
            this.STATUS = statusClient;
        }

        public Computer2(DataRow row1)
        {

            this.ID = (int)row1["ID"];
            this.NAME = row1["NAME"].ToString();
            this.STATUS = row1["STATUS"].ToString();
        }
        public int iD;
        private string clientName;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }


        public string NAME
        {
            get { return clientName; }
            set { clientName = value; }
        }
        public string statusClient;

        public string STATUS
        {
            get { return statusClient; }
            set
            {
                statusClient = value;
            }
        }


    }
}
