using DevExpress.XtraEditors;
using QLTN.DAO;
using QLTN.DTO;
using QLTN.Properties;
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
    public partial class fChính : DevExpress.XtraEditors.XtraForm
    {
        private Account login;

        public Account Login
        {
            get { return login; }
            set { login = value; changeAcc(login.GroupUser); }
        }
        public fChính(Account acc)
        {
            InitializeComponent();

            this.login = acc;

            LoadComputer();
            LoadCategory();
            changeAcc(login.GroupUser);
        }
        #region void
        void LoadComputer()
        {
            flpComp.Controls.Clear();
            List<Computer> ComputerList = ComputerDAO.Instance.LoadComputerList();
            try
            {
                foreach (Computer item in ComputerList)
                {

                    SimpleButton btn = new SimpleButton() { Width = ComputerDAO.ComputerWidth, Height = ComputerDAO.ComputerHeight };
                    btn.Text = item.ClientName + Environment.NewLine + item.StatusClient;
                    btn.Font = new Font("Arial", 10); ;
                    btn.ForeColor = Color.Red;
                    btn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
                    //Sửa Đường Dẫn Đến File Ảnh
                    btn.Image = Resources.Computer;
                    // -----------------------  
                    btn.Click += btn_Click;
                    btn.Tag = item;

                    if (item.StatusClient == "Trống")
                    {
                        btn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
                    }
                    else
                    {
                        btn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Default;
                    }
                    flpComp.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could Not Found "+ex.Message);
            }
        }
        void changeAcc(int type)
        {
            adimToolStripMenuItem.Enabled = type == 1;
        }
        private void A_UpdateCom(object sender, EventArgs e)
        {
            LoadComputer();
        }

        private void A_DeleteCom(object sender, EventArgs e)
        {
            LoadComputer();
        }

        private void A_InsertCom(object sender, EventArgs e)
        {
            LoadComputer();
        }

        private void A_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodCategoryID((cbxCatetory.SelectedItem as Category).ID);
            if (listFood.Tag != null)
            {
                ShowBill((listFood.Tag as Computer).ID);
            }

        }
        private void A_DeletetFood(object sender, EventArgs e)
        {
            LoadFoodCategoryID((cbxCatetory.SelectedItem as Category).ID);
            if (listFood.Tag != null)
            {
                ShowBill((listFood.Tag as Computer).ID);
            }
        }

        private void a_InsertFood(object sender, EventArgs e)
        {
            LoadFoodCategoryID((cbxCatetory.SelectedItem as Category).ID);
            if (listFood.Tag != null)
            {
                ShowBill((listFood.Tag as Computer).ID);
            }
        }
       
        void ShowBill(int id)
        {
            float totalpriceFood = 0;
            listFood.Items.Clear();
            List<DTO.DSMenu> listBillInfo = DSMenuDAO.Instance.GetListMenuByComp(id);
            foreach (DTO.DSMenu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.Name.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                listFood.Items.Add(lsvItem);
                totalpriceFood += item.TotalPrice;
            }
            Txtfood.Text = totalpriceFood.ToString();
        }
        void Show(int id)
        {

            List<DTO.MoneyTime> listBill = MoneyTimeDAO.Instance.GetMoneyTimes(id);
            textBoxGio.Clear();
            textBoxphut.Clear();
            foreach (DTO.MoneyTime item in listBill)
            {
                textBoxGio.Text = item.GIỜ.ToString();
                textBoxphut.Text = item.Phút.ToString();
            }
        }
        void PriceMoney()
        {
            int T = 0;
            int T2 = 0;
            for (int i = 0; i < Convert.ToInt32(textBoxGio.Text); i++)
            {
                T = T + 3000;
            }
            for (int j = -1; j < Convert.ToInt32(textBoxphut.Text); j++)
            {
                if (Convert.ToInt32(textBoxphut.Text) <= 10)
                {
                    T2 = 500;
                    break;
                }
                T2 = T2 + 50;
            }
            int T3 = 0;
            T3 = T + T2;
            tbxTime.Text = T3.ToString();
        }
        void btn_Click(object sender, EventArgs e)
        {
            textBoxGio.Clear();
            textBoxphut.Clear();
            Txtfood.Clear();
            tbxTime.Clear();
            TXBTOTAL.Clear();
            int Computer = ((sender as SimpleButton).Tag as Computer).ID;
            listFood.Tag = (sender as SimpleButton).Tag;
            btnChoose.Tag = (sender as SimpleButton).Tag;
            ShowBill(Computer);
        }
      
        void LoadCategory()
        {
            List<Category> categories = CategoryDAO.Instance.GetListCategory();
            cbxCatetory.DataSource = categories;
            cbxCatetory.DisplayMember = "Name";
        }

        void LoadFoodCategoryID(int id)
        {
            List<DTO.Menu> foods = DAO.MenuDAO.Instance.GetFoodByCategoryID(id);
            cbxFood.DataSource = foods;
            cbxFood.DisplayMember = "Name";

        }
        #endregion
        #region Even
        private void fChính_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Đăng Xuất", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void cbxCatetory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category category = cb.SelectedItem as Category;
            id = category.ID;

            LoadFoodCategoryID(id);
        }

        private void btADDFood_Click(object sender, EventArgs e)
        {
            Computer computer = listFood.Tag as Computer;

            if (computer == null)
            {
                MessageBox.Show("Chọn Máy!!!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                int count = (int)nudAddFood.Value;
                int MenuID = (cbxFood.SelectedItem as DTO.Menu).ID;
                int Sl = MenuDAO.Instance.GetMenus2(MenuID);

                int Status = ComputerDAO.Instance.GetStatusByClientID(computer.ID);
                if (Status == -1)
                {
                    MessageBox.Show("Mở Máy !!!!", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    if (Sl < count)
                    {
                        MessageBox.Show("Món Bạn Chọn Chỉ Còn " + Sl + " Phần Thôi", "Chia Buồn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        int BillID = BillDAO.Instance.GetUncheckBillIDByClientID(computer.ID);
                        if (BillID == -1)
                        {
                            BillDAO.Instance.insertBill(computer.ID);
                            BillInfoDAO.Instance.insertBillinfo(BillDAO.Instance.MaxBillID(), MenuID, count);
                            MenuDAO.Instance.UPFoodBySL(count, MenuID);
                            ShowBill(computer.ID);
                        }
                        else
                        {
                            BillInfoDAO.Instance.insertBillinfo(BillID, MenuID, count);
                            MenuDAO.Instance.UPFoodBySL(count, MenuID);
                            ShowBill(computer.ID);
                        }
                    }
                }
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            Computer computer = listFood.Tag as Computer;
            if (computer == null)
            {
                MessageBox.Show("Chọn Máy!!!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                int Status = ComputerDAO.Instance.GetStatusByClientID(computer.ID);
                if (Status >= 0)
                {
                    MessageBox.Show("Máy Đã Mở");
                }
                else
                {
                    int idBill = BillDAO.Instance.GetUncheckBillIDByClientID(computer.ID);
                    if (idBill == -1)
                    {
                        BillDAO.Instance.insertBill(computer.ID);
                    }
                    if (Status == -1)
                    {
                        if (MessageBox.Show("Bạn Muốn Mở " + computer.ClientName, "Thông Báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            string query = "UPDATE MAY SET [STATUS] = N'Có Người' WHERE [STATUS] = N'Trống' AND ID =" + computer.ID;
                            DataProvider.Instance.ExecuteNonQuery(query);
                            LoadComputer();
                        }
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Computer computer = listFood.Tag as Computer;
            if (computer == null)
            {
                MessageBox.Show("Chọn Máy!!!", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                int Status = ComputerDAO.Instance.GetStatusByClientID(computer.ID);
                if (Status == -1)
                {
                    MessageBox.Show("Mở Máy !!!!", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    int idBill = BillDAO.Instance.GetUncheckBillIDByClientID(computer.ID);
                    if (idBill != -1)
                    {
                        if (MessageBox.Show("Muốn Thanh Toán " + computer.ClientName, "Thông Báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            BillDAO.Instance.CheckOut(idBill);
                            LoadComputer();
                            Show(computer.ID);
                            PriceMoney();
                            int price = Convert.ToInt32(tbxTime.Text);
                            TXBTOTAL.Text = (price + Convert.ToInt32(Txtfood.Text)).ToString();
                            string time = textBoxGio.Text + " : " + textBoxphut.Text;
                            MessageBox.Show(computer.ClientName + " Đã Dùng : " + textBoxGio.Text + " Giờ " + textBoxphut.Text + " Phút" + Environment.NewLine + "Tiền Giờ Là : " + price + " , Tiền Food Là : " + Txtfood.Text + Environment.NewLine + "Tổng : " + TXBTOTAL.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MoneyTimeDAO.Instance.insert(computer.ID, idBill, Convert.ToInt32(tbxTime.Text), Convert.ToInt32(Txtfood.Text), Convert.ToInt32(TXBTOTAL.Text), time);
                        }
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Computer computer = listFood.Tag as Computer;
            List<DTO.Again> listBill = AgainDAO.Instance.GetList(computer.ID);
            foreach (DTO.Again item in listBill)
            {
                tbxTime.Text = item.PriceTime.ToString();
                Txtfood.Text = item.PriceFodd.ToString();
                TXBTOTAL.Text = item.TotalPrice.ToString();
            }
        }

        private void adimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDanhMuc a = new fDanhMuc();
            a.InsertFood += a_InsertFood;
            a.DeletetFood += A_DeletetFood;
            a.UpdateFood += A_UpdateFood;
            a.InsertCom += A_InsertCom;
            a.DeleteCom += A_DeleteCom;
            a.UpdateCom += A_UpdateCom;
            a.ShowDialog();
        }

        private void thôngTinCáNhânToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Thông_Tin_Tài_Kh f = new Thông_Tin_Tài_Kh(login);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void thôngTinCáNhânToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ThoongTin_Cá_Nhân form2 = new ThoongTin_Cá_Nhân(login);
            this.Hide();
            form2.ShowDialog();
            this.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mởMáyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnChoose_Click(this, new EventArgs());
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            simpleButton1_Click(this, new EventArgs());
        }

        private void fChính_Load(object sender, EventArgs e)
        {

        }
        #endregion

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}