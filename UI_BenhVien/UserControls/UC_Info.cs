﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_BenhVien.Forms;
using System.Data.Linq.SqlClient;

namespace UI_BenhVien.UserControls
{
    public partial class UC_Info : UserControl
    {
        private static int _dem1;
        private static int cbindex;
        public bool delete;
        private static int tab;

        public UC_Info()
        {
            InitializeComponent();
             delete = false;

        }

        public static int Dem1
        {
            get
            {
                return _dem1;
            }

            set
            {
                _dem1 = value;
            }
        }

        public static int Cbindex
        {
            get
            {
                return cbindex;
            }

            set
            {
                cbindex = value;
            }
        }

        public static int Tab { get => tab; set => tab = value; }

        public void btnDelete_Click(object sender, EventArgs e)
        {

            delete = true;
            Dem1 = Dem1 - 1;
            UC_Action hao = (UC_Action)this.Parent.Parent;
            using (QuanLyBenhVienDataContext db = new QuanLyBenhVienDataContext())
            {
                if (tab == 1)
                {
                    if (cbindex == 1)
                    {
                        var a = (from bnhan in db.BenhNhans
                                 where bnhan.MaBN.ToString() == this.txbID.Text
                                 select bnhan).FirstOrDefault();
                        db.BenhNhans.DeleteOnSubmit(a);
                        db.SubmitChanges();
                    }
                    else
                    {
                        var a = (from bsy in db.NhanViens
                                 where bsy.MaNV.ToString() == this.txbID.Text
                                 select bsy).FirstOrDefault();
                        db.NhanViens.DeleteOnSubmit(a);
                        db.SubmitChanges();
                    }
                }
                if(tab == 2)
                {
                    var a = (from acc in db.accounts
                             where acc.usernamme == this.textBox1.Text
                             select acc).FirstOrDefault();
                    db.accounts.DeleteOnSubmit(a);
                    db.SubmitChanges();
                }
            }
            hao.DisplayResult(Dem1);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tab == 2)
            {
                if (this.textBox4.Text == "True")
                {
                    MessageBox.Show("Không có quyền thực hiện thay đổi", "Cảnh cáo");
                }
                else
                {
                    txbName.ReadOnly = textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = textBox4.ReadOnly = false;
                    btnSave.Visible = true;
                    btnEdit.Visible = false;
                }
            }
            if (tab == 1)
            {
                txbName.ReadOnly = textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = textBox4.ReadOnly = false;
                btnSave.Visible = true;
                btnEdit.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tab == 1)
            {
                txbName.ReadOnly = textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = textBox4.ReadOnly = true;
                btnEdit.Visible = true;
                btnSave.Visible = false;
                using (QuanLyBenhVienDataContext db = new QuanLyBenhVienDataContext())
                {
                    if (cbindex == 1)
                    {
                        var a = (from bnhan in db.BenhNhans
                                 where bnhan.MaBN.ToString() == this.txbID.Text
                                 select bnhan).FirstOrDefault();
                        a.HotenBN = txbName.Text;
                        a.NgaySinh = DateTime.ParseExact(textBox1.Text, "dd.MM.yyyy", null);
                        a.Diachi = textBox2.Text;
                        a.GioiTinh = (textBox3.Text == "Nam") ? true : false;
                        a.MaBenh = Convert.ToInt32(textBox4.Text);
                        db.SubmitChanges();
                    }
                    else
                    {
                        var a = (from bsy in db.NhanViens
                                 where bsy.MaNV.ToString() == this.txbID.Text
                                 select bsy).FirstOrDefault();
                        a.HotenNV = txbName.Text;
                        a.ChucDanh = textBox1.Text;
                        a.TenKhoa = textBox2.Text;
                        a.MaChuyenNganh = Convert.ToInt32(textBox3.Text);
                        db.SubmitChanges();
                    }
                }
            }
            if (tab == 2)
            {
                using (QuanLyBenhVienDataContext db = new QuanLyBenhVienDataContext()) {
                    var a = (from acc in db.accounts
                             where acc.usernamme == this.textBox1.Text
                             select acc).FirstOrDefault();
                    a.password = textBox2.Text;
                    a.tenhienthi = textBox3.Text;
                    a.admin = (textBox4.Text == "True") ? true : false;
                    db.SubmitChanges();
                }
            }
        }
    }
}
