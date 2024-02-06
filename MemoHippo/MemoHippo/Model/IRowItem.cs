using System.Windows.Forms;

namespace MemoHippo.Model
{
    public interface IRowItem
    {
        event MouseEventHandler NLMouseClick;
        event MouseEventHandler NLMouseDown;
        event MouseEventHandler NLMouseUp;

        void SetTitle(string str);
        void SetIcon(string icon);
        int ItemId { get; set; }

        void SetSelect(bool sel);

        void AfterInit();
    }
}
