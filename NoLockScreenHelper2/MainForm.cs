using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
        Timer casovatSopek = new Timer();
        Task kontrolor;
        MenuItem menuItemShow = new MenuItem("Zobrazit");
        MenuItem menuItemStop = new MenuItem("Stop");
        MenuItem menuItemStart = new MenuItem("Start");
        MenuItem menuItemAuto = new MenuItem("Auto");

        public MainForm()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            this.FormClosing += MainForm_FormClosing;
            this.Resize += MainForm_Resize;
            this.Load += MainForm_Load;

            // vymazani casovace na formulari
            toolStripStatusLabelTimer.Text = "";
            casovatSopek.Tick += CasovatSopek_Tick;

            Config = Configuration.Load();
            Config.ActivationChanged += Config_ActivationChanged;

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
                                MainForm.NI.ShowBalloonTip(2000, "Stav", "Aktivováno", System.Windows.Forms.ToolTipIcon.Info);
                        });
                    }
                    else if (!Config.Activated && prevState != Config.Activated)
                    {
                        Tools.Deactivate();
                        this.InvokeIfRequired(c =>
                        {
                            if (MainForm.Config.EnableNotificationBubbles)
                                MainForm.NI.ShowBalloonTip(2000, "Stav", "Deaktivováno", System.Windows.Forms.ToolTipIcon.Info);
                        });
                    }

                    prevState = Config.Activated;
                }
            }, TaskCreationOptions.LongRunning);

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

        private void CasovatSopek_Tick(object sender, EventArgs e)
        {
            if (stopky.Elapsed.Hours > 0)
            {
                toolStripStatusLabelTimer.Text = string.Format("{0:00}:{1:00}:{2:00}", stopky.Elapsed.TotalHours, stopky.Elapsed.Minutes, stopky.Elapsed.Seconds);
            }
            else
            {
                toolStripStatusLabelTimer.Text = string.Format("{0:00}:{1:00}", stopky.Elapsed.Minutes, stopky.Elapsed.Seconds);
            }
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"Při běhu programu nastala chyba:\n{((Exception)e.ExceptionObject).Message}\n\n{e.ExceptionObject}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                casovatSopek.Interval = 1000;
                casovatSopek.Start();
            }
            else
            {
                stopky.Stop();
                stopky.Reset();
                casovatSopek.Stop();
                toolStripStatusLabelTimer.Text = "";
            }
        }

        


        void activate()
        {
            this.InvokeIfRequired(c =>
            {
                //Tools.Activate();
                buttonStart.Enabled = false;
                buttonStop.Enabled = true;
                menuItemStart.Enabled = false;
                menuItemStop.Enabled = true;
                Icon = NI.Icon = Properties.Resources.odemceno;
                if (Config.Automat)
                {
                        toolStripStatusLabelStatus.Text = "Auto: Aktivováno";
                        statusStrip1.BackColor = Color.Orange;
                }
                else
                {
                        toolStripStatusLabelStatus.Text = "Ručně: Aktivováno";
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
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
                menuItemStart.Enabled = true;
                menuItemStop.Enabled = false;
                Icon = NI.Icon = Properties.Resources.zamceno;
                if (Config.Automat)
                {
                    toolStripStatusLabelStatus.Text = "Auto: Deaktivováno";
                    statusStrip1.BackColor = Color.Orange;
                }
                else
                {
                    toolStripStatusLabelStatus.Text = "Ručně: Deaktivováno";
                    statusStrip1.BackColor = WinRed;
                }
                BackColor = WinRed;
                Config.Save();
                startStopWatch(true);
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
            buttonStart.Enabled = true;
            menuItemStart.Enabled = true;
            buttonStop.Enabled = true;
            menuItemStop.Enabled = true;
            buttonAuto.Enabled = false;
            menuItemAuto.Enabled = false;
            Config.Automat = true;
            automat.Start();
        }

        private void pictureBoxSettings_Click(object sender, EventArgs e)
        {
            DialogResult dr = new SettingsForm().ShowDialog();
            Config.Save();
            if (Config.Automat)
                automat.InitiateNetworkChanged();
        }
    }
}
