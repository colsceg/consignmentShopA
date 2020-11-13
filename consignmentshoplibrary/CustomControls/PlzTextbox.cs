using System.Windows.Forms;

namespace ConsignmentShopLibrary
{
    public partial class PlzTextbox : TextBoxEnter
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)  || (Text.Length >= 5 && !(SelectionLength == Text.Length) && !Equals(e.KeyChar, '\b')) )
                e.Handled = true;

            base.OnKeyPress(e);
        }
    }
}
