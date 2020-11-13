using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentShopLibrary
{
    public class TextBoxEnter : TextBox
    {
        static bool _isClicked;
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
            base.OnKeyDown(e);
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
                int myPosition = _SelectionStart;
                if (TextAlign == HorizontalAlignment.Left)
                {
                    if (myPosition >= Text.Length)
                    {
                        SelectionStart = 0;
                        SelectionLength = Text.Length;
                    }
                }
                else
                {
                    SelectionStart = 0;
                    SelectionLength = Text.Length;
                }
            }
            _isClicked = !_isClicked;
            base.OnClick(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            SelectionStart = 0;
            SelectionLength = Text.Length;
            base.OnClick(e);
        }
    }
}
