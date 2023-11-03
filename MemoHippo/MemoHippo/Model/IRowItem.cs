using System.Windows.Forms;

namespace MemoHippo.Model
{
    interface IRowItem
    {
        event MouseEventHandler NLMouseClick;
        event MouseEventHandler NLMouseDown;

        void SetTitle(string str);
        void SetIcon(string icon);
        int ItemId { get; set; }

        void AfterInit();
    }
}
