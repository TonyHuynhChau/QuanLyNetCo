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
    public partial class CategoryMenu : DevExpress.XtraEditors.XtraForm
    {
        public CategoryMenu()
        {
            InitializeComponent();
            loadcombo();
        }
        void loadcombo()
        {
            comboBox1.DataSource = CategoryDAO.Instance.GetListCategory();
            comboBox1.DisplayMember = "Name";
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string name = comboBox1.Text;
            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm Thành Công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (insertCategory != null)
                {
                    insertCategory(this, new EventArgs());
                }
                loadcombo();
            }
            else
            {
                MessageBox.Show("Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int id = (comboBox1.SelectedItem as Category).ID;
            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (delCategory != null)
                {
                    delCategory(this, new EventArgs());
                }
                loadcombo();
            }
            else
            {
                MessageBox.Show("Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }

        private event EventHandler delCategory;
        public event EventHandler DelCategory
        {
            add { delCategory += value; }
            remove { delCategory -= value; }
        }

    }
}