using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DTO
{
    public class Computer
    {
        public Computer(int iD, string clientName, string statusClient)
        {
            this.ID = iD;
            this.ClientName = clientName;
            this.StatusClient = statusClient;
        }

        public Computer(DataRow row1)
        {
       
            this.ID = (int)row1["ID"];
            this.ClientName = row1["NAME"].ToString();
            this.StatusClient = row1["STATUS"].ToString();
        }

        public int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }


        private string clientName;
        public string statusClient;

        public string StatusClient
        {
            get { return statusClient; }
            set
            {
                statusClient = value;
            }
        }
      
       


    }
}
