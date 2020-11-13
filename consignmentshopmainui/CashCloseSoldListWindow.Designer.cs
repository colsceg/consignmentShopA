namespace ConsignmentShopMainUI
{
    partial class CashCloseSoldListWindow
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
            this.SoldItemsListBox = new System.Windows.Forms.ListBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SoldItemsListBox
            // 
            this.SoldItemsListBox.FormattingEnabled = true;
            this.SoldItemsListBox.Location = new System.Drawing.Point(0, -1);
            this.SoldItemsListBox.Name = "SoldItemsListBox";
            this.SoldItemsListBox.Size = new System.Drawing.Size(298, 355);
            this.SoldItemsListBox.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(223, 355);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Schließen";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // CashCloseSoldListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 380);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SoldItemsListBox);
            this.Name = "CashCloseSoldListWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Heute verkauft";
            this.Shown += new System.EventHandler(this.CashCloseSoldListWindow_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox SoldItemsListBox;
        private System.Windows.Forms.Button CloseButton;
    }
}