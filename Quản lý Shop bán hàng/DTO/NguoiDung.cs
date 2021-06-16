using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanHang.DTO
{
    class NguoiDung
    {

        private String hoten, email, phone, taikhoan, matkhau, xacnhanMK;

        public NguoiDung()
        {
            hoten = email = phone = taikhoan = matkhau = xacnhanMK = " ";
        }
        public NguoiDung(String ten, String mail, String sđt, String tk, String mk, string XNMK)
        {
            hoten = ten;
            email = mail;
            phone = sđt;
            taikhoan = tk;
            matkhau = mk;
            xacnhanMK = XNMK;
        }
        //True: hợp lê, False : ko hợp lệ
        public Boolean KTDinhDangMatKhau() // Tối thiểu 8 kí tự và có cả chữ & số
        {

            if (matkhau.Length < 8)
            {
                return false;
            }
            //Kiểm tra chữ và số
            Boolean KTChu = false; //coi như chưa có chữ
            Boolean KTSo = false; //coi như chưa có số

            for (int i = 0; i < matkhau.Length; ++i)
            {
                if (KTChu == true && KTSo == true)
                {
                    break;
                    //Dừng vòng lăp lại
                }
                //A -> Z :Bắt đầu 65
                //a -> z :bắt đầu 97
                if ((matkhau[i] >= 'A' && matkhau[i] <= 'Z') || (matkhau[i] >= 'a' && matkhau[i] <= 'z'))
                {
                    KTChu = true;
                }
                if (matkhau[i] > '0' && matkhau[i] < '9')
                {
                    KTSo = true;
                }
            }
            if (KTSo == false && KTChu == false)
            {
                return false; // không hợp lệ
            }
            return true; // hoàn toàn hợp lệ
        }
        public Boolean CheckEmail() // Kiểm tra Email đúng định dạng
        {
            //Liệt kê ra hết các trường hợp sai

            //Nếu ko chứa @ là sai
            if (!email.Contains("@"))
            {
                return false;
            }
            // Nếu ko chứa .com là sai
            if (!email.Contains(".com"))
            {
                return false;
            }
            int index1 = email.IndexOf("@");
            int index2 = email.IndexOf(".com");

            string s = email.Substring(index1 + 1, index2 - index1 - 1);
            if (s != "gmail" && s != "yahoo" && s != "hotmail")
            {
                return false;
            }
            if (s == "yahoo")
            {
                if (!email.Contains(".vn"))
                {
                    return false;
                }
            }
            return true;
        }
        public string ChuanHoaHoTen()
        {
            hoten = hoten.Trim();//Bỏ khoảng trắng đầu và cuối chuỗi
            //Nếu phát hiện 2 khoảng trắng trùng nhau liên tiếp thì xóa đi 1
            for (int i = 0; i < hoten.Length; ++i)
            {
                if (hoten[i] == ' ' && hoten[i + 1] == ' ')
                {
                    hoten = hoten.Remove(i, 1);
                    i--;
                }

            }
            hoten = hoten.ToLower();
            //a -> A(a:97,A:65)
            //In hoa ký tự đầu tiên
            char c = hoten[0];
            hoten = hoten.Remove(0, 1);
            hoten = hoten.Insert(0, c.ToString().ToUpper());
            //Xử lí in hoa kí tự đầu mỗi từ sau khoảng trắng
            for (int i = 1; i < hoten.Length; ++i)
            {
                if (hoten[i] == ' ')//i+1 sẽ viết hoa
                {
                    char c1 = hoten[i + 1];
                    hoten = hoten.Remove(i + 1, 1);
                    hoten = hoten.Insert(i + 1, c1.ToString().ToUpper());
                }
            }
            return hoten; // trả về họ tên
        }
    }
}
