
// Written by Jonathan Fay
// Portions taken from WorldWide Telescope Kinect control circa 2012


using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace KincetControl 
{
    class NetControl
    {
        static Socket sockA = null;

        public static void SendMove(double leftRight, double upDown, double zoom, double tilt)
        {
            SendCommand(leftRight.ToString() + "," + upDown.ToString() + "," + zoom.ToString() + ",,false,0," + -tilt + ", D");
        }

        public static void SendMove(double leftRight, double upDown, double zoom, double tilt, string mode)
        {
            SendCommand(leftRight.ToString() + "," + upDown.ToString() + "," + zoom.ToString() + ",,false,0," + -tilt + "," +mode);
        }
  

        public static void SendCommand(string output)
        {
            if (sockA == null)
            {
                sockA = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
                sockA.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
                IPEndPoint bindEPA = new IPEndPoint(IPAddress.Parse(GetThisHostIP()), 8088);
                sockA.Bind(bindEPA);
            }
            EndPoint destinationEPA = (EndPoint)new IPEndPoint(IPAddress.Broadcast, 8088);


            Byte[] header = Encoding.ASCII.GetBytes(output);

            sockA.SendTo(header, destinationEPA);
        }


        public static string GetThisHostIP()
        {
            string hostIp = "127.1.1.1";
            try
            {
                String strHostName = Dns.GetHostName();

                // Find host by name
                IPHostEntry iphostentry = Dns.GetHostByName(strHostName);

                // Enumerate IP addresses
                foreach (IPAddress ipaddress in iphostentry.AddressList)
                {
                    if (ipaddress.AddressFamily == AddressFamily.InterNetwork)
                    {
                        hostIp = ipaddress.ToString();
                        break;
                    }
                }
            }
            catch
            {
            }

            return hostIp;
        }
    }
}
