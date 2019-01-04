namespace NoLockScreenHelper2
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.buttonPortableMaker = new System.Windows.Forms.Button();
            this.checkBoxActivateOnStartup = new System.Windows.Forms.CheckBox();
            this.checkBoxRunOnLogOn = new System.Windows.Forms.CheckBox();
            this.groupBoxBehaviorals = new System.Windows.Forms.GroupBox();
            this.groupBoxOthers = new System.Windows.Forms.GroupBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.objectListView1 = new BrightIdeasSoftware.DataListView();
            this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnNetworkName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnIPAddress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnGateway = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.checkBoxEnableNotificationBubbles = new System.Windows.Forms.CheckBox();
            this.groupBoxBehaviorals.SuspendLayout();
            this.groupBoxOthers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPortableMaker
            // 
            this.buttonPortableMaker.Location = new System.Drawing.Point(6, 28);
            this.buttonPortableMaker.Name = "buttonPortableMaker";
            this.buttonPortableMaker.Size = new System.Drawing.Size(166, 23);
            this.buttonPortableMaker.TabIndex = 0;
            this.buttonPortableMaker.Text = "Udělat přenositelné";
            this.buttonPortableMaker.UseVisualStyleBackColor = true;
            this.buttonPortableMaker.Click += new System.EventHandler(this.buttonPortableMaker_Click);
            // 
            // checkBoxActivateOnStartup
            // 
            this.checkBoxActivateOnStartup.AutoSize = true;
            this.checkBoxActivateOnStartup.Location = new System.Drawing.Point(6, 19);
            this.checkBoxActivateOnStartup.Name = "checkBoxActivateOnStartup";
            this.checkBoxActivateOnStartup.Size = new System.Drawing.Size(130, 17);
            this.checkBoxActivateOnStartup.TabIndex = 1;
            this.checkBoxActivateOnStartup.Text = "Aktivovat po spuštění";
            this.checkBoxActivateOnStartup.UseVisualStyleBackColor = true;
            this.checkBoxActivateOnStartup.CheckedChanged += new System.EventHandler(this.checkBoxActivateOnStartup_CheckedChanged);
            // 
            // checkBoxRunOnLogOn
            // 
            this.checkBoxRunOnLogOn.AutoSize = true;
            this.checkBoxRunOnLogOn.Location = new System.Drawing.Point(6, 36);
            this.checkBoxRunOnLogOn.Name = "checkBoxRunOnLogOn";
            this.checkBoxRunOnLogOn.Size = new System.Drawing.Size(123, 17);
            this.checkBoxRunOnLogOn.TabIndex = 2;
            this.checkBoxRunOnLogOn.Text = "Spustit po přihlášení";
            this.checkBoxRunOnLogOn.UseVisualStyleBackColor = true;
            this.checkBoxRunOnLogOn.CheckedChanged += new System.EventHandler(this.checkBoxRunOnLogOn_CheckedChanged);
            // 
            // groupBoxBehaviorals
            // 
            this.groupBoxBehaviorals.Controls.Add(this.checkBoxEnableNotificationBubbles);
            this.groupBoxBehaviorals.Controls.Add(this.checkBoxRunOnLogOn);
            this.groupBoxBehaviorals.Controls.Add(this.checkBoxActivateOnStartup);
            this.groupBoxBehaviorals.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBehaviorals.Name = "groupBoxBehaviorals";
            this.groupBoxBehaviorals.Size = new System.Drawing.Size(171, 77);
            this.groupBoxBehaviorals.TabIndex = 4;
            this.groupBoxBehaviorals.TabStop = false;
            this.groupBoxBehaviorals.Text = "Chování";
            // 
            // groupBoxOthers
            // 
            this.groupBoxOthers.Controls.Add(this.buttonPortableMaker);
            this.groupBoxOthers.Location = new System.Drawing.Point(189, 12);
            this.groupBoxOthers.Name = "groupBoxOthers";
            this.groupBoxOthers.Size = new System.Drawing.Size(178, 77);
            this.groupBoxOthers.TabIndex = 5;
            this.groupBoxOthers.TabStop = false;
            this.groupBoxOthers.Text = "Ostatní";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(12, 222);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Přidat";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemove.Location = new System.Drawing.Point(93, 222);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 7;
            this.buttonRemove.Text = "Odebrat";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.olvColumnName);
            this.objectListView1.AllColumns.Add(this.olvColumnNetworkName);
            this.objectListView1.AllColumns.Add(this.olvColumnIPAddress);
            this.objectListView1.AllColumns.Add(this.olvColumnGateway);
            this.objectListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.olvColumnNetworkName,
            this.olvColumnIPAddress,
            this.olvColumnGateway});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.DataSource = null;
            this.objectListView1.Location = new System.Drawing.Point(12, 95);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(395, 121);
            this.objectListView1.TabIndex = 8;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // olvColumnName
            // 
            this.olvColumnName.AspectName = "Name";
            this.olvColumnName.Text = "Název";
            this.olvColumnName.Width = 92;
            // 
            // olvColumnNetworkName
            // 
            this.olvColumnNetworkName.AspectName = "NetworkName";
            this.olvColumnNetworkName.Text = "Název sítě";
            this.olvColumnNetworkName.Width = 98;
            // 
            // olvColumnIPAddress
            // 
            this.olvColumnIPAddress.AspectName = "IPAddress";
            this.olvColumnIPAddress.Text = "IP Adresa";
            this.olvColumnIPAddress.Width = 100;
            // 
            // olvColumnGateway
            // 
            this.olvColumnGateway.AspectName = "Gateway";
            this.olvColumnGateway.Text = "IP Brány";
            this.olvColumnGateway.Width = 100;
            // 
            // checkBoxEnableNotificationBubbles
            // 
            this.checkBoxEnableNotificationBubbles.AutoSize = true;
            this.checkBoxEnableNotificationBubbles.Location = new System.Drawing.Point(6, 54);
            this.checkBoxEnableNotificationBubbles.Name = "checkBoxEnableNotificationBubbles";
            this.checkBoxEnableNotificationBubbles.Size = new System.Drawing.Size(147, 17);
            this.checkBoxEnableNotificationBubbles.TabIndex = 9;
            this.checkBoxEnableNotificationBubbles.Text = "Povolit informační bubliny";
            this.checkBoxEnableNotificationBubbles.UseVisualStyleBackColor = true;
            this.checkBoxEnableNotificationBubbles.CheckedChanged += new System.EventHandler(this.checkBoxEnableNotificationBubbles_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(420, 257);
            this.Controls.Add(this.objectListView1);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.groupBoxOthers);
            this.Controls.Add(this.groupBoxBehaviorals);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nastavení";
            this.groupBoxBehaviorals.ResumeLayout(false);
            this.groupBoxBehaviorals.PerformLayout();
            this.groupBoxOthers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPortableMaker;
        private System.Windows.Forms.CheckBox checkBoxActivateOnStartup;
        private System.Windows.Forms.CheckBox checkBoxRunOnLogOn;
        private System.Windows.Forms.GroupBox groupBoxBehaviorals;
        private System.Windows.Forms.GroupBox groupBoxOthers;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private BrightIdeasSoftware.DataListView objectListView1;
        private BrightIdeasSoftware.OLVColumn olvColumnName;
        private BrightIdeasSoftware.OLVColumn olvColumnNetworkName;
        private BrightIdeasSoftware.OLVColumn olvColumnIPAddress;
        private BrightIdeasSoftware.OLVColumn olvColumnGateway;
        private System.Windows.Forms.CheckBox checkBoxEnableNotificationBubbles;
    }
}