using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.DTO
{
    class MoneyTime
    {
        public MoneyTime(string name, int gio, int phut)
        {
            this.MÁY = name;
            this.GIỜ = gio;
            this.Phút = phut;
        }

        public MoneyTime(DataRow row)
        {
            this.MÁY = row["NAME"].ToString();
            this.GIỜ = (int)row["Gio"];
            this.Phút = (int)row["Phut"];
        }
        private int gio;
        private int phut;
        private string name;

        public string MÁY
        {
            get { return name; }
            set { name = value; }
        }

        public int GIỜ
        {
            get { return gio; }
            set { gio = value; }
        }

        public int Phút
        {
            get { return phut; }
            set { phut = value; }
        }

    }
}
