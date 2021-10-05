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
    public partial class Thông_Tin_Tài_Kh : DevExpress.XtraEditors.XtraForm
    {
        private Account login;
        public Account Login
        {
            get { return login; }
            set { login = value; }
        }
        public Thông_Tin_Tài_Kh(Account acc)
        {
            InitializeComponent();
            this.login = acc;
            ddD();
            Show();
        }
        void ddD()
        {
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
        }
        void Show()
        {
            textBox2.Text = login.AccountName;
            textBox3.Text = login.Password;
            textBox1.Text = login.UserName;

        }

        private void Thông_Tin_Tài_Kh_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
            }
            else
            {
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Chưa Nhập Mật Khẩu");
                textBox4.Clear();
                textBox5.Clear();
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Chưa Nhập Mật Khẩu Mới");
                textBox4.Clear();
                textBox5.Clear();
                return;
            }
            if (textBox5.Text != textBox4.Text)
            {
                MessageBox.Show("Mật Khẩu Mới Không Khớp");
                textBox4.Clear();
                textBox5.Clear();
                return;
            }
            if (checkBox1.Checked == true)
            {
                Account a = AccountDAO.Instance.GetAccount(login.AccountName);
                string pass = textBox4.Text;
                if (textBox3.Text == a.Password)
                {
                    if (AccountDAO.Instance.UpdateNV2(pass, login.AccountName))
                    {
                        MessageBox.Show("Thay Đổi Thành Công");
                        textBox4.Clear();
                        textBox5.Clear();
                        Account a2 = AccountDAO.Instance.GetAccount(login.AccountName);
                        textBox3.Text = a2.Password;
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Có Lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Mật Khẩu Không Khớp!!");
                }
            }
            else
            {
                MessageBox.Show("Check Thay Đổi Thông Tin", "Thông Báo", MessageBoxButtons.OK);

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

        }
    }
}