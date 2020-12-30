using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoLockScreenHelper2
{
    public partial class SettingsForm : Form
    {
        Configuration _config;
        public SettingsForm()
        {
            InitializeComponent();

            _config = MainForm.Config;

            // detekce přenosné verze
            if (Configuration.IsPortable)
                buttonPortableMaker.Text = "Zrušit přenositelnost";
            else
                buttonPortableMaker.Text = "Udělat přenositelné";

            checkBoxEnableNotificationBubbles.Checked = MainForm.Config.EnableNotificationBubbles;
            checkBoxActivateOnStartup.Checked = MainForm.Config.ActivateOnStartup;
            checkBoxStartMinimized.Checked = MainForm.Config.StartMinimalized;
            checkBoxHideIfMinimalized.Checked = MainForm.Config.HideToTrayIfMinimized;
            checkBoxRunOnLogOn.Checked = Tools.GetLaunchApplicationAtStartupUserScope("NLSH");

            this.checkBoxRunOnLogOn.CheckedChanged += new System.EventHandler(this.checkBoxRunOnLogOn_CheckedChanged);
            this.checkBoxEnableNotificationBubbles.CheckedChanged += new System.EventHandler(this.checkBoxEnableNotificationBubbles_CheckedChanged);
            this.checkBoxStartMinimized.CheckedChanged += new System.EventHandler(this.checkBoxStartMinimized_CheckedChanged);
            this.checkBoxHideIfMinimalized.CheckedChanged += new System.EventHandler(this.checkBoxHideIfMinimalized_CheckedChanged);
            this.checkBoxActivateOnStartup.CheckedChanged += new System.EventHandler(this.checkBoxActivateOnStartup_CheckedChanged);

            if (MainForm.Config.TimerEndsActivity == TimerEndsActivity.Auto)
                radioButtonTimerEndsAuto.Checked = true;
            else
                radioButtonTimerEndsStop.Checked = true;

            initOLV();

            radioButtonTimerEndsAuto.CheckedChanged += (s, e) => { MainForm.Config.TimerEndsActivity = TimerEndsActivity.Auto; MainForm.Config.Save(); };
            radioButtonTimerEndsStop.CheckedChanged += (s, e) => { MainForm.Config.TimerEndsActivity = TimerEndsActivity.Stop; MainForm.Config.Save(); };

            
        }

        private void checkBoxActivateOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.Config.ActivateOnStartup = checkBoxActivateOnStartup.Checked;
            MainForm.Config.Save();
        }

        private void checkBoxRunOnLogOn_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRunOnLogOn.Checked)
                Tools.LaunchApplicationAtStartupUserScope("NLSH", Application.ExecutablePath);
            else
                Tools.LaunchApplicationAtStartupUserScope("NLSH", Application.ExecutablePath, true);
        }

        private void checkBoxEnableNotificationBubbles_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.Config.EnableNotificationBubbles = checkBoxEnableNotificationBubbles.Checked;
            MainForm.Config.Save();
        }

        private void checkBoxStartMinimized_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.Config.StartMinimalized = checkBoxStartMinimized.Checked;
            MainForm.Config.Save();
        }

        private void checkBoxHideIfMinimalized_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.Config.HideToTrayIfMinimized = checkBoxHideIfMinimalized.Checked;
            MainForm.Config.Save();
        }

        private void buttonPortableMaker_Click(object sender, EventArgs e)
        {
            Configuration.SwitchPortability();
            if (Configuration.IsPortable)
                buttonPortableMaker.Text = "Zrušit přenositelnost";
            else
                buttonPortableMaker.Text = "Udělat přenositelné";
        }


        void initOLV()
        {
            objectListView1.ShowGroups = false;
            objectListView1.AutoGenerateColumns = false;
            objectListView1.DataSource = MainForm.Config.Networks;
            objectListView1.FormatRow += (sender, e) =>
            {
                if (MainForm.Config.Automat)
                {
                    Network n = (Network)e.Model;
                    if (n == Automat.LastMatchedNetwork)
                    {
                        e.Item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(255)))), ((int)(((byte)(208)))));
                    }
                }
            };
            objectListView1.DoubleClick += (sender, e) =>
                {
                    if (objectListView1.SelectedObject != null)
                    {
                        var editor = new NetworkEditorForm(NetworkEditorForm.Mode.Edit);
                        editor.Network = MainForm.Config.Networks[objectListView1.SelectedIndex];
                        DialogResult dr = editor.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            MainForm.Config.Networks[objectListView1.SelectedIndex] = editor.Network;
                            //MainForm.Config.Networks.Add(editor.Network);
                            objectListView1.BuildList();
                            MainForm.Config.Save();
                        }
                    }
                };
            objectListView1.AllowColumnReorder = true;
            objectListView1.FullRowSelect = true;
            objectListView1.ShowCommandMenuOnRightClick = true;
            objectListView1.UseFilterIndicator = true;
            objectListView1.AddDecoration(new EditingCellBorderDecoration(true));
            objectListView1.UseHotItem = true;
            objectListView1.UseTranslucentHotItem = true;
            objectListView1.UseTranslucentSelection = true;
            objectListView1.RebuildColumns();



            dataListView1.ShowGroups = false;
            dataListView1.AutoGenerateColumns = false;
            dataListView1.UseHotItem = false;
            dataListView1.UseTranslucentHotItem = false;
            dataListView1.UseTranslucentSelection = false;

            dataListView1.DataSource = MainForm.Config.TimeSpans;
            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.Add("Přidat").Click += (s, e) => {
                TimeSpanPicker tpp = new TimeSpanPicker();
                if (tpp.ShowDialog(this) == DialogResult.OK)
                {
                    MainForm.Config.TimeSpans.Add(new TimerTimeSpan(tpp.Timespan));
                    dataListView1.BuildList();
                }
            };
            cms.Items.Add("Odebrat").Click += (s, e) => {

                MainForm.Config.TimeSpans.Remove((TimerTimeSpan)dataListView1.MouseMoveHitTest.Item.RowObject);
                dataListView1.BuildList();
            };
            cms.Items.Add("Upravit").Click += (s, e) => {
                int index = dataListView1.MouseMoveHitTest.RowIndex;
                var tss = _config.TimeSpans[index].TimeSpan;
                TimeSpanPicker tpp = new TimeSpanPicker(tss);
                if (tpp.ShowDialog(this) == DialogResult.OK)
                {
                    _config.TimeSpans[index].TimeSpan = tpp.Timespan;
                    dataListView1.BuildList();
                }
            };
            dataListView1.ContextMenuStrip = cms;


        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach(Network obj in objectListView1.SelectedObjects)
            {
                MainForm.Config.Networks.Remove(obj);
            }
            objectListView1.BuildList();
            MainForm.Config.Save();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var editor = new NetworkEditorForm(NetworkEditorForm.Mode.New);
            DialogResult dr = editor.ShowDialog();
            if (dr == DialogResult.OK)
            {
                MainForm.Config.Networks.Add(editor.Network);
                objectListView1.BuildList();
                MainForm.Config.Save();
            }
        }


    }
}
