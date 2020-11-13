using System.Windows.Forms;

namespace ConsignmentShopLibrary
{
    public class NumComboBox : ComboBoxEnter
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

            base.OnKeyPress(e);
        }
    }
}
