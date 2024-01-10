﻿using MemoHippo;
using MemoHippo.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MemoHippo.UIS.Panels
{
    public partial class UCGmRunSvTime : UserControl
    {
        public Action<string> AfterSelect;

        public UCGmRunSvTime()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void OnInit()
        {
            SetTime(DateTime.Now);
        }


        private void SetTime(DateTime dt)
        {
            textBoxYear.Text = dt.Year.ToString();
            textBoxMonth.Text = dt.Month.ToString();
            textBoxDate.Text = dt.Day.ToString();

            textBoxHour.Text = dt.Hour.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMonth.Text) || string.IsNullOrEmpty(textBoxHour.Text))
                return;

            var nowDate = new DateTime(int.Parse(textBoxYear.Text), int.Parse(textBoxMonth.Text),
                int.Parse(textBoxDate.Text)
                , int.Parse(textBoxHour.Text), 0, 0);

            var addon = int.Parse((sender as Button).Tag.ToString());

            SetTime(nowDate.AddHours(addon));
        }

        private void textBoxYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
        }

        private void textBoxSec_TextChanged(object sender, EventArgs e)
        {
            var txtbox = sender as TextBox;
            if (txtbox.Text == "")
                txtbox.Text = 0.ToString();
            int number = int.Parse(txtbox.Text);
            if (number < 0)
            {
                number = 0;
            }

            if (number > int.Parse(txtbox.Tag.ToString()))
            {
                number = int.Parse(txtbox.Tag.ToString());
            }

            txtbox.Text = number.ToString();
        }

        private bool flag = false;
        private void textBoxYear_Enter(object sender, EventArgs e)
        {
            flag = true;
        }

        private void textBoxYear_MouseUp(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                flag = false;
                (sender as TextBox).SelectAll();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            var nowDate = new DateTime(int.Parse(textBoxYear.Text), int.Parse(textBoxMonth.Text),
             int.Parse(textBoxDate.Text)
             , int.Parse(textBoxHour.Text), 0, 0);

            if (AfterSelect != null)
                AfterSelect((rjToggleButtonIsddl.Checked ? "ddl " : "time ") + TimeTool.FormatTime(nowDate));

            PanelManager.Instance.HideBlackPanel();
        }
    }
}
