﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoLockScreenHelper2
{

    public partial class MainForm : Form
    {
        internal static Configuration Config { get; set; }
        internal static NotifyIcon NI = new NotifyIcon();
        Automat automat = new Automat();
        private readonly Color WinGreen = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(255)))), ((int)(((byte)(134)))));
        private readonly Color WinRed = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
        Stopwatch stopky = new Stopwatch();
        Timer casovatStopek = new Timer();
        Timer casovacVypnuti = new Timer();
        DateTime _casovacVypnutiStart = new DateTime();
        Task kontrolor;
        MenuItem menuItemShow = new MenuItem(NoLockScreenHelper2.Resources.Lng.Show);
        MenuItem menuItemStop = new MenuItem(NoLockScreenHelper2.Resources.Lng.Stop);
        MenuItem menuItemStart = new MenuItem(NoLockScreenHelper2.Resources.Lng.Start);
        MenuItem menuItemAuto = new MenuItem(NoLockScreenHelper2.Resources.Lng.Auto);

        public MainForm()
        {
            InitializeComponent();
            Config = Configuration.Load();
            Config.ActivationChanged += Config_ActivationChanged;
            Language.ChangeLanguage(Config.Language);
            UpdateUI();
            
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            this.FormClosing += MainForm_FormClosing;
            this.Resize += MainForm_Resize;
            this.Load += MainForm_Load;

            // vymazani casovace na formulari
            toolStripStatusLabelTimer.Text = "";
            casovatStopek.Tick += CasovatStopek_Tick;

            NI.Visible = true;
            NI.Icon = Properties.Resources.zamceno;
            NI.MouseDoubleClick += NI_MouseDoubleClick;
            NI.ContextMenu = new ContextMenu();
            menuItemShow.Click += MenuItemShow_Click;
            menuItemStart.Click += buttonStart_Click;
            menuItemStop.Click += buttonStop_Click;
            menuItemAuto.Click += buttonAuto_Click;
            NI.ContextMenu.MenuItems.Add(menuItemShow);
            NI.ContextMenu.MenuItems.Add(menuItemStart);
            NI.ContextMenu.MenuItems.Add(menuItemStop);
            NI.ContextMenu.MenuItems.Add(menuItemAuto);

            if (!Config.Automat && Config.ActivateOnStartup)
                activate();
            else if (!Config.Automat && !Config.ActivateOnStartup)
                deactivate();

            if (Config.Automat)
            {
                automat.Start();
                buttonAuto.Enabled = false;
                menuItemAuto.Enabled = false;
            }

            if (Config.StartMinimalized)
                this.WindowState = FormWindowState.Minimized;


            kontrolor = Task.Factory.StartNew(() =>
            {
                bool prevState = false;
                while (true)
                {
                    System.Threading.Thread.Sleep(3000);
                    if (Config.Activated && prevState != Config.Activated)
                    {
                        Tools.Activate();
                        this.InvokeIfRequired(c =>
                        {
                            if (MainForm.Config.EnableNotificationBubbles)
                                MainForm.NI.ShowBalloonTip(2000, NoLockScreenHelper2.Resources.Lng.State, NoLockScreenHelper2.Resources.Lng.Activated, System.Windows.Forms.ToolTipIcon.Info);
                        });
                    }
                    else if (!Config.Activated && prevState != Config.Activated)
                    {
                        Tools.Deactivate();
                        this.InvokeIfRequired(c =>
                        {
                            if (MainForm.Config.EnableNotificationBubbles)
                                MainForm.NI.ShowBalloonTip(2000, NoLockScreenHelper2.Resources.Lng.State, NoLockScreenHelper2.Properties.Resources.Deactivated, System.Windows.Forms.ToolTipIcon.Info);
                        });
                    }

                    prevState = Config.Activated;
                }
            }, TaskCreationOptions.LongRunning);

            splitButtonStart.Menu = new ContextMenuStrip();
            _refreshStartButtonTimer();
            casovacVypnuti.Tick += (s, e) => {

                casovacVypnuti.Stop();
                if (Config.TimerEndsActivity == TimerEndsActivity.Auto)
                {
                    splitButtonStart.Enabled = true;
                    menuItemStart.Enabled = true;
                    buttonStop.Enabled = true;
                    menuItemStop.Enabled = true;
                    buttonAuto.Enabled = false;
                    menuItemAuto.Enabled = false;
                    Config.Automat = true;
                    automat.Start();
                }
                else
                {
                    deactivate();
                    buttonAuto.Enabled = true;
                    menuItemAuto.Enabled = true;
                    Config.Automat = false;
                    automat.Stop();
                    Config.Activated = false;
                }
            };
            




        }

        void _refreshStartButtonTimer()
        {
            splitButtonStart.Menu.Items.Clear();
            foreach (var span in Config.TimeSpans)
            {
                splitButtonStart.Menu.Items.Add(new ToolStripMenuItem(span.TimeSpan.ToString(), null, splitButtonStartMenuItemClik_Click));
            }

        }

        internal void UpdateUI()
        {
            buttonAuto.Text = Resources.Lng.Auto;
            splitButtonStart.Text = Resources.Lng.Start;
            buttonStop.Text = Resources.Lng.Stop;
            toolStripStatusLabelStatus.Text = string.Empty;
        }

        private void splitButtonStartMenuItemClik_Click(object sender, EventArgs e)
        {

            activate();
            buttonAuto.Enabled = true;
            menuItemAuto.Enabled = true;
            Config.Automat = false;
            automat.Stop();
            Config.Activated = true;

            TimeSpan ts = TimeSpan.Parse((sender as ToolStripMenuItem).Text);

            casovacVypnuti.Interval = Convert.ToInt32(ts.TotalMilliseconds);
            casovacVypnuti.Start();
            _casovacVypnutiStart = DateTime.Now;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Config.HideToTrayIfMinimized && WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void MenuItemShow_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void NI_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && Config.HideToTrayIfMinimized)
            {
                Hide();
            }
        }

        private void CasovatStopek_Tick(object sender, EventArgs e)
        {
            if (stopky.Elapsed.Hours > 0)
            {
                toolStripStatusLabelTimer.Text = string.Format("{0:00}:{1:00}:{2:00}", stopky.Elapsed.TotalHours, stopky.Elapsed.Minutes, stopky.Elapsed.Seconds);
            }
            else
            {
                toolStripStatusLabelTimer.Text = string.Format("{0:00}:{1:00}", stopky.Elapsed.Minutes, stopky.Elapsed.Seconds);
            }
            if (casovacVypnuti.Enabled)
            {
                TimeSpan ubehnutyCas = DateTime.Now - _casovacVypnutiStart;
                TimeSpan zbyva = TimeSpan.FromMilliseconds((ubehnutyCas.TotalMilliseconds - casovacVypnuti.Interval) * -1);
                if (zbyva.Hours > 0)
                    toolStripStatusLabelTimer.Text += string.Format("/-{0:00}:{1:00}:{2:00}", zbyva.TotalHours, zbyva.Minutes, zbyva.Seconds);
                else
                    toolStripStatusLabelTimer.Text += string.Format("/-{0:00}:{1:00}", zbyva.Minutes, zbyva.Seconds);

            }

        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(Resources.Lng.ExceptionDuringRunningProgram + $":\n{((Exception)e.ExceptionObject).Message}\n\n{e.ExceptionObject}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NI.Visible = false;
            NI.Dispose();
        }

        private void Config_ActivationChanged(object sender, EventArgs e)
        {
            if (Config.Activated)
                activate();
            else
                deactivate();
        }

        void startStopWatch(bool orNot = false)
        {
            if (!orNot)
            {
                stopky.Start();
                casovatStopek.Interval = 500;
                casovatStopek.Start();
            }
            else
            {
                stopky.Stop();
                stopky.Reset();
                casovatStopek.Stop();
                toolStripStatusLabelTimer.Text = "";
            }
        }

        void activate()
        {
            this.InvokeIfRequired(c =>
            {
                //Tools.Activate();
                //if (!Config.Automat)
                //    splitButtonStart.Enabled = false;
                splitButtonStart.Enabled = Config.Automat;
                buttonStop.Enabled = true;
                menuItemStart.Enabled = false;
                menuItemStop.Enabled = true;
                Icon = NI.Icon = Properties.Resources.odemceno;
                if (Config.Automat)
                {
                        toolStripStatusLabelStatus.Text = NoLockScreenHelper2.Resources.Lng.StatusActivatedAuto;
                        statusStrip1.BackColor = Color.Orange;
                }
                else
                {
                        toolStripStatusLabelStatus.Text = NoLockScreenHelper2.Resources.Lng.StatusActivatedManual;
                        statusStrip1.BackColor = WinGreen;
                }
                BackColor = WinGreen;
                Config.Save();
                startStopWatch();
                //MainForm.NI.ShowBalloonTip(2000, "Stav", "Aktivováno", System.Windows.Forms.ToolTipIcon.Info);
            });


        }

        void deactivate()
        {
            this.InvokeIfRequired(c =>
            {
                //Tools.Deactivate();
                splitButtonStart.Enabled = true;
                buttonStop.Enabled = false;
                menuItemStart.Enabled = true;
                menuItemStop.Enabled = false;
                Icon = NI.Icon = Properties.Resources.zamceno;
                if (Config.Automat)
                {
                    toolStripStatusLabelStatus.Text = NoLockScreenHelper2.Resources.Lng.StatusDeactivatedAuto;
                    statusStrip1.BackColor = Color.Orange;
                }
                else
                {
                    toolStripStatusLabelStatus.Text = NoLockScreenHelper2.Resources.Lng.StatusDeactivatedManual;
                    statusStrip1.BackColor = WinRed;
                }
                BackColor = WinRed;
                Config.Save();
                startStopWatch(true);
                casovacVypnuti.Stop();
                //MainForm.NI.ShowBalloonTip(2000, "Stav", "Deaktivováno", System.Windows.Forms.ToolTipIcon.Info);
            });
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            activate();
            buttonAuto.Enabled = true;
            menuItemAuto.Enabled = true;
            Config.Automat = false;
            automat.Stop();
            Config.Activated = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            deactivate();
            buttonAuto.Enabled = true;
            menuItemAuto.Enabled = true;
            Config.Automat = false;
            automat.Stop();
            Config.Activated = false;
        }

        private void buttonAuto_Click(object sender, EventArgs e)
        {
            //splitButtonStart.Enabled = true;
            menuItemStart.Enabled = true;
            buttonStop.Enabled = true;
            menuItemStop.Enabled = true;
            buttonAuto.Enabled = false;
            menuItemAuto.Enabled = false;
            Config.Automat = true;
            casovacVypnuti.Enabled = false;
            automat.Start();
        }

        private void pictureBoxSettings_Click(object sender, EventArgs e)
        {
            DialogResult dr = new SettingsForm().ShowDialog();
            Config.Save();
            if (Config.Automat)
                automat.InitiateNetworkChanged();
            _refreshStartButtonTimer();
            UpdateUI();
        }
        
        private void splitButtonStart_Click(object sender, EventArgs e)
        {
            activate();
            buttonAuto.Enabled = true;
            menuItemAuto.Enabled = true;
            Config.Automat = false;
            automat.Stop();
            Config.Activated = true;
        }
    }
}
