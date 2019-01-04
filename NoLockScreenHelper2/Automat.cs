using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace NoLockScreenHelper2
{
    public class Automat
    {
        public static Network LastMatchedNetwork;

        public void Start()
        {
            NetworkChange.NetworkAvailabilityChanged += NetworkAvailabilityChanged;
            NetworkChange.NetworkAddressChanged += NetworkAddressChanged;
            NetworkAddressChanged(null, null);
        }

        public void Stop()
        {
            NetworkChange.NetworkAvailabilityChanged -= NetworkAvailabilityChanged;
            NetworkChange.NetworkAddressChanged -= NetworkAddressChanged;
        }

        public void InitiateNetworkChanged()
        {
            NetworkAddressChanged(null, null);
        }



        // asi k ničemu, moc mi toho neodchytává
        private static void NetworkAvailabilityChanged(
        object sender, NetworkAvailabilityEventArgs e)
        {
            // Report whether the network is now available or unavailable.
            if (!MainForm.Config.EnableNotificationBubbles)
                return;
            if (e.IsAvailable)
            {
                MainForm.NI.ShowBalloonTip(2000, "Přístupnost sítě", "Síť je dostupná", System.Windows.Forms.ToolTipIcon.Info);
            }
            else
            {
                MainForm.NI.ShowBalloonTip(2000, "Přístupnost sítě", "Síť není dostupná", System.Windows.Forms.ToolTipIcon.Info);
            }
        }
        // Declare a method to handle NetworkAdressChanged events.
        private static void NetworkAddressChanged(object sender, EventArgs e)
        {
            List<NetInfo> nis = Tools.GetNetworks();
            foreach (var rule in MainForm.Config.Networks)
            {
                foreach (var ni in nis)
                {
                    if (rule.Gateway != null && !rule.Gateway.Equals(ni.Gateway))
                        continue;
                    if (rule.IPAddress != null && !rule.IPAddress.Equals(ni.IPAddress))
                        continue;
                    if (!string.IsNullOrWhiteSpace(rule.NetworkName) && !rule.NetworkName.Equals(ni.NetworkName))
                        continue;
                    
                    //here we found posotive rule
                    MainForm.Config.Activated = true;
                    LastMatchedNetwork = rule;
                    return;
                }
            }
            // if we are here nothing found
            MainForm.Config.Activated = false;
            return;
        }
    }
}
