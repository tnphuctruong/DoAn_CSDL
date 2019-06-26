﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_BenhVien.UserControls
{
    public partial class UC_Info : UserControl
    {
        private static int _dem1;
        public bool delete;

        public static int Dem1 { get => _dem1; set => _dem1 = value; }

        public UC_Info()
        {
            InitializeComponent();
             delete = false;

        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
            //delete = true;
            UC_Action.Instace.pnlShow.Controls.Clear();
            _dem1 = _dem1 - 1;
            UC_Action hao = new UC_Action();
            if(_dem1 > 0)
            hao.DisplayResult(_dem1);
            UC_Action.Instace.pnlShow.Update();
        }
    }
}
