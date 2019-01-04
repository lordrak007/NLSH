﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoLockScreenHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //App.Current.Startup += new StartupEventHandler((sender, e) =>
            //{
            //    SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
            //});
            //App.Current.Exit += new ExitEventHandler((sender, e) =>
            //{
            //    SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
            //});

            switchIt();
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        bool IsStarted = false;

        private void btStartStop_Click(object sender, RoutedEventArgs e)
        {
            switchIt();
        }

        void switchIt()
        {
            if (IsStarted)
            {
                this.btStartStop.Background = Brushes.Red;
                this.btStartStop.Content = "Start";
                SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
                IsStarted = false;

                Uri iconUri = new Uri("pack://application:,,,/Resources/zamceno.ico", UriKind.RelativeOrAbsolute);
                this.Icon = BitmapFrame.Create(iconUri);
            }
            else
            {
                this.btStartStop.Background = Brushes.LightGreen;
                this.btStartStop.Content = "Stop";
                SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
                IsStarted = true;

                Uri iconUri = new Uri("pack://application:,,,/Resources/odemceno.ico", UriKind.RelativeOrAbsolute);
                this.Icon = BitmapFrame.Create(iconUri);
            }
        }



        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }
    }
}
