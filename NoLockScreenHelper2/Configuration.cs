﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace NoLockScreenHelper2
{
    [Serializable]
    public class Configuration
    {
        public Configuration()
        {
            Networks = new Networks();
            RunOnLogOn = false;
            Automat = false;
            Activated = false;
            EnableNotificationBubbles = true;
            HideToTrayIfMinimized = false;
            StartMinimalized = false;
            
        }
        static readonly string ConfigurationsPath = "Settings.xml";
        [XmlAttribute]
        public bool Automat { get; set; }

        public event EventHandler ActivationChanged;
        private void RaiseActivationChanged()
        {
            ActivationChanged?.Invoke(this, new EventArgs());
        }
        private bool _activated = false;
        [XmlIgnore]
        public bool Activated { get { return _activated; } set
            {
                _activated = value;
                RaiseActivationChanged();
            }
        }
        [XmlAttribute]
        public bool ActivateOnStartup { get; set; }
        [XmlIgnore]
        public bool RunOnLogOn { get; set; }
        [XmlAttribute]
        public bool EnableNotificationBubbles { get; set; }
        [XmlAttribute]
        public bool HideToTrayIfMinimized { get; set; }
        [XmlAttribute]
        public bool StartMinimalized { get; set; }

        public Networks Networks {get;set;}

        public TimerTimeSpans TimeSpans { get; set; } = new TimerTimeSpans();

        /// <summary>
        /// What to do when start time ends
        /// </summary>
        public TimerEndsActivity TimerEndsActivity { get; set; } = TimerEndsActivity.Stop;

        // seznam GW a dle typu

        public static Configuration Load()
        {
            string soubor = GetConfigFile();
            if (!System.IO.File.Exists(soubor))
                (new Configuration()).Save();

            try
            {
                var cfg = LTools.XmlUtility.DeserializeFromFile<Configuration>(soubor);
                if (cfg.TimeSpans.Count == 0)
                {
                    cfg.TimeSpans.Add(new TimerTimeSpan(5));
                    cfg.TimeSpans.Add(new TimerTimeSpan(10));
                    cfg.TimeSpans.Add(new TimerTimeSpan(15));
                    cfg.TimeSpans.Add(new TimerTimeSpan(30));
                    cfg.TimeSpans.Add(new TimerTimeSpan(60));
                    cfg.TimeSpans.Add(new TimerTimeSpan(180));
                }
                return cfg;
            }
            catch (Exception ex)
            {
                throw new Exception("Nepodařilo se načíst soubor Settings.xml.\nChyba: " + ex.Message);
            }

        }

        public void Save()
        {
            string soubor = GetConfigFile();
            try
            {
                LTools.XmlUtility.SerializeToFile<Configuration>(this, soubor);
            }
            catch (Exception ex)
            {
                throw new Exception("Nepodařilo se uložit soubor Settings.xml.\nChyba: " + ex.Message);
            }
        }

        internal static string GetConfigFile()
        {
            string soubor = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, ConfigurationsPath);
            if (System.IO.File.Exists(soubor))
            {
                return soubor;
            }
            else
            {
                soubor = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, ConfigurationsPath);
                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(soubor)))
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(soubor));
                return soubor;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        internal static bool IsPortable
        {
            get { return System.Windows.Forms.Application.StartupPath == System.IO.Path.GetDirectoryName(GetConfigFile()); }
        }

        internal static void SwitchPortability()
        {
            FileInfo fi = new FileInfo(GetConfigFile());
            if (IsPortable)
            {
                string appdata = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, ConfigurationsPath);
                if (File.Exists(appdata))
                    File.Delete(appdata);
                if (!Directory.Exists(Path.GetDirectoryName(appdata)))
                    Directory.CreateDirectory(Path.GetDirectoryName(appdata));
                fi.MoveTo(appdata);
            }
            else
            {
                string local = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, ConfigurationsPath);
                if (File.Exists(local))
                    File.Delete(local);
                fi.MoveTo(local);
            }
        }

        [XmlAttribute]
        public string Language { get; set; } = string.Empty;

    }
    [Serializable]
    public class Networks : List<Network>
    {

    }
    [Serializable]
    public class Network
    {
        public string Name { get; set; }
        public DetectionType DetectionType { get; set; }

        [XmlIgnore]
        public IPAddress Gateway { get; set; }
        /// <summary>
        /// Only for serialization purposes. Converts IPAddress property to string and string to IPAddress.
        /// </summary>
        [XmlElement("Gateway")]
        public string GatewayForXml
        {
            get { return Gateway?.ToString(); }
            set
            {
                Gateway = string.IsNullOrEmpty(value) ? null : System.Net.IPAddress.Parse(value);
            }
        }
        [XmlIgnore]
        public IPAddress IPAddress { get; set; }
        /// <summary>
        /// Only for serialization purposes. Converts IPAddress property to string and string to IPAddress.
        /// </summary>
        [XmlElement("IPAddress")]
        public string IPAddressForXml
        {
            get { return IPAddress?.ToString(); }
            set
            {
                IPAddress = string.IsNullOrEmpty(value) ? null : System.Net.IPAddress.Parse(value);
            }
        }
        public string NetworkName { get; set; }

        //public Using Using { get; set; }

    }

    [Serializable]
    [Flags]
    public enum DetectionType
    {
        Gateway = 1,
        IPAddress = 2,
        NetworkName = 4,
        All = Gateway | IPAddress| NetworkName
    }

    public enum TimerEndsActivity
    {
        Stop = 0,
        Auto = 1
    }
    //[Serializable]
    //[Flags]
    //public enum Using
    //{
    //    IPAddress = 1,
    //    Gateway = 2,
    //    All = IPAddress | Gateway
    //}
    [Serializable]
    public class TimerTimeSpan
    {
        public TimerTimeSpan()
        { }
        public TimerTimeSpan(TimeSpan timeSpan)
        {
            TimeSpan = timeSpan;
        }

        public TimerTimeSpan(int minutes)
        {
            TimeSpan = new TimeSpan(0, minutes, 0);
        }
        [XmlIgnore]
        public TimeSpan TimeSpan { get; set; }

        [XmlAttribute("TimeSpan")]
        public string TimeSpanForXml
        {
            get { return TimeSpan.ToString(); }
            set
            {
                TimeSpan = string.IsNullOrEmpty(value) ? new TimeSpan() : TimeSpan.Parse(value);
            }
        }
    }

    [Serializable]
    public class TimerTimeSpans : List<TimerTimeSpan>
    {

    }
}
