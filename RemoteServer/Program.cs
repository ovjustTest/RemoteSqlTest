using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;

namespace RemoteServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Server1();
            Server2();
        }

        private static void Server2()
        {

            TcpChannel h = new TcpChannel(9999);
            ChannelServices.RegisterChannel(h, true);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject.RemoteTest),
            "heyu", WellKnownObjectMode.Singleton);


            Console.WriteLine("The Server hasstarted");
            Console.WriteLine("Press the enter keyto stop the server ...");
            Console.ReadLine();
        }

        private static void Server1()
        {
            //注意第二个参数要和客户端的一致，可以为TRUE也可以为FALSE
            ChannelServices.RegisterChannel(new TcpServerChannel(19999), true);
            RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(RemoteObject.RemoteTest), "heyu", WellKnownObjectMode.Singleton);
        }
    }
}
