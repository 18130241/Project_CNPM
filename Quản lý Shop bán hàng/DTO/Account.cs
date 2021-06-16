using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShopBanHang.DTO
{
    public class Account
    {
        private string username;
        private string displayName;
        private string  password;
        private int type;

        public Account(string username, string displayName, string password, int type)
        {
            this.username = Username;
            this.displayName = DisplayName;
            this.password = Password;
            this.type = type;
        }
        public Account(DataRow row)
        {
            this.username = row["Username"].ToString();
            this.displayName = row["DisplayName"].ToString();
            this.password = row["Password"].ToString();
            this.type =(int)row["Type"];
        }
        public string Username
        {
            get
            {
                return Username;
            }

            set
            {
                Username = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return DisplayName;
            }

            set
            {
                DisplayName = value;
            }
        }

        public string Password
        {
            get
            {
                return Password;
            }

            set
            {
                Password = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
    }
}
