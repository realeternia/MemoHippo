using MemoHippo.UIS;
using MemoHippo.UIS.Panels;
using System;
using System.Drawing;

namespace MemoHippo
{
    public class PanelManager
    {
        public static PanelManager Instance = new PanelManager();

        private Form1 form1;
        private UCSearch searchForm;
        private UCIconPicker iconPicker;
        private UCNInput peoplePanel;

        public void Init(Form1 form)
        {
            form1 = form;
        }

        public void ShowSearchForm()
        {
            if (searchForm == null)
                searchForm = new UCSearch();

            form1.ShowBlackPanel(searchForm, 0, 0);
            searchForm.OnInit();
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
                iconPicker = new UCIconPicker();
            iconPicker.Form1 = form1;

            iconPicker.AfterSelect = act;

            ReLocate(ref x, ref y, iconPicker.Size);
            form1.ShowBlackPanel(iconPicker, x, y, 1);
            iconPicker.OnInit();
        }

        public void ShowPeopleForm(int x, int y, Action<string> act)
        {
            if (peoplePanel == null)
                peoplePanel = new UCNInput();
            peoplePanel.Form1 = form1;

            peoplePanel.AfterSelect = act;

            ReLocate(ref x, ref y, peoplePanel.Size);
            form1.ShowBlackPanel(peoplePanel, x, y, 1);
            peoplePanel.OnInit(MemoBook.Instance.Cfg.PeopleNames);
        }
    }
}
