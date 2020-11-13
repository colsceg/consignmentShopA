namespace VendorEditUI
{
    partial class VendorEdit
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VendorEdit));
            this.lblVendorID = new System.Windows.Forms.Label();
            this.lblLastname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SaveNewVendorButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.VendorIDTextBox = new System.Windows.Forms.TextBox();
            this.LastnameTextBox = new ConsignmentShopLibrary.TextBoxEnter();
            this.FirstnameTextBox = new ConsignmentShopLibrary.TextBoxEnter();
            this.CommissionTextBox = new ConsignmentShopLibrary.TextBoxEnter();
            this.StreetTextBox = new ConsignmentShopLibrary.TextBoxEnter();
            this.ExpirationTimeTextBox = new ConsignmentShopLibrary.TextBoxEnter();
            this.PlzTextBox = new ConsignmentShopLibrary.PlzTextbox();
            this.TownTextBox = new ConsignmentShopLibrary.TextBoxEnter();
            this.TelefonTextBox = new ConsignmentShopLibrary.TextBoxEnter();
            this.MobilteTextBox = new ConsignmentShopLibrary.TextBoxEnter();
            this.EmailTextBox = new ConsignmentShopLibrary.TextBoxEnter();
            this.SuspendLayout();
            // 
            // lblVendorID
            // 
            this.lblVendorID.AutoSize = true;
            this.lblVendorID.Location = new System.Drawing.Point(34, 26);
            this.lblVendorID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVendorID.Name = "lblVendorID";
            this.lblVendorID.Size = new System.Drawing.Size(131, 15);
            this.lblVendorID.TabIndex = 0;
            this.lblVendorID.Text = "Kunden/Lieferanten Nr";
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.Location = new System.Drawing.Point(34, 88);
            this.lblLastname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(68, 15);
            this.lblLastname.TabIndex = 1;
            this.lblLastname.Text = "Nachname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vorname";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 145);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Strasse";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 209);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Postleitzahl";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 209);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ort";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 274);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Telefonnummer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(290, 274);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Mobilrufnummer";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 339);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "E-Mail Adresse";
            // 
            // SaveNewVendorButton
            // 
            this.SaveNewVendorButton.Location = new System.Drawing.Point(485, 386);
            this.SaveNewVendorButton.Margin = new System.Windows.Forms.Padding(4);
            this.SaveNewVendorButton.Name = "SaveNewVendorButton";
            this.SaveNewVendorButton.Size = new System.Drawing.Size(88, 26);
            this.SaveNewVendorButton.TabIndex = 38;
            this.SaveNewVendorButton.Text = "Speichern";
            this.SaveNewVendorButton.UseVisualStyleBackColor = true;
            this.SaveNewVendorButton.Click += new System.EventHandler(this.SaveNewVendorButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(619, 386);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(88, 26);
            this.CloseButton.TabIndex = 27;
            this.CloseButton.TabStop = false;
            this.CloseButton.Text = "Abbrechen";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(584, 88);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "Kommissionsrate [%]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(584, 145);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 15);
            this.label11.TabIndex = 14;
            this.label11.Text = "Lagerdauer [Tage]";
            // 
            // VendorIDTextBox
            // 
            this.VendorIDTextBox.Enabled = false;
            this.VendorIDTextBox.Location = new System.Drawing.Point(38, 45);
            this.VendorIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.VendorIDTextBox.Name = "VendorIDTextBox";
            this.VendorIDTextBox.ReadOnly = true;
            this.VendorIDTextBox.Size = new System.Drawing.Size(116, 21);
            this.VendorIDTextBox.TabIndex = 15;
            // 
            // LastnameTextBox
            // 
            this.LastnameTextBox.Location = new System.Drawing.Point(38, 106);
            this.LastnameTextBox.Name = "LastnameTextBox";
            this.LastnameTextBox.Size = new System.Drawing.Size(162, 21);
            this.LastnameTextBox.TabIndex = 28;
            this.LastnameTextBox.Leave += new System.EventHandler(this.LastnameTextBox_Leave);
            // 
            // FirstnameTextBox
            // 
            this.FirstnameTextBox.Location = new System.Drawing.Point(310, 106);
            this.FirstnameTextBox.Name = "FirstnameTextBox";
            this.FirstnameTextBox.Size = new System.Drawing.Size(208, 21);
            this.FirstnameTextBox.TabIndex = 29;
            this.FirstnameTextBox.Leave += new System.EventHandler(this.FirstnameTextBox_Leave);
            // 
            // CommissionTextBox
            // 
            this.CommissionTextBox.Location = new System.Drawing.Point(587, 106);
            this.CommissionTextBox.Name = "CommissionTextBox";
            this.CommissionTextBox.Size = new System.Drawing.Size(52, 21);
            this.CommissionTextBox.TabIndex = 36;
            this.CommissionTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CommissionTextBox_KeyUp);
            this.CommissionTextBox.Leave += new System.EventHandler(this.CommissionTextBox_Leave);
            // 
            // StreetTextBox
            // 
            this.StreetTextBox.Location = new System.Drawing.Point(37, 163);
            this.StreetTextBox.Name = "StreetTextBox";
            this.StreetTextBox.Size = new System.Drawing.Size(272, 21);
            this.StreetTextBox.TabIndex = 30;
            this.StreetTextBox.Leave += new System.EventHandler(this.StreetTextBox_Leave);
            // 
            // ExpirationTimeTextBox
            // 
            this.ExpirationTimeTextBox.Location = new System.Drawing.Point(587, 163);
            this.ExpirationTimeTextBox.Name = "ExpirationTimeTextBox";
            this.ExpirationTimeTextBox.Size = new System.Drawing.Size(52, 21);
            this.ExpirationTimeTextBox.TabIndex = 37;
            this.ExpirationTimeTextBox.Leave += new System.EventHandler(this.ExpirationTimeTextBox_Leave);
            // 
            // PlzTextBox
            // 
            this.PlzTextBox.Location = new System.Drawing.Point(37, 227);
            this.PlzTextBox.Name = "PlzTextBox";
            this.PlzTextBox.Size = new System.Drawing.Size(65, 21);
            this.PlzTextBox.TabIndex = 31;
            this.PlzTextBox.Leave += new System.EventHandler(this.PlzTextBox_Leave);
            // 
            // TownTextBox
            // 
            this.TownTextBox.Location = new System.Drawing.Point(126, 227);
            this.TownTextBox.Name = "TownTextBox";
            this.TownTextBox.Size = new System.Drawing.Size(183, 21);
            this.TownTextBox.TabIndex = 32;
            this.TownTextBox.Leave += new System.EventHandler(this.TownTextBox_Leave);
            // 
            // TelefonTextBox
            // 
            this.TelefonTextBox.Location = new System.Drawing.Point(37, 293);
            this.TelefonTextBox.Name = "TelefonTextBox";
            this.TelefonTextBox.Size = new System.Drawing.Size(179, 21);
            this.TelefonTextBox.TabIndex = 33;
            // 
            // MobilteTextBox
            // 
            this.MobilteTextBox.Location = new System.Drawing.Point(293, 293);
            this.MobilteTextBox.Name = "MobilteTextBox";
            this.MobilteTextBox.Size = new System.Drawing.Size(179, 21);
            this.MobilteTextBox.TabIndex = 34;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(37, 357);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(179, 21);
            this.EmailTextBox.TabIndex = 35;
            // 
            // VendorEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(726, 425);
            this.ControlBox = false;
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.MobilteTextBox);
            this.Controls.Add(this.TelefonTextBox);
            this.Controls.Add(this.TownTextBox);
            this.Controls.Add(this.PlzTextBox);
            this.Controls.Add(this.ExpirationTimeTextBox);
            this.Controls.Add(this.StreetTextBox);
            this.Controls.Add(this.CommissionTextBox);
            this.Controls.Add(this.FirstnameTextBox);
            this.Controls.Add(this.LastnameTextBox);
            this.Controls.Add(this.VendorIDTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveNewVendorButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLastname);
            this.Controls.Add(this.lblVendorID);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "VendorEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kunden/Lieferanten bearbeiten";
            this.Load += new System.EventHandler(this.VendorEdit_Load);
            this.Shown += new System.EventHandler(this.VendorEdit_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVendorID;
        private System.Windows.Forms.Label lblLastname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button SaveNewVendorButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox VendorIDTextBox;
        private ConsignmentShopLibrary.TextBoxEnter LastnameTextBox;
        private ConsignmentShopLibrary.TextBoxEnter FirstnameTextBox;
        private ConsignmentShopLibrary.TextBoxEnter CommissionTextBox;
        private ConsignmentShopLibrary.TextBoxEnter StreetTextBox;
        private ConsignmentShopLibrary.TextBoxEnter ExpirationTimeTextBox;
        private ConsignmentShopLibrary.PlzTextbox PlzTextBox;
        private ConsignmentShopLibrary.TextBoxEnter TownTextBox;
        private ConsignmentShopLibrary.TextBoxEnter TelefonTextBox;
        private ConsignmentShopLibrary.TextBoxEnter MobilteTextBox;
        private ConsignmentShopLibrary.TextBoxEnter EmailTextBox;
    }
}

