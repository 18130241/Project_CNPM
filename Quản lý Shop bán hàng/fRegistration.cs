using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyShopBanHang.DTO;

namespace QuanLyShopBanHang
{
    public partial class fRegistration : Form
    {
        string conn = @"Data Source=VAN_TIEN\SQLEXPRESS;Initial Catalog=QuanLyShopBanHang;Integrated Security=True";

        public fRegistration()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc chắn muốn thoát không", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
                Application.Exit();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(conn);
            try
            {

                NguoiDung nd = new NguoiDung(txtName.Text, txtEmail.Text, txtPhone.Text, txtAccount.Text, txtMK.Text, txtXNMK.Text);
                if (!nd.CheckEmail())
                {
                    DialogResult tb9 = MessageBox.Show("Email không đúng định dạng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEmail.Focus();
                }
                else
                {
                    if (nd.KTDinhDangMatKhau() == true)
                    {
                        if (txtName.Text != "" && txtEmail.Text != "" && txtPhone.Text != "" && txtAccount.Text != ""
                   && txtMK.Text != "" && txtXNMK.Text != "")
                        {
                            connection.Open();
                            //string sql = "insert into Customer values('" + txtName.Text + "','" + txtEmail.Text + "','" + txtPhone.Text +
                            //    "','" + txtAccount.Text + "','" + txtMK.Text + "','" + txtXNMK.Text + "')";
                            string sql1 = "insert into Account  values('" + txtAccount.Text + "','" + txtName.Text + "','" + txtMK.Text + "','" + cbType.Text + "')";
                            SqlCommand cmd = new SqlCommand(sql1, connection);
                            int result = (int)cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                // MessageBox.Show("Thêm tài khoản thành công");
                                flogin flogin = new flogin();
                                this.Hide();
                                flogin.ShowDialog();
                                this.Show();
                                // ClearTextBox();

                            }
                            else

                                MessageBox.Show("Thêm thất bại");
                            connection.Close();

                        }

                    }
                    else
                    {
                        DialogResult tb8 = MessageBox.Show("Mật Khẩu không đúng định dạng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMK.Focus();
                        txtMK.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối" + ex.Message);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chỉ được nhập chữ, phím space và phím xóa
            if (Char.IsDigit(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && (Keys)e.KeyChar != Keys.Space)
            {
                e.Handled = true;
            }
            //Chuẩn hóa trực tiếp Họ tên
            if (txtName.Text == " ")
            {
                if ((Keys)e.KeyChar == Keys.Space)
                {
                    e.Handled = true;
                }
                if (Char.IsLower(e.KeyChar))
                {
                    e.Handled = true;

                    char c = e.KeyChar;
                    txtName.Text = c.ToString().ToUpper();
                    txtName.Select(txtName.Text.Length, 1);

                }

            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chỉ được nhập số không được nhập chữ
            if (!Char.IsDigit(e.KeyChar) && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
