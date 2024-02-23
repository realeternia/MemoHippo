﻿using MemoHippo.UIS;
using MemoHippo.UIS.Panels;
using MemoHippo.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MemoHippo
{
    public class PanelManager
    {
        public static PanelManager Instance = new PanelManager();

        private Form1 form1;
        private UCSearch searchForm;
        private UCRoleStore roleStore;
        private UCIconPicker iconPicker;
        private UCNInput intputPanel;
        private UCBigBox bigBox;
        private UCSettingBar setupBar;
        private InputTextBox inputBox;
        private InputNumberBox numberBox;
        private InputArrayBox arrayBox;
        private InputColorBox colorBox;
        private UCGmRunSvTime timePicker; 

        public void Init(Form1 form) 
        {
            form1 = form;
        }

        public void ShowSearchForm(string keyword = "")
        {
            if (searchForm == null)
            {
                searchForm = new UCSearch();
                searchForm.Form1 = form1;
            }

            ShowBlackPanel(searchForm, 0, 0);

            searchForm.OnInit(keyword);
        }

        public void ShowRoleStore(string keyword = "")
        {
            if (roleStore == null)
            {
                roleStore = new UCRoleStore();
                roleStore.Form1 = form1;
            }

            ShowBlackPanel(roleStore, 0, 0);

            roleStore.OnInit(keyword);
        }

        private void ReLocate(ref int x, ref int y, Size formSize)
        {
            var xBound = form1.Width - 10;
            var yBound = form1.Height - 50;

            if (x + formSize.Width > xBound)
                x = xBound - formSize.Width;
            if (y + formSize.Height > yBound)
                y = yBound - formSize.Height;
        }

        public void ShowIconForm(int x, int y, Action<string> act)
        {
            if (iconPicker == null)
            {
                iconPicker = new UCIconPicker();
            }

            iconPicker.AfterSelect = act;

            ReLocate(ref x, ref y, iconPicker.Size);
            ShowBlackPanel(iconPicker, x, y, 1);
            iconPicker.OnInit();
        }

        public void ShowPeopleForm(int x, int y, Action<string> act)
        {
            if (intputPanel == null)
            {
                intputPanel = new UCNInput();
            }

            intputPanel.Mode = UCNInput.UCNInputMode.Name;
            intputPanel.AfterSelect = act;

            ReLocate(ref x, ref y, intputPanel.Size);
            ShowBlackPanel(intputPanel, x, y, 1);

            List<string> names = RoleDB.Instance.DB.GetValuesByHeader("姓名");
            names.AddRange(MemoBook.Instance.Cfg.PeopleNames);
            names.Sort();
            intputPanel.OnInit(names.ToArray());
        }

        public void ShowPageForm(int x, int y, Action<string> act)
        {
            if (intputPanel == null)
            {
                intputPanel = new UCNInput();
            }

            intputPanel.Mode = UCNInput.UCNInputMode.String;
            intputPanel.AfterSelect = act;

            ReLocate(ref x, ref y, intputPanel.Size);
            ShowBlackPanel(intputPanel, x, y, 1);
            intputPanel.OnInit(MemoBook.Instance.GetAllPageInfos());
        }

        public void ShowBigBox(string rtf)
        {
            if (bigBox == null)
            {
                bigBox = new UCBigBox();
            }

            ShowBlackPanel(bigBox, 0, 0);

            bigBox.OnInit(rtf);
        }

        public void ShowSetup()
        {
            if (setupBar == null)
            {
                setupBar = new UCSettingBar();
                setupBar.Init();
            }

            ShowBlackPanel(setupBar, 0, 0);
        }

        public void ShowInputBox(string str, Action<string> callback)
        {
            if (inputBox == null)
            {
                inputBox = new InputTextBox();
                inputBox.Width = 500;
            }

            inputBox.Text = str;
            inputBox.OnCustomTextChanged = (s1) => callback(s1);

            ShowBlackPanel(inputBox, 0, 0);
            inputBox.OnInit();
        }

        public void ShowNumberBox(int number, int min, int max, Action<int> callback)
        {
            if (numberBox == null)
            {
                numberBox = new InputNumberBox();
                numberBox.Width = 500;
            }

            numberBox.ValMin = min;
            numberBox.ValMax = max;
            numberBox.Value = number;
            numberBox.OnCustomTextChanged = (s1) => callback(s1);

            ShowBlackPanel(numberBox, 0, 0);
            numberBox.OnInit();
        }

        public void ShowStrArrayBox(string[] strs, Action<string[]> callback)
        {
            if (arrayBox == null)
            {
                arrayBox = new InputArrayBox();
                arrayBox.Width = 500;
            }

            arrayBox.StrArray = strs;
            arrayBox.OnCustomTextChanged = (s1) => callback(s1);

            ShowBlackPanel(arrayBox, 0, 0);
            arrayBox.OnInit();
        }

        public void ShowColorBox(Color c, Action<Color> callback)
        {
            if (colorBox == null)
            {
                colorBox = new InputColorBox();
                colorBox.Width = 500;
            }

            colorBox.OnCustomTextChanged = (s1) => callback(s1);

            ShowBlackPanel(colorBox, 0, 0);
            colorBox.OnInit(c);
        }

        public void ShowTimeForm(int x, int y, Action<string> act)
        {
            if (timePicker == null)
            {
                timePicker = new UCGmRunSvTime();
            }

            timePicker.AfterSelect = act;

            ReLocate(ref x, ref y, timePicker.Size);
            ShowBlackPanel(timePicker, x, y, 1);
            timePicker.OnInit();
        }

        public void ShowBlackPanel(Control ctr, int x, int y, float bright = 0.5f)
        {
            Bitmap bitmap = new Bitmap(form1.Width+2, form1.Height+2);
            using (Graphics graphics = Graphics.FromImage(bitmap))
                graphics.CopyFromScreen(form1.PointToScreen(Point.Empty), Point.Empty, form1.Size);

            form1.panelBlack.SetUp(ctr, x, y, bitmap, bright);
            form1.panelBlack.BringToFront();
        }

        public void HideBlackPanel()
        {
            form1.panelBlack.HideAll();
        }
    }
}
