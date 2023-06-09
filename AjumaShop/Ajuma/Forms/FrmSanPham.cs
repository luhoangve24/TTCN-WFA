﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Ajuma.Class;

namespace Ajuma.Forms
{
    public partial class FrmSanPham : Form
    {
        public FrmSanPham()
        {
            InitializeComponent();
        }
        DataTable tblsp;
        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            txtMasanpham.Enabled = false;
            buttonluu.Enabled = false;
            buttonboqua.Enabled = false;
            Class.Functions.FillCombo("SELECT matheloai, tentheloai FROM TheLoai", comboBoxmaloai, "matheloai", "tentheloai");
            comboBoxmaloai.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT manhacungcap, tennhacungcap FROM NhaCungCap", comboBoxmancc, "manhacungcap", "tennhacungcap");
            comboBoxmancc.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT maalbum, tenalbum FROM Album", comboBoxmaalbum, "maalbum", "tenalbum");
            comboBoxmaalbum.SelectedIndex = -1;

            buttonsua.Enabled = false;
            buttonxoa.Enabled = false;
            buttonboqua.Enabled = false;
            buttonopen.Enabled = false;
            Load_DataGridView();
        }
        //
       // string sql;
        public string sql = "SELECT masanpham, tensanpham, dongianhap, dongiaban, soluongkho,  anh, manhacungcap, matheloai, maalbum, trangthai, mota, phienban,  ngayphathanh, trongluong FROM SanPham ";
        private void Load_DataGridView()
        {
             //where MaSanPham=N'" + txtMasanpham.Text + "' 
            tblsp = Class.Functions.GetDataToTable(sql);
            dtgvsp.DataSource = tblsp;
            dtgvsp.Columns[0].HeaderText = "Mã sản phẩm";
            dtgvsp.Columns[1].HeaderText = "Tên sản phẩm";
            dtgvsp.Columns[2].HeaderText = "Giá nhập";
            dtgvsp.Columns[3].HeaderText = "Giá bán";
            dtgvsp.Columns[4].HeaderText = "Số lượng";
            dtgvsp.Columns[5].HeaderText = "Hình ảnh";
            dtgvsp.Columns[6].HeaderText = "Mã nhà cung cấp ";
            dtgvsp.Columns[7].HeaderText = "Mã loại";
            dtgvsp.Columns[8].HeaderText = "Mã album";
            dtgvsp.Columns[9].HeaderText = "Trạng thái";
            dtgvsp.Columns[10].HeaderText = "Mô tả";
            dtgvsp.Columns[11].HeaderText = "Phiên bản";
            dtgvsp.Columns[12].HeaderText = "Ngày phát hành";
            dtgvsp.Columns[13].HeaderText = "Trọng lượng";
            dtgvsp.Columns[0].Width = 80;
            dtgvsp.Columns[1].Width = 100;
            dtgvsp.Columns[2].Width = 80;
            dtgvsp.Columns[3].Width = 80;
            dtgvsp.Columns[4].Width = 80;
            dtgvsp.Columns[5].Width = 200;
            dtgvsp.Columns[6].Width = 80;
            dtgvsp.Columns[7].Width = 80;
            dtgvsp.Columns[8].Width = 80;
            dtgvsp.Columns[9].Width = 80;
            dtgvsp.Columns[10].Width = 80;
            dtgvsp.Columns[11].Width = 80;
            dtgvsp.Columns[12].Width = 80;
            dtgvsp.Columns[13].Width = 80;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dtgvsp.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dtgvsp.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        
        private void ResetValues()
        {
            txtMasanpham.Text = "";
            comboBoxmaloai.Text = "";
            comboBoxmaalbum.Text = "";
           
            comboBoxmancc.Text = "";
            textBoxtensp.Text = "";
            textBoxgianhap.Text = "";
            textBoxgiaban.Text = "";
            textBoxsoluong.Text = "";
            textBoxhinhanh.Text = "";
            pictureBox1.Image = null;
            //txtNgayphathanh.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }

        private void dtgvsp_Click(object sender, EventArgs e)
        {
            string ma;
            if (buttonthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMasanpham.Focus();
                return;
            }
            if (tblsp.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMasanpham.Text = dtgvsp.CurrentRow.Cells["masanpham"].Value.ToString();
            ma = dtgvsp.CurrentRow.Cells["matheloai"].Value.ToString();
            comboBoxmaloai.Text = Class.Functions.GetFieldValues("select tentheloai from TheLoai where matheloai = N'" + ma + "'");
            ma = dtgvsp.CurrentRow.Cells["manhacungcap"].Value.ToString();
            comboBoxmaalbum.Text = Class.Functions.GetFieldValues("select tennhacungcap from NhaCungCap where manhacungcap = N'" + ma + "'");
          
            ma = dtgvsp.CurrentRow.Cells["maalbum"].Value.ToString();
            comboBoxmancc.Text = Class.Functions.GetFieldValues("select tenalbum from Album where maalbum = N'" + ma + "'");
            textBoxtensp.Text = dtgvsp.CurrentRow.Cells["tensanpham"].Value.ToString();
            textBoxgianhap.Text = dtgvsp.CurrentRow.Cells["dongianhap"].Value.ToString();
            textBoxgiaban.Text = dtgvsp.CurrentRow.Cells["dongiaban"].Value.ToString();
            textBoxsoluong.Text = dtgvsp.CurrentRow.Cells["soluongkho"].Value.ToString();
            textBoxhinhanh.Text = Class.Functions.GetFieldValues("SELECT anh FROM SanPham WHERE masanpham = N'" + txtMasanpham.Text + "'");
            txtTrangthai.Text = dtgvsp.CurrentRow.Cells["trangthai"].Value.ToString();
            txtTrongluong.Text = dtgvsp.CurrentRow.Cells["trongluong"].Value.ToString();
            txtPhienban.Text = dtgvsp.CurrentRow.Cells["phienban"].Value.ToString();
            txtMota.Text = dtgvsp.CurrentRow.Cells["mota"].Value.ToString();
            mskngaysinh.Text = dtgvsp.CurrentRow.Cells["ngayphathanh"].Value.ToString();


            //picAnh.Image = Image.FromFile(txtHinhanh.Text);

            if (textBoxhinhanh.Text != "")
            {
                pictureBox1.Visible = true;
                pictureBox1.Image = Image.FromFile(textBoxhinhanh.Text);
            }
            else
            {
                pictureBox1.Visible = false;
            }
            buttonsua.Enabled = true;
            buttonxoa.Enabled = true;
            buttonboqua.Enabled = true;
            buttonopen.Enabled = true;
            /*string str;
            str = "SELECT ngayphathanh FROM SanPham WHERE  masanpham = N'" + txtMasanpham.Text + "'";
            txtNgayphathanh.Text = Functions.GetFieldValues(str);*/
        }

        private void buttonthem_Click(object sender, EventArgs e)
        {
            buttonsua.Enabled = false;
            buttonxoa.Enabled = false;
            buttonboqua.Enabled = true;
            buttonluu.Enabled = true;
            buttonthem.Enabled = false;
            buttonopen.Enabled = true;
            ResetValues();
            txtMasanpham.Enabled = true;
            txtMasanpham.Focus();
        }

        private void buttonluu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMasanpham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasanpham.Focus();
                return;
            }
            if (textBoxtensp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxtensp.Focus();
                return;
            }
            if (textBoxgianhap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập giá nhập cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxgianhap.Focus();
                return;
            }
            if (textBoxgiaban.Text == "")
            {
                MessageBox.Show("Bạn phải nhập giá bán cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxgiaban.Focus();
                return;
            }
            if (textBoxsoluong.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số lượng cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxsoluong.Focus();
                return;
            }
            if (textBoxhinhanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh họa cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxhinhanh.Focus();
                return;
            }
            if (comboBoxmaloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã the loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxmaloai.Focus();
                return;
            }

            if (!Functions.IsDate(mskngaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày phat hanh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Text = "";
                mskngaysinh.Focus();
                return;
            }
            if (mskngaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Focus();
                return;
            }
            if (!Functions.IsDate(mskngaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaysinh.Text = "";
                mskngaysinh.Focus();
                return;
            }

            sql = "SELECT masanpham FROM SanPham WHERE masanpham = N'" + txtMasanpham.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasanpham.Focus();
                txtMasanpham.Text = "";
                return;
            }
            sql = "insert into SanPham values(N'" + txtMasanpham.Text.Trim() + "', N'" + textBoxtensp.Text.Trim() + "', N'" + Functions.ConvertDateTime(mskngaysinh.Text.Trim()) + "', N'" + txtPhienban.Text.Trim() + "', N'" + txtTrongluong.Text + "', N'" + textBoxgianhap.Text + "',  N'" + textBoxgiaban.Text + "',  N'" + textBoxsoluong.Text + "', N'" + txtTrangthai.Text + "', N'" + txtMota.Text + "',N'" + comboBoxmancc.SelectedValue + "', N'" + comboBoxmaloai.SelectedValue + "', N'" + comboBoxmaalbum.SelectedValue + "', N'" + textBoxhinhanh.Text.Trim() + "' )";
            SqlCommand them = new SqlCommand(sql, Class.Functions.Conn);
            them.ExecuteNonQuery();
            MessageBox.Show("Thêm dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Load_DataGridView();
            ResetValues();
            buttonxoa.Enabled = false;
            buttonthem.Enabled = true;
            buttonsua.Enabled = false;
            buttonboqua.Enabled = true;
            buttonluu.Enabled = false;
            txtMasanpham.Enabled = false;
        }

        private void buttonopen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "bitmap(*.bmp)|*.bmp|Gif(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = @"D:\picture123";
            dlgOpen.FilterIndex = 4;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dlgOpen.FileName);
                textBoxhinhanh.Text = dlgOpen.FileName;
            }
        }

        private void buttonsua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblsp.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMasanpham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBoxtensp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxtensp.Focus();
                return;
            }
            if (textBoxgianhap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập giá nhập cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxgianhap.Focus();
                return;
            }
            if (textBoxgiaban.Text == "")
            {
                MessageBox.Show("Bạn phải nhập giá bán cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxgiaban.Focus();
                return;
            }
            if (textBoxsoluong.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số lượng cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxsoluong.Focus();
                return;
            }
            if (textBoxhinhanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh họa cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxhinhanh.Focus();
                return;
            }
            if (comboBoxmaloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxmaloai.Focus();
                return;
            }
            if (comboBoxmaalbum.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã album", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxmaalbum.Focus();
                return;
            }

            if (comboBoxmancc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ma nha cung cap", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxmancc.Focus();
                return;
            }

            sql = "UPDATE SanPham SET tensanpham=N'" + textBoxtensp.Text.Trim().ToString() + "', ngayphathanh=N'" + Functions.ConvertDateTime(mskngaysinh.Text) + "', phienban=N'" + txtPhienban.Text.Trim() + "', trongluong=N'" + txtTrongluong.Text.Trim() + "', dongianhap =N'" + textBoxgianhap.Text.Trim() + "', dongiaban=N'" + textBoxgiaban.Text.Trim() + "', soluongkho=N'" + textBoxsoluong.Text.Trim() + "', trangthai=N'" + txtTrangthai.Text.Trim()+ "', mota=N'" + txtMota.Text.Trim() + "', manhacungcap=N'" + comboBoxmancc.SelectedValue + "', matheloai=N'" + comboBoxmaloai.SelectedValue + "', maalbum=N'" + comboBoxmaalbum.SelectedValue + "', anh=N'" + textBoxhinhanh.Text.Trim() + "' WHERE masanpham=N'" + txtMasanpham.Text + "'";
            Class.Functions.RunSql(sql);
            MessageBox.Show("Đã sửa dữ liệu");
            Load_DataGridView();
            ResetValues();
            buttonboqua.Enabled = false;
            buttonopen.Enabled = false;
            buttonluu.Enabled = false;
        }

        private void buttonboqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            buttonboqua.Enabled = true;
            buttonthem.Enabled = true;
            buttonxoa.Enabled = true;
            buttonsua.Enabled = true;
            buttonluu.Enabled = false;
            txtMasanpham.Enabled = false;
            buttonopen.Enabled = false;
        }

        private void buttonxoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblsp.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMasanpham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblSanPham WHERE MaSanPham = N'" + txtMasanpham.Text + "'";
                Class.Functions.RunSqlDel(sql);
                MessageBox.Show("Đã xóa dữ liệu");
                Load_DataGridView();
                ResetValues();
            }

        }

        private void textBoxgianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBoxgiaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textBoxsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void buttondong_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn thoát? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (a == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
