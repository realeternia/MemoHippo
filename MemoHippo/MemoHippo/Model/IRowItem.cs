using System.Windows.Forms;

namespace MemoHippo.Model
{
    interface IRowItem
    {
        event MouseEventHandler NLMouseClick;
        event MouseEventHandler NLMouseDown;

        void SetTitile(string str);
    }
}
