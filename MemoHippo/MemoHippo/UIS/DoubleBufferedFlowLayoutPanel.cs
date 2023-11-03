using System.Windows.Forms;

namespace MemoHippo.UIS
{
    public class DoubleBufferedFlowLayoutPanel : FlowLayoutPanel
    {
        public DoubleBufferedFlowLayoutPanel()
        {
            DoubleBuffered = true;
        }
    }
}
