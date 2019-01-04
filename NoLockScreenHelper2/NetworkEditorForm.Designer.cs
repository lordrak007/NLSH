namespace NoLockScreenHelper2
{
    partial class NetworkEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkEditorForm));
            this.ipAddressControlGateway = new IPAddressControlLib.IPAddressControl();
            this.ipAddressControlIPAddress = new IPAddressControlLib.IPAddressControl();
            this.comboBoxChooseNet = new System.Windows.Forms.ComboBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxNetworkName = new System.Windows.Forms.TextBox();
            this.labelChooseNetLabel = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelNetworkName = new System.Windows.Forms.Label();
            this.labelGateway = new System.Windows.Forms.Label();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ipAddressControlGateway
            // 
            this.ipAddressControlGateway.AllowInternalTab = false;
            this.ipAddressControlGateway.AutoHeight = true;
            this.ipAddressControlGateway.BackColor = System.Drawing.SystemColors.Window;
            this.ipAddressControlGateway.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddressControlGateway.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressControlGateway.Location = new System.Drawing.Point(224, 82);
            this.ipAddressControlGateway.MinimumSize = new System.Drawing.Size(87, 20);
            this.ipAddressControlGateway.Name = "ipAddressControlGateway";
            this.ipAddressControlGateway.ReadOnly = false;
            this.ipAddressControlGateway.Size = new System.Drawing.Size(87, 20);
            this.ipAddressControlGateway.TabIndex = 0;
            this.ipAddressControlGateway.Text = "...";
            // 
            // ipAddressControlIPAddress
            // 
            this.ipAddressControlIPAddress.AllowInternalTab = false;
            this.ipAddressControlIPAddress.AutoHeight = true;
            this.ipAddressControlIPAddress.BackColor = System.Drawing.SystemColors.Window;
            this.ipAddressControlIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddressControlIPAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressControlIPAddress.Location = new System.Drawing.Point(317, 82);
            this.ipAddressControlIPAddress.MinimumSize = new System.Drawing.Size(87, 20);
            this.ipAddressControlIPAddress.Name = "ipAddressControlIPAddress";
            this.ipAddressControlIPAddress.ReadOnly = false;
            this.ipAddressControlIPAddress.Size = new System.Drawing.Size(87, 20);
            this.ipAddressControlIPAddress.TabIndex = 1;
            this.ipAddressControlIPAddress.Text = "...";
            // 
            // comboBoxChooseNet
            // 
            this.comboBoxChooseNet.FormattingEnabled = true;
            this.comboBoxChooseNet.Location = new System.Drawing.Point(12, 28);
            this.comboBoxChooseNet.Name = "comboBoxChooseNet";
            this.comboBoxChooseNet.Size = new System.Drawing.Size(392, 21);
            this.comboBoxChooseNet.TabIndex = 2;
            this.comboBoxChooseNet.Text = "Zvolte položku";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(12, 122);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(329, 122);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Zrušit";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 82);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 5;
            // 
            // textBoxNetworkName
            // 
            this.textBoxNetworkName.Location = new System.Drawing.Point(118, 82);
            this.textBoxNetworkName.Name = "textBoxNetworkName";
            this.textBoxNetworkName.Size = new System.Drawing.Size(100, 20);
            this.textBoxNetworkName.TabIndex = 6;
            // 
            // labelChooseNetLabel
            // 
            this.labelChooseNetLabel.AutoSize = true;
            this.labelChooseNetLabel.Location = new System.Drawing.Point(9, 9);
            this.labelChooseNetLabel.Name = "labelChooseNetLabel";
            this.labelChooseNetLabel.Size = new System.Drawing.Size(156, 13);
            this.labelChooseNetLabel.TabIndex = 7;
            this.labelChooseNetLabel.Text = "Vyberte jednu z nalezených sítí";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(9, 66);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Název";
            // 
            // labelNetworkName
            // 
            this.labelNetworkName.AutoSize = true;
            this.labelNetworkName.Location = new System.Drawing.Point(115, 66);
            this.labelNetworkName.Name = "labelNetworkName";
            this.labelNetworkName.Size = new System.Drawing.Size(60, 13);
            this.labelNetworkName.TabIndex = 9;
            this.labelNetworkName.Text = "Název síťe";
            // 
            // labelGateway
            // 
            this.labelGateway.AutoSize = true;
            this.labelGateway.Location = new System.Drawing.Point(221, 66);
            this.labelGateway.Name = "labelGateway";
            this.labelGateway.Size = new System.Drawing.Size(47, 13);
            this.labelGateway.TabIndex = 10;
            this.labelGateway.Text = "IP Brány";
            // 
            // labelIPAddress
            // 
            this.labelIPAddress.AutoSize = true;
            this.labelIPAddress.Location = new System.Drawing.Point(314, 66);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(53, 13);
            this.labelIPAddress.TabIndex = 11;
            this.labelIPAddress.Text = "IP Adresa";
            // 
            // NetworkEditorForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(420, 160);
            this.ControlBox = false;
            this.Controls.Add(this.labelIPAddress);
            this.Controls.Add(this.labelGateway);
            this.Controls.Add(this.labelNetworkName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelChooseNetLabel);
            this.Controls.Add(this.textBoxNetworkName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.comboBoxChooseNet);
            this.Controls.Add(this.ipAddressControlIPAddress);
            this.Controls.Add(this.ipAddressControlGateway);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(436, 199);
            this.MinimumSize = new System.Drawing.Size(436, 199);
            this.Name = "NetworkEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Úprava sítě";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IPAddressControlLib.IPAddressControl ipAddressControlGateway;
        private IPAddressControlLib.IPAddressControl ipAddressControlIPAddress;
        private System.Windows.Forms.ComboBox comboBoxChooseNet;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxNetworkName;
        private System.Windows.Forms.Label labelChooseNetLabel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelNetworkName;
        private System.Windows.Forms.Label labelGateway;
        private System.Windows.Forms.Label labelIPAddress;
    }
}