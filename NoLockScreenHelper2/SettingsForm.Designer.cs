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
            this.checkBoxHideIfMinimalized = new System.Windows.Forms.CheckBox();
            this.checkBoxStartMinimized = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableNotificationBubbles = new System.Windows.Forms.CheckBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.objectListView1 = new BrightIdeasSoftware.DataListView();
            this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnNetworkName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnIPAddress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnGateway = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageBehavior = new System.Windows.Forms.TabPage();
            this.tabPageNetworks = new System.Windows.Forms.TabPage();
            this.splitContainerNetworks = new System.Windows.Forms.SplitContainer();
            this.tabPageOther = new System.Windows.Forms.TabPage();
            this.groupBoxLanguage = new System.Windows.Forms.GroupBox();
            this.groupBoxPortability = new System.Windows.Forms.GroupBox();
            this.tabPageTimer = new System.Windows.Forms.TabPage();
            this.groupBoxTimerEnds = new System.Windows.Forms.GroupBox();
            this.radioButtonTimerEndsStop = new System.Windows.Forms.RadioButton();
            this.radioButtonTimerEndsAuto = new System.Windows.Forms.RadioButton();
            this.groupBoxTimer = new System.Windows.Forms.GroupBox();
            this.dataListView1 = new BrightIdeasSoftware.DataListView();
            this.olvColumnTimerTimeSpan = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPageBehavior.SuspendLayout();
            this.tabPageNetworks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerNetworks)).BeginInit();
            this.splitContainerNetworks.Panel1.SuspendLayout();
            this.splitContainerNetworks.Panel2.SuspendLayout();
            this.splitContainerNetworks.SuspendLayout();
            this.tabPageOther.SuspendLayout();
            this.groupBoxLanguage.SuspendLayout();
            this.groupBoxPortability.SuspendLayout();
            this.tabPageTimer.SuspendLayout();
            this.groupBoxTimerEnds.SuspendLayout();
            this.groupBoxTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPortableMaker
            // 
            this.buttonPortableMaker.Location = new System.Drawing.Point(6, 19);
            this.buttonPortableMaker.Name = "buttonPortableMaker";
            this.buttonPortableMaker.Size = new System.Drawing.Size(124, 30);
            this.buttonPortableMaker.TabIndex = 0;
            this.buttonPortableMaker.Text = "Udělat přenositelné";
            this.buttonPortableMaker.UseVisualStyleBackColor = true;
            this.buttonPortableMaker.Click += new System.EventHandler(this.buttonPortableMaker_Click);
            // 
            // checkBoxActivateOnStartup
            // 
            this.checkBoxActivateOnStartup.AutoSize = true;
            this.checkBoxActivateOnStartup.Location = new System.Drawing.Point(6, 6);
            this.checkBoxActivateOnStartup.Name = "checkBoxActivateOnStartup";
            this.checkBoxActivateOnStartup.Size = new System.Drawing.Size(130, 17);
            this.checkBoxActivateOnStartup.TabIndex = 1;
            this.checkBoxActivateOnStartup.Text = "Aktivovat po spuštění";
            this.checkBoxActivateOnStartup.UseVisualStyleBackColor = true;
            // 
            // checkBoxRunOnLogOn
            // 
            this.checkBoxRunOnLogOn.AutoSize = true;
            this.checkBoxRunOnLogOn.Location = new System.Drawing.Point(6, 23);
            this.checkBoxRunOnLogOn.Name = "checkBoxRunOnLogOn";
            this.checkBoxRunOnLogOn.Size = new System.Drawing.Size(123, 17);
            this.checkBoxRunOnLogOn.TabIndex = 2;
            this.checkBoxRunOnLogOn.Text = "Spustit po přihlášení";
            this.checkBoxRunOnLogOn.UseVisualStyleBackColor = true;
            // 
            // checkBoxHideIfMinimalized
            // 
            this.checkBoxHideIfMinimalized.AutoSize = true;
            this.checkBoxHideIfMinimalized.Location = new System.Drawing.Point(6, 78);
            this.checkBoxHideIfMinimalized.Name = "checkBoxHideIfMinimalized";
            this.checkBoxHideIfMinimalized.Size = new System.Drawing.Size(139, 17);
            this.checkBoxHideIfMinimalized.TabIndex = 11;
            this.checkBoxHideIfMinimalized.Text = "Schovat při minimalizaci";
            this.checkBoxHideIfMinimalized.UseVisualStyleBackColor = true;
            // 
            // checkBoxStartMinimized
            // 
            this.checkBoxStartMinimized.AutoSize = true;
            this.checkBoxStartMinimized.Location = new System.Drawing.Point(6, 59);
            this.checkBoxStartMinimized.Name = "checkBoxStartMinimized";
            this.checkBoxStartMinimized.Size = new System.Drawing.Size(132, 17);
            this.checkBoxStartMinimized.TabIndex = 10;
            this.checkBoxStartMinimized.Text = "Spustit minimalizovaně";
            this.checkBoxStartMinimized.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableNotificationBubbles
            // 
            this.checkBoxEnableNotificationBubbles.AutoSize = true;
            this.checkBoxEnableNotificationBubbles.Location = new System.Drawing.Point(6, 41);
            this.checkBoxEnableNotificationBubbles.Name = "checkBoxEnableNotificationBubbles";
            this.checkBoxEnableNotificationBubbles.Size = new System.Drawing.Size(147, 17);
            this.checkBoxEnableNotificationBubbles.TabIndex = 9;
            this.checkBoxEnableNotificationBubbles.Text = "Povolit informační bubliny";
            this.checkBoxEnableNotificationBubbles.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(4, 10);
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
            this.buttonRemove.Location = new System.Drawing.Point(85, 10);
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
            this.objectListView1.CellEditUseWholeCell = false;
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.olvColumnNetworkName,
            this.olvColumnIPAddress,
            this.olvColumnGateway});
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.DataSource = null;
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.HideSelection = false;
            this.objectListView1.Location = new System.Drawing.Point(0, 0);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(396, 242);
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
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageBehavior);
            this.tabControlMain.Controls.Add(this.tabPageNetworks);
            this.tabControlMain.Controls.Add(this.tabPageOther);
            this.tabControlMain.Controls.Add(this.tabPageTimer);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(410, 314);
            this.tabControlMain.TabIndex = 9;
            // 
            // tabPageBehavior
            // 
            this.tabPageBehavior.Controls.Add(this.checkBoxHideIfMinimalized);
            this.tabPageBehavior.Controls.Add(this.checkBoxStartMinimized);
            this.tabPageBehavior.Controls.Add(this.checkBoxActivateOnStartup);
            this.tabPageBehavior.Controls.Add(this.checkBoxEnableNotificationBubbles);
            this.tabPageBehavior.Controls.Add(this.checkBoxRunOnLogOn);
            this.tabPageBehavior.Location = new System.Drawing.Point(4, 22);
            this.tabPageBehavior.Name = "tabPageBehavior";
            this.tabPageBehavior.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBehavior.Size = new System.Drawing.Size(402, 288);
            this.tabPageBehavior.TabIndex = 0;
            this.tabPageBehavior.Text = "Chování";
            this.tabPageBehavior.UseVisualStyleBackColor = true;
            // 
            // tabPageNetworks
            // 
            this.tabPageNetworks.Controls.Add(this.splitContainerNetworks);
            this.tabPageNetworks.Location = new System.Drawing.Point(4, 22);
            this.tabPageNetworks.Name = "tabPageNetworks";
            this.tabPageNetworks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNetworks.Size = new System.Drawing.Size(402, 288);
            this.tabPageNetworks.TabIndex = 1;
            this.tabPageNetworks.Text = "Sítě";
            this.tabPageNetworks.UseVisualStyleBackColor = true;
            // 
            // splitContainerNetworks
            // 
            this.splitContainerNetworks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerNetworks.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerNetworks.IsSplitterFixed = true;
            this.splitContainerNetworks.Location = new System.Drawing.Point(3, 3);
            this.splitContainerNetworks.Name = "splitContainerNetworks";
            this.splitContainerNetworks.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerNetworks.Panel1
            // 
            this.splitContainerNetworks.Panel1.Controls.Add(this.objectListView1);
            // 
            // splitContainerNetworks.Panel2
            // 
            this.splitContainerNetworks.Panel2.Controls.Add(this.buttonRemove);
            this.splitContainerNetworks.Panel2.Controls.Add(this.buttonAdd);
            this.splitContainerNetworks.Size = new System.Drawing.Size(396, 282);
            this.splitContainerNetworks.SplitterDistance = 242;
            this.splitContainerNetworks.SplitterWidth = 1;
            this.splitContainerNetworks.TabIndex = 10;
            this.splitContainerNetworks.TabStop = false;
            // 
            // tabPageOther
            // 
            this.tabPageOther.Controls.Add(this.groupBoxLanguage);
            this.tabPageOther.Controls.Add(this.groupBoxPortability);
            this.tabPageOther.Location = new System.Drawing.Point(4, 22);
            this.tabPageOther.Name = "tabPageOther";
            this.tabPageOther.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOther.Size = new System.Drawing.Size(402, 288);
            this.tabPageOther.TabIndex = 2;
            this.tabPageOther.Text = "Ostatní";
            this.tabPageOther.UseVisualStyleBackColor = true;
            // 
            // groupBoxLanguage
            // 
            this.groupBoxLanguage.Controls.Add(this.comboBoxLanguage);
            this.groupBoxLanguage.Location = new System.Drawing.Point(163, 6);
            this.groupBoxLanguage.Name = "groupBoxLanguage";
            this.groupBoxLanguage.Size = new System.Drawing.Size(153, 70);
            this.groupBoxLanguage.TabIndex = 2;
            this.groupBoxLanguage.TabStop = false;
            this.groupBoxLanguage.Text = "Jazyk";
            // 
            // groupBoxPortability
            // 
            this.groupBoxPortability.Controls.Add(this.buttonPortableMaker);
            this.groupBoxPortability.Location = new System.Drawing.Point(8, 6);
            this.groupBoxPortability.Name = "groupBoxPortability";
            this.groupBoxPortability.Size = new System.Drawing.Size(149, 70);
            this.groupBoxPortability.TabIndex = 1;
            this.groupBoxPortability.TabStop = false;
            this.groupBoxPortability.Text = "Portability";
            // 
            // tabPageTimer
            // 
            this.tabPageTimer.Controls.Add(this.groupBoxTimerEnds);
            this.tabPageTimer.Controls.Add(this.groupBoxTimer);
            this.tabPageTimer.Location = new System.Drawing.Point(4, 22);
            this.tabPageTimer.Name = "tabPageTimer";
            this.tabPageTimer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTimer.Size = new System.Drawing.Size(402, 288);
            this.tabPageTimer.TabIndex = 3;
            this.tabPageTimer.Text = "Časovač";
            this.tabPageTimer.UseVisualStyleBackColor = true;
            // 
            // groupBoxTimerEnds
            // 
            this.groupBoxTimerEnds.Controls.Add(this.radioButtonTimerEndsStop);
            this.groupBoxTimerEnds.Controls.Add(this.radioButtonTimerEndsAuto);
            this.groupBoxTimerEnds.Location = new System.Drawing.Point(8, 6);
            this.groupBoxTimerEnds.Name = "groupBoxTimerEnds";
            this.groupBoxTimerEnds.Size = new System.Drawing.Size(386, 82);
            this.groupBoxTimerEnds.TabIndex = 13;
            this.groupBoxTimerEnds.TabStop = false;
            this.groupBoxTimerEnds.Text = "When timer ends";
            // 
            // radioButtonTimerEndsStop
            // 
            this.radioButtonTimerEndsStop.AutoSize = true;
            this.radioButtonTimerEndsStop.Location = new System.Drawing.Point(7, 44);
            this.radioButtonTimerEndsStop.Name = "radioButtonTimerEndsStop";
            this.radioButtonTimerEndsStop.Size = new System.Drawing.Size(108, 17);
            this.radioButtonTimerEndsStop.TabIndex = 1;
            this.radioButtonTimerEndsStop.TabStop = true;
            this.radioButtonTimerEndsStop.Text = "přepnout na Stop";
            this.radioButtonTimerEndsStop.UseVisualStyleBackColor = true;
            // 
            // radioButtonTimerEndsAuto
            // 
            this.radioButtonTimerEndsAuto.AutoSize = true;
            this.radioButtonTimerEndsAuto.Location = new System.Drawing.Point(7, 20);
            this.radioButtonTimerEndsAuto.Name = "radioButtonTimerEndsAuto";
            this.radioButtonTimerEndsAuto.Size = new System.Drawing.Size(108, 17);
            this.radioButtonTimerEndsAuto.TabIndex = 0;
            this.radioButtonTimerEndsAuto.TabStop = true;
            this.radioButtonTimerEndsAuto.Text = "přeonout na Auto";
            this.radioButtonTimerEndsAuto.UseVisualStyleBackColor = true;
            // 
            // groupBoxTimer
            // 
            this.groupBoxTimer.Controls.Add(this.dataListView1);
            this.groupBoxTimer.Location = new System.Drawing.Point(8, 94);
            this.groupBoxTimer.Name = "groupBoxTimer";
            this.groupBoxTimer.Size = new System.Drawing.Size(386, 188);
            this.groupBoxTimer.TabIndex = 4;
            this.groupBoxTimer.TabStop = false;
            this.groupBoxTimer.Text = "Časovač";
            // 
            // dataListView1
            // 
            this.dataListView1.AllColumns.Add(this.olvColumnTimerTimeSpan);
            this.dataListView1.CellEditUseWholeCell = false;
            this.dataListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnTimerTimeSpan});
            this.dataListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataListView1.DataSource = null;
            this.dataListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataListView1.HideSelection = false;
            this.dataListView1.Location = new System.Drawing.Point(3, 16);
            this.dataListView1.Name = "dataListView1";
            this.dataListView1.Size = new System.Drawing.Size(380, 169);
            this.dataListView1.TabIndex = 0;
            this.dataListView1.UseCompatibleStateImageBehavior = false;
            this.dataListView1.View = System.Windows.Forms.View.Details;
            // 
            // olvColumnTimerTimeSpan
            // 
            this.olvColumnTimerTimeSpan.AspectName = "TimeSpan";
            this.olvColumnTimerTimeSpan.IsEditable = false;
            this.olvColumnTimerTimeSpan.Text = "Čas";
            this.olvColumnTimerTimeSpan.Width = 344;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(6, 25);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(141, 21);
            this.comboBoxLanguage.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(410, 314);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nastavení";
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageBehavior.ResumeLayout(false);
            this.tabPageBehavior.PerformLayout();
            this.tabPageNetworks.ResumeLayout(false);
            this.splitContainerNetworks.Panel1.ResumeLayout(false);
            this.splitContainerNetworks.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerNetworks)).EndInit();
            this.splitContainerNetworks.ResumeLayout(false);
            this.tabPageOther.ResumeLayout(false);
            this.groupBoxLanguage.ResumeLayout(false);
            this.groupBoxPortability.ResumeLayout(false);
            this.tabPageTimer.ResumeLayout(false);
            this.groupBoxTimerEnds.ResumeLayout(false);
            this.groupBoxTimerEnds.PerformLayout();
            this.groupBoxTimer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPortableMaker;
        private System.Windows.Forms.CheckBox checkBoxActivateOnStartup;
        private System.Windows.Forms.CheckBox checkBoxRunOnLogOn;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private BrightIdeasSoftware.DataListView objectListView1;
        private BrightIdeasSoftware.OLVColumn olvColumnName;
        private BrightIdeasSoftware.OLVColumn olvColumnNetworkName;
        private BrightIdeasSoftware.OLVColumn olvColumnIPAddress;
        private BrightIdeasSoftware.OLVColumn olvColumnGateway;
        private System.Windows.Forms.CheckBox checkBoxEnableNotificationBubbles;
        private System.Windows.Forms.CheckBox checkBoxHideIfMinimalized;
        private System.Windows.Forms.CheckBox checkBoxStartMinimized;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageBehavior;
        private System.Windows.Forms.TabPage tabPageNetworks;
        private System.Windows.Forms.TabPage tabPageOther;
        private System.Windows.Forms.SplitContainer splitContainerNetworks;
        private System.Windows.Forms.GroupBox groupBoxPortability;
        private System.Windows.Forms.TabPage tabPageTimer;
        private System.Windows.Forms.GroupBox groupBoxTimerEnds;
        private System.Windows.Forms.RadioButton radioButtonTimerEndsStop;
        private System.Windows.Forms.RadioButton radioButtonTimerEndsAuto;
        private System.Windows.Forms.GroupBox groupBoxTimer;
        private BrightIdeasSoftware.DataListView dataListView1;
        private BrightIdeasSoftware.OLVColumn olvColumnTimerTimeSpan;
        private System.Windows.Forms.GroupBox groupBoxLanguage;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
    }
}