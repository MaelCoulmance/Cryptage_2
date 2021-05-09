using System.Windows.Forms;

namespace Cryptage.Visual
{
    public partial class VigenereWindow : Form
    {
        public VigenereWindow()
        {
            InitializeComponent();
            CenterToParent();
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }
    }
}