﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_BenhVien.Forms;

namespace UI_BenhVien
{
    public partial class Form_Login : Form
    {
        public static string DisplayName = String.Empty;
        public static bool admin = false;
        public Form_Login()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            using(QuanLyBenhVienDataContext db = new QuanLyBenhVienDataContext())
            {
                var a = (from user in db.accounts
                         where txbPassword.Text == user.password && txbUsername.Text == user.usernamme
                         select user).FirstOrDefault();
                if(a != null)
                {
                    DisplayName = a.tenhienthi;
                    admin = a.admin;
                    this.Hide();
                    Form_Menu form_Menu = new Form_Menu();
                    form_Menu.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Mật khẩu hoặc tên tài khoản sai", "Thông báo");
                }
            }
        }
        #region effect
        private void btnSignIn_MouseEnter(object sender, EventArgs e)
        {
            btnSignIn.BackColor = Color.SeaGreen;
            btnSignIn.ForeColor = Color.White;
        }
        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackColor = Color.Red;
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackColor = Color.SeaGreen;
        }
        private void btnSignIn_MouseLeave(object sender, EventArgs e)
        {
            btnSignIn.BackColor = Color.White;
            btnSignIn.ForeColor = Color.Green;
        }
        private void txbPassword_Enter(object sender, EventArgs e)
        {
            txbPassword.Text = String.Empty;
        }

        private void txbPassword_Leave(object sender, EventArgs e)
        {
            if (txbPassword.Text == String.Empty)
                txbPassword.Text = "password";
        }
        private void txbUsername_Enter(object sender, EventArgs e)
        {
            txbUsername.Text = String.Empty;
        }

        private void txbUsername_Leave(object sender, EventArgs e)
        {
            if (txbUsername.Text == String.Empty)
                txbUsername.Text = "Tài khoản";
        }

        #endregion

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            Form_SignUp form_signup = new Form_SignUp();
            form_signup.ShowDialog();
        }

        private void txbUsername_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
