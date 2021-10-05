using DevExpress.XtraEditors;
using Microsoft.Reporting.WinForms;
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
    public partial class fDanhMuc : DevExpress.XtraEditors.XtraForm
    {
        BindingSource comList = new BindingSource();
        BindingSource StaffList = new BindingSource();
        BindingSource foodList = new BindingSource();
        public fDanhMuc()
        {
            InitializeComponent();
            Loadfood();
            datetimepick();
        }

        private void fDanhMuc_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            checkBox1.Checked = true;
           
        }
        void datetimepick()
        {
            DateTime today = DateTime.Now;
            dateTimePicker2.Value = new DateTime(today.Year, today.Month, 1);
            dateTimePicker1.Value = dateTimePicker2.Value.AddMonths(1).AddDays(-1);
        }
        void Loadfood()
        {
            dgvEat.DataSource = foodList;
            loadListFood();
            LoadCategoryIntoCombobox(cbxMenu);
            LoadGroupUser(comboBox1);
            AddMenu();
            dgvComp.DataSource = comList;
            LoadComputer();
            AddComPuter();
            dgvStaff.DataSource = StaffList;
            show();
            AddStaff();
        }


        #region Add
        void loadListFood()
        {
            foodList.DataSource = MenuDAO.Instance.GetMenus();
        }
        void LoadComputer()
        {
            comList.DataSource = ComputerDAO.Instance.LoadComputer();

        }
        void LoadListBillDate(string checkin, string checkout)
        {
            dgvdoanhthu.DataSource = MoneyTimeDAO.Instance.GetBillListByDate(checkin, checkout);
        }
        void show()
        {
            StaffList.DataSource = NhanVienDAO.Instance.GetNhanVien();

        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        void LoadGroupUser(ComboBox comboBox)
        {
            comboBox.DataSource = GroupUserDAO.Instance.GetList();
            comboBox.DisplayMember = "GroupName";
        }
        void AddMenu()
        {
            textBox2.DataBindings.Add(new Binding("Text", dgvEat.DataSource, "ID", true, DataSourceUpdateMode.Never));
            textBox3.DataBindings.Add(new Binding("Text", dgvEat.DataSource, "Name", true, DataSourceUpdateMode.Never));
            nudPrice.DataBindings.Add(new Binding("Value", dgvEat.DataSource, "Price", true, DataSourceUpdateMode.Never));
            nudSL.DataBindings.Add(new Binding("Value", dgvEat.DataSource, "InventoryNumber", true, DataSourceUpdateMode.Never));
            textBox11.DataBindings.Add(new Binding("Text", dgvEat.DataSource, "UnitLot", true, DataSourceUpdateMode.Never));
        }    
        void AddComPuter()
        {
            textBox5.DataBindings.Add(new Binding("Text", dgvComp.DataSource, "ID", true, DataSourceUpdateMode.Never));
            textBox6.DataBindings.Add(new Binding("Text", dgvComp.DataSource, "NAME", true, DataSourceUpdateMode.Never));
            textBox9.DataBindings.Add(new Binding("Text", dgvComp.DataSource, "STATUS", true, DataSourceUpdateMode.Never));
        }

        void AddStaff()
        {
            textBox7.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "ID", true, DataSourceUpdateMode.Never));
            textBox4.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "UserName", true, DataSourceUpdateMode.Never));     
            tbSDTVIP.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "PhoneNumber", true, DataSourceUpdateMode.Never));
            textBox8.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "Email", true, DataSourceUpdateMode.Never));
            var maleBinding = new Binding("Checked", dgvStaff.DataSource, "Sex", true, DataSourceUpdateMode.Never);
            maleBinding.Format += (s, args) => args.Value = ((string)args.Value) == "Nam";
            maleBinding.Parse += (s, args) => args.Value = (bool)args.Value ? "Nam" : "Nữ";
            rbStaffMale.DataBindings.Add(maleBinding);
            rbStaffMale.CheckedChanged += (s, args) => rbStaffFemale.Checked = !rbStaffMale.Checked;
            textBox13.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "AccountName", true, DataSourceUpdateMode.Never));
            textBox12.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "Password", true, DataSourceUpdateMode.Never));

        }
        List<DTO.Menu> SearchFoodByName(string name)
        {
            List<DTO.Menu> menus = MenuDAO.Instance.SearchFoodByName(name);

            return menus;
        }
        List<DTO.Computer2> SearchComByname(string name)
        {
            List<DTO.Computer2> com = ComputerDAO.Instance.SearchComByName(name);

            return com;
        }
        List<DTO.NhanVien> SearchStaffByName(string name)
        {
            List<DTO.NhanVien> nv = NhanVienDAO.Instance.SearchStaffByName(name);

            return nv;
        }
        List<DTO.NhanVien> SearchStaffByPhone(string name)
        {
            List<DTO.NhanVien> nv = NhanVienDAO.Instance.SearchStaffByPhone(name);

            return nv;
        }

        #endregion
        #region EventHandler
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler updateCom;
        public event EventHandler UpdateCom
        {
            add { updateCom += value; }
            remove { updateCom -= value; }
        }
        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private event EventHandler deletetFood;
        public event EventHandler DeletetFood
        {
            add { deletetFood += value; }
            remove { deletetFood -= value; }
        }

        private event EventHandler insertCom;
        public event EventHandler InsertCom
        {
            add { insertCom += value; }
            remove { insertCom -= value; }
        }
        private event EventHandler deleteCom;
        public event EventHandler DeleteCom
        {
            add { deleteCom += value; }
            remove { deleteCom -= value; }
        }

        #endregion begin   
        #region Myevent
        private void simpleButton2_Click(object sender, EventArgs e)
        {

            int id =Convert.ToInt32(textBox7.Text);
            if (AccountDAO.Instance.Reset(id))
            {
                MessageBox.Show("ReSet Thành Công");
                show();
            }
            else
            {
                MessageBox.Show("Có Lỗi");
            }
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedCells.Count > 0 && dgvStaff.SelectedCells[0].OwningRow.Cells["GroupUser"].Value != null)
            {
                int id = (int)dgvStaff.SelectedCells[0].OwningRow.Cells["GroupUser"].Value;

                GroupUser group = GroupUserDAO.Instance.GetGruopByID(id);

                comboBox1.SelectedItem = group;

                int index = -1;
                int i = 0;
                foreach (GroupUser item in comboBox1.Items)
                {
                    if (item.groupUser == group.groupUser)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                comboBox1.SelectedIndex = index;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (dgvEat.SelectedCells.Count > 0 && dgvEat.SelectedCells[0].OwningRow.Cells["CategoryID"].Value != null)
            {         
                    int id = (int)dgvEat.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                    Category cateogory = CategoryDAO.Instance.GetListCategory2(id);

                    cbxMenu.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbxMenu.Items)
                    {
                        if (item.ID == cateogory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbxMenu.SelectedIndex = index;
                }
        }

        private void fDanhMuc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Chắc Thoát Không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                List<DSMenu2> dSMenu2s = DSMenuDAO.Instance.GetList();
                reportViewer1.LocalReport.ReportPath = "DoanhThu.rdlc";
                if (dSMenu2s.Count > 0)
                {
                    var reportDatasource = new ReportDataSource("DoanhThu", dSMenu2s);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(reportDatasource);
                    reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Chưa Có Doanh Thu");
                }
            }
            if (checkBox2.Checked == true)
            {
                List<Menu2> menu2s = MenuDAO.Instance.GetFood();
                reportViewer1.LocalReport.ReportPath = "Menu.rdlc";
                if (menu2s.Count > 0)
                {
                    var reportDatasource = new ReportDataSource("MenuSet", menu2s);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(reportDatasource);
                    reportViewer1.RefreshReport();
                }
            }
            if (checkBox3.Checked == true)
            {
                List<Computer2> com = ComputerDAO.Instance.LoadComputer();
                reportViewer1.LocalReport.ReportPath = "Computer.rdlc";
                if (com.Count > 0)
                {
                    var reportDatasource = new ReportDataSource("ComputerSet", com);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(reportDatasource);
                    reportViewer1.RefreshReport();
                }
            }
            if (checkBox4.Checked == true)
            {
                List<NhanVien2> com = NhanVienDAO.Instance.GetNhanVien2();
                reportViewer1.LocalReport.ReportPath = "NhanVien.rdlc";
                if (com.Count > 0)
                {
                    var reportDatasource = new ReportDataSource("NhanVien", com);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(reportDatasource);
                    reportViewer1.RefreshReport();
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
        }
      
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }
        private void btThongKe_Click(object sender, EventArgs e)
        {
            LoadListBillDate(dateTimePicker2.Value.ToString(), dateTimePicker1.Value.ToString());
        }
        private void btAddEat_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            int id = (cbxMenu.SelectedItem as Category).ID;
            int price = (int)nudPrice.Value;
            string unitlot = textBox11.Text;
            int inven = (int)nudSL.Value;
            if (MenuDAO.Instance.InsertFood(name, id, price, unitlot, inven))
            {
                MessageBox.Show("Thêm Món Thành Công");
                loadListFood();
                if (insertFood != null)
                {
                    insertFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có Lỗi");
            }
        }
        private void btDelEat_Click(object sender, EventArgs e)
        {
            int foodid = Convert.ToInt32(textBox2.Text);

            if (MenuDAO.Instance.DeteleFood(foodid))
            {
                MessageBox.Show("Xóa Món Thành Công");
                loadListFood();
                if (deletetFood != null)
                {
                    deletetFood(this, new EventArgs());
                }

            }
            else
            {
                MessageBox.Show("Có Lỗi");
            }
        }
        private void btUpEat_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            int id = (cbxMenu.SelectedIndex + 1);
            int price = (int)nudPrice.Value;
            string unitlot = textBox11.Text;
            int inven = (int)nudSL.Value;
            int foodid = Convert.ToInt32(textBox2.Text);
            if (MenuDAO.Instance.UpdateFood(name, id, price, unitlot, inven, foodid))
            {
                MessageBox.Show("Sửa Món Thành Công");
                loadListFood();
                if (updateFood != null)
                {
                    updateFood(this, new EventArgs()); ;
                }

            }
            else
            {
                MessageBox.Show("Có Lỗi");
            }
        }
        private void btWatchEat_Click(object sender, EventArgs e)
        {
            loadListFood();
        }
        private void btSearchEat_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            foodList.DataSource = SearchFoodByName(name);
        }

        private void btSearchComp_Click(object sender, EventArgs e)
        {
            string name = tbSearchComp.Text;
            comList.DataSource = SearchComByname(name);
        }
        private void btSearchStaff_Click(object sender, EventArgs e)
        {
            string name = tbSearchStaff.Text;
            StaffList.DataSource = SearchStaffByName(name);
            StaffList.DataSource = SearchStaffByPhone(name);
           
        }

        private void btAddComp_Click(object sender, EventArgs e)
        {
            string name = textBox6.Text;
            if (ComputerDAO.Instance.InsertCom(name))
            {
                MessageBox.Show("Thêm Máy Thành Công");
                LoadComputer();
                if (insertCom != null)
                {
                    insertCom(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có Lỗi");
            }
        }
        private void btDelComp_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(textBox5.Text);
            if (ComputerDAO.Instance.DeteleCom(id))
            {
                MessageBox.Show("Xóa Máy Thành Công");
                LoadComputer();
                if (deleteCom != null)
                {
                    deleteCom(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có Lỗi");
            }
        }
        private void btUpComp_Click(object sender, EventArgs e)
        {
            string name = textBox6.Text;
            int id = Convert.ToInt32(textBox5.Text);
            if (ComputerDAO.Instance.UpdateCom(name, id))
            {
                MessageBox.Show("Sửa Máy Thành Công");
                LoadComputer();
                if (updateCom != null)
                {
                    updateCom(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có Lỗi");
            }
        }
        private void btShowComp_Click(object sender, EventArgs e)
        {
            LoadComputer();
        }
        private void btAddStaff_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox4.Text;
                string Acount = textBox13.Text;
                string pass = textBox12.Text;
                int Group = (comboBox1.SelectedItem as GroupUser).groupUser;
                string SDT = tbSDTVIP.Text;
                string Email = textBox8.Text;
                int account = AccountDAO.Instance.Get(Acount);
                if (name == "" || Acount == "" || pass=="" || SDT == "" || Email == "" )
                {
                    MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
                }
                else
                {
                    if (account != -1)
                    {
                        MessageBox.Show("ACCount Bị Trùng Với Nhân Viên Khác");
                    }
                    else
                    {
                        if (rbStaffMale.Checked == false && rbStaffFemale.Checked == false)
                        {
                            MessageBox.Show("Vui Lòng Điền Đầy Đủ Thông Tin");
                        }
                        if (rbStaffMale.Checked == true)
                        {
                            string i = "Nam";
                            if (AccountDAO.Instance.InsertNV(Acount, pass, name, i, Group, SDT, Email))
                            {
                                MessageBox.Show("Thêm Thành Công");
                                show();
                            }
                            else
                            {
                                MessageBox.Show("Có Lỗi");
                            }
                        }
                        if (rbStaffFemale.Checked == true)
                        {
                            string i = "Nữ";
                            if (AccountDAO.Instance.InsertNV(Acount, pass, name, i, Group, SDT, Email))
                            {
                                MessageBox.Show("Thêm Thành Công");
                                show();
                            }
                            else
                            {
                                MessageBox.Show("Có Lỗi");
                            }

                        }
                    }
                }
            
            }
            catch (Exception)
            {

                MessageBox.Show("Có Lỗi");
            }
        }
        private void btUpStaff_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox7.Text);
            if (AccountDAO.Instance.DeleteNV(id))
            {
                MessageBox.Show("Xóa Thành Công");
                show();
            }
            else
            {
                MessageBox.Show("Có Lỗi");
            }
        }
        private void btDelStaff_Click(object sender, EventArgs e)
        {
                int id = Convert.ToInt32(textBox7.Text);
                string name = textBox4.Text;
                string Acount = textBox13.Text;
                string pass = textBox12.Text;
                int Group = (comboBox1.SelectedItem as GroupUser).groupUser;
                string SDT = tbSDTVIP.Text;
                string Email = textBox8.Text;

                if (rbStaffMale.Checked == true)
                {
                    string i = "Nam";
                    if (AccountDAO.Instance.UpdateNV(Acount, pass, name, i, Group, SDT, Email, id))
                    {
                        MessageBox.Show("Sửa Thành Công");
                        show();
                    }
                    else
                    {
                        MessageBox.Show("Có Lỗi");
                    }
                }
                if (rbStaffFemale.Checked == true)
                {
                    string i = "Nữ";
                    if (AccountDAO.Instance.UpdateNV(Acount, pass, name, i, Group, SDT, Email, id))
                    {
                        MessageBox.Show("Sửa Thành Công");
                        show();
                    }
                    else
                    {
                        MessageBox.Show("Có Lỗi");
                    }

                }
        
        }
        private void btShowStaff_Click(object sender, EventArgs e)
        {
            show();
        }

        #endregion

     
        private void cbxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            CategoryMenu categoryMenu = new CategoryMenu();            
            categoryMenu.InsertCategory += CategoryMenu_InsertCategory;
            categoryMenu.DelCategory += CategoryMenu_DelCategory;
            categoryMenu.ShowDialog();
        }

        private void CategoryMenu_DelCategory(object sender, EventArgs e)
        {
            loadListFood();
            LoadCategoryIntoCombobox(cbxMenu);
        }

        private void CategoryMenu_InsertCategory(object sender, EventArgs e)
        {
            LoadCategoryIntoCombobox(cbxMenu);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ChucVu chucVu = new ChucVu();
            chucVu.InsertChucVu += ChucVu_InsertChucVu;
            chucVu.DelChucVu += ChucVu_DelChucVu;
            chucVu.ShowDialog();
        }

        private void ChucVu_InsertChucVu(object sender, EventArgs e)
        {
            show();
            LoadGroupUser(comboBox1);
        }

        private void ChucVu_DelChucVu(object sender, EventArgs e)
        {
            show();
            LoadGroupUser(comboBox1);
        }
    }
}