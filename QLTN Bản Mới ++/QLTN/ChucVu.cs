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
    public partial class ChucVu : DevExpress.XtraEditors.XtraForm
    {
        public ChucVu()
        {
            InitializeComponent();
            LoadChucVu();
        }

        private void ChucVu_Load(object sender, EventArgs e)
        {

        }
        void  LoadChucVu()
        {
            comboBox1.DataSource = GroupUserDAO.Instance.GetList();
            comboBox1.DisplayMember = "GroupName";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string name = comboBox1.Text;
            if (GroupUserDAO.Instance.InsertChucVu(name))
            {
                MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (insertChucVu != null)
                {
                    insertChucVu(this, new EventArgs());
                }
                LoadChucVu();
            }
            else
            {
                MessageBox.Show("Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private event EventHandler insertChucVu;
        public event EventHandler InsertChucVu
        {
            add { insertChucVu += value; }
            remove { insertChucVu -= value; }
        }
        private event EventHandler delChucVu;
        public event EventHandler DelChucVu
        {
            add { delChucVu += value; }
            remove { delChucVu -= value; }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int id = (comboBox1.SelectedItem as GroupUser).groupUser;
            if (id == 1)
            {
                MessageBox.Show("Không Thể Xóa");
            }
            else
            {
                if (GroupUserDAO.Instance.DelChucVu(id))
                {
                    MessageBox.Show("Xóa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (delChucVu != null)
                    {
                        delChucVu(this, new EventArgs());
                    }
                    LoadChucVu();
                }
                else
                {
                    MessageBox.Show("Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}