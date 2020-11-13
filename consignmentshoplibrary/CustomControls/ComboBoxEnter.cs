using System;
using System.Windows.Forms;

namespace ConsignmentShopLibrary
{
    public class ComboBoxEnter : ComboBox
    {
        private static bool _isClicked = false;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            DroppedDown = false;

            base.OnKeyPress(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            SelectionStart = 0;
            SelectionLength = Text.Length;
            base.OnGotFocus(e);
        }

        protected override void OnClick(EventArgs e)
        {
            int _SelectionStart = SelectionStart;
            
            if (_isClicked)
            {
                SelectionStart = _SelectionStart;
                SelectionLength = 0;
            }
            else
            {
                SelectionStart = 0;
                SelectionLength = Text.Length;
            }
            _isClicked = !_isClicked;

            base.OnClick(e);
            
        }
    }
}
