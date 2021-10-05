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
using ComboBox = System.Windows.Forms.ComboBox;

namespace QLTN
{
    public partial class ThoongTin_Cá_Nhân : DevExpress.XtraEditors.XtraForm
    {

        private Account login;
        public Account Login
        {
            get { return login; }
            set { login = value; }
        }
        public ThoongTin_Cá_Nhân(Account acc)
        {
            InitializeComponent();
            this.login = acc;
            // Loadcb(comboBox1);
        }

        private void ThoongTin_Cá_Nhân_Load(object sender, EventArgs e)
        {
            Account a2 = AccountDAO.Instance.GetAccount(login.AccountName);
            GroupUser group = GroupUserDAO.Instance.GetGruopByID(login.GroupUser);
            TbxTen.Text = a2.UserName;
            TbxSDT.Text = a2.PhoneNumber;
            textBox1.Text = group.GroupName;
            TbxSex.Text = a2.Sex;
            tbxEmail.Text = a2.Email;
        }
        //void Loadcb(ComboBox cb)
        //{
        //    cb.DataSource = GroupUserDAO.Instance.GetListByID(login.GroupUser);
        //    cb.DisplayMember = "GroupName";
        //    cb.ValueMember = "groupUser";
        //}
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string UserName = TbxTen.Text;
            string Sex = TbxSex.Text;
            string PhoneNumber = TbxSDT.Text;
            string Email = tbxEmail.Text;
            string AccountName = login.AccountName;
            try
            {
                if (Sex != "Nam" && Sex != "Nữ")
                {
                    MessageBox.Show("Chỉ Được Nhập Nam Hoặc Nữ");
                }
                else
                {
                    if (AccountDAO.Instance.UpdateNV3(UserName, Sex, PhoneNumber, Email, AccountName))
                    {
                        Account a2 = AccountDAO.Instance.GetAccount(login.AccountName);
                        TbxTen.Text = a2.UserName;
                        TbxSDT.Text = a2.PhoneNumber;
                        TbxSex.Text = a2.Sex;
                        tbxEmail.Text = a2.Email;
                        MessageBox.Show("Thay Đổi Thành Công");
                        checkBox1.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {             
                tbxEmail.ReadOnly = true;
                TbxTen.ReadOnly = true;
                TbxSDT.ReadOnly = true;               
                TbxSex.ReadOnly = true;
            }
            else
            {
                tbxEmail.ReadOnly = false;
                TbxTen.ReadOnly = false;
                TbxSDT.ReadOnly = false;               
                TbxSex.ReadOnly = false;

            }
        }
    }
}