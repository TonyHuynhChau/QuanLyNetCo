using DevExpress.XtraEditors;
using QLTN.DAO;
using QLTN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTN
{
    public partial class Đăng_Nhập : DevExpress.XtraEditors.XtraForm
    {
        public Đăng_Nhập()
        {
            InitializeComponent();

            timer1.Start();
        }

        private void lbMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void Đăng_Nhập_Load(object sender, EventArgs e)
        {
            this.ActiveControl = taikhoantb;
        }
        int Se =Convert.ToInt32(DateTime.Now.Second.ToString());
        int Mi = Convert.ToInt32(DateTime.Now.Minute.ToString());
        int HOUR = Convert.ToInt32(DateTime.Now.Hour.ToString());
        private void timer1_Tick(object sender, EventArgs e)
        {

            Se++;
            if (Se > 59)
            {
                Se = 0;
                Mi++;
            }
            if (Mi > 59)
            {
                Mi = 0;
                HOUR++;
            }
            if (HOUR > 24)
            {
                HOUR = 0;
            }
            if (Se<10)
            {
                simpleButton2.Text ="0" + Se.ToString();
            }
            else
            {
                simpleButton2.Text = "" + Se.ToString();
            }
            if (Mi < 10)
            {
                simpleButton3.Text = "0" + Mi.ToString();
            }
            else
            {
                simpleButton3.Text = "" + Mi.ToString();
            }
            if (HOUR < 10)
            {
                simpleButton4.Text = "0" + HOUR.ToString();
            }
            else
            {
                simpleButton4.Text = "" + HOUR.ToString();
            }

        }
        bool Login(string userName, string password)
        {
            return AccountDAO.Instance.Login(userName, password);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string userName = taikhoantb.Text;
            string password = matkhautb.Text;
            if (Login(userName, password))
            {
                Account login = AccountDAO.Instance.GetAccount2(userName,password);
                fChính m = new fChính(login);
                this.Hide();
                m.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai Tài Khoản Hoặc Mật Khẩu !!!");
                taikhoantb.Focus();
                taikhoantb.Clear();
                matkhautb.Clear();
            }
        }

        private void Đăng_Nhập_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Chắc Thoát Không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void Đăng_Nhập_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}