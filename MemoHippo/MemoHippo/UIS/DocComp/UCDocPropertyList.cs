﻿using MemoHippo.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public partial class UCDocPropertyList : UserControl
    {
        public Color BgColor
        {
            get { return doubleBufferedPanel1.BackColor; }
            set { doubleBufferedPanel1.BackColor = value; }
        }

        public UCDocPropertyList()
        {
            InitializeComponent();
        }

        public void Init(MemoItemInfo itemInfo)
        {
            var oldCtrList = new List<Control>();
            foreach (Control c in doubleBufferedPanel1.Controls)
                oldCtrList.Add(c);
            doubleBufferedPanel1.Controls.Clear();

            CheckCtrs(oldCtrList, "common", "创建时间", new FileInfo(string.Format("{0}/{1}.rtf", ENV.SaveDir, itemInfo.Id)).CreationTime.ToString(), null);
            CheckCtrs(oldCtrList, "multisel", "标签", itemInfo.Tag, (s) => itemInfo.Tag = s);

            Width = 700 - 5;
            Height = doubleBufferedPanel1.Controls.Count * 37 + 10;
        }

        private void CheckCtrs(List<Control> cc, string type, string k, string v, Action<string> onModify)
        {
            var found = FindCtr(cc, k);
            if(found == null)
            {
                if (type == "common")
                    found = new UCDocStringItem();
                else if (type == "multisel")
                    found = new UCDocMultiselItem();

                var foundCtr = found as Control;
                foundCtr.Name = k;
                foundCtr.Height = 37;
                foundCtr.Width = 700 - 5;
                foundCtr.Location = new Point(0, doubleBufferedPanel1.Controls.Count * 37);
            }
            found.OnModify = onModify;
            found.SetData(k, v);

            doubleBufferedPanel1.Controls.Add(found as Control);
        }

        private IDocComp FindCtr(List<Control> cc, string k)
        {
            foreach(Control c in cc)
            {
                if (c.Name == k)
                    return c as IDocComp;
            }
            return null;
        }
    }
}