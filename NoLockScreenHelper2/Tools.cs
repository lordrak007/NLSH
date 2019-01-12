using Microsoft.Win32;
using NETWORKLIST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace NoLockScreenHelper2
{
    public class Tools
    {


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

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        public static void Activate()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
        }

        public static void Deactivate()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }


        /// <summary>
        /// Register application as Startup after logon in user scope
        /// </summary>
        /// <param name="ApplicationName">Application name. Could be anything.</param>
        /// <param name="ApplicationPath">Application executable path</param>
        /// <param name="delete">If true then remove otherwise add it. Default false</param>
        public static void LaunchApplicationAtStartupUserScope(string ApplicationName, string ApplicationPath, bool delete = false)
        {
            RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (!delete)
                key.SetValue(ApplicationName, ApplicationPath);
            else
                key.DeleteValue(ApplicationName, false);
        }

        public static bool GetLaunchApplicationAtStartupUserScope(string ApplicationName)
        {
            RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);
            return key.GetValueNames().Contains(ApplicationName);
        }

        public static IPAddress GetDefaultGateway()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .Where(a => a != null)
                //.Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                // .Where(a => Array.FindIndex(a.GetAddressBytes(), b => b != 0) >= 0)
                .FirstOrDefault();
        }

        public static List<NetInfo> GetNetworks()
        {
            List<NetInfo> result = new List<NetInfo>();
            try
            {
                var nets = NetworkInterface
                    .GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == OperationalStatus.Up)
                    .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback);

                foreach (NetworkInterface ni in nets)
                {
                    NetInfo info = new NetInfo();
                    IPInterfaceProperties ipip = ni.GetIPProperties();
                    if (ipip.UnicastAddresses != null && ipip.UnicastAddresses.Count > 0)
                    {
                        info.IPAddress = ni.GetIPProperties().UnicastAddresses.Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork).First().Address;
                        if (ipip.GatewayAddresses != null && ipip.GatewayAddresses.Count > 0)
                            info.Gateway = ni.GetIPProperties().GatewayAddresses.Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork).First().Address;
                    }
                    result.Add(info);
                }

                var networks = new NetworkListManagerClass().GetNetworks(NETWORKLIST.NLM_ENUM_NETWORK.NLM_ENUM_NETWORK_CONNECTED).Cast<INetwork>();
                foreach (var net in networks)
                {
                    foreach (INetworkConnection netcon in net.GetNetworkConnections())
                    {
                        string name = netcon.GetNetwork().GetName();
                        var ni = nets.FirstOrDefault(i => new Guid(i.Id) == netcon.GetAdapterId());
                        var niip = ni.GetIPProperties().UnicastAddresses.Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
                        if (niip != null && result.Any(a => a.IPAddress.Equals(niip.Address)))
                        {
                            NetInfo info = result.Find(a => a.IPAddress.Equals(niip.Address));
                            info.NetworkName = name;
                        }
                        else
                            continue;
                    }
                }
            }
            catch { }

            return result;
        }

        public static NetInfo GetDefaultGatewayWithNetName()
        {
            NetInfo netinfo = new NetInfo();
            //get defauklt gateway
            var nets = NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Where(n => n.GetIPProperties().GatewayAddresses != null);
            foreach (NetworkInterface ni in nets)
            {
                if (ni.GetIPProperties().GatewayAddresses.Count > 0)
                {
                    netinfo.Gateway = ni.GetIPProperties().GatewayAddresses.Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork).First().Address;
                    netinfo.IPAddress = ni.GetIPProperties().UnicastAddresses.Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork).First().Address;
                    break;
                }
            }

            // get network name to the gateway
            var networks = new NetworkListManagerClass().GetNetworks(NETWORKLIST.NLM_ENUM_NETWORK.NLM_ENUM_NETWORK_CONNECTED).Cast<INetwork>();
            foreach (var net in networks)
            {
                foreach (INetworkConnection netcon in net.GetNetworkConnections())
                {
                    string name = netcon.GetNetwork().GetName();
                    var ni = nets.FirstOrDefault(i => new Guid(i.Id) == netcon.GetAdapterId());
                    var niip = ni.GetIPProperties().GatewayAddresses.Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
                    if (niip != null && netinfo.Gateway.Equals(niip.Address))
                    {
                        netinfo.NetworkName = name;
                        return netinfo;
                    }
                }
            }

            return new NetInfo();
        }


    }

    public class IPAddressConverter
    {
        public static int ToInt(IPAddress ip)
        {
            return BitConverter.ToInt32(ip.GetAddressBytes(), 0);
        }

        public static IPAddress ToIPAddress(int ip)
        {
            return new IPAddress(BitConverter.GetBytes(ip));
        }
    }

    public class NetInfo
    {
        public IPAddress Gateway { get; set; }
        public IPAddress IPAddress { get; set; }
        public string NetworkName { get; set; }

        public override string ToString()
        {
            List<string> str = new List<string>();
            if (!string.IsNullOrEmpty(NetworkName))
                str.Add($"Název: {NetworkName}");
            if (IPAddress != null)
                str.Add($"IP Adresa: {IPAddress}");
            if (Gateway != null)
                str.Add($"IP Brány: {Gateway}");
            return string.Join(", ", str);
        }
    }
}
