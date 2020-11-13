namespace ConsignmentShopMainUI
{
    partial class CashClosePayedListWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PayedItemListBox = new System.Windows.Forms.ListBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PayedItemListBox
            // 
            this.PayedItemListBox.FormattingEnabled = true;
            this.PayedItemListBox.Location = new System.Drawing.Point(0, 1);
            this.PayedItemListBox.Name = "PayedItemListBox";
            this.PayedItemListBox.Size = new System.Drawing.Size(258, 355);
            this.PayedItemListBox.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(182, 356);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Schliessen";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // CashClosePayedListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 379);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.PayedItemListBox);
            this.Name = "CashClosePayedListWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Heute ausgezahlt";
            this.Shown += new System.EventHandler(this.CashClosePayedWindow_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox PayedItemListBox;
        private System.Windows.Forms.Button CloseButton;
    }
}