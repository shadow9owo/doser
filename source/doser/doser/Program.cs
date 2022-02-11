using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace doser
{
    class Program
    {
        static void Main(string[] args)
        {
            l:
            int counter = 0;
            bool atv = true;
            string logo = @" __     __     __  ___   _";
            string logo1 = @"|  \   /  \   /    |__  | \";
            string logo2 = @"|   | |    |  \_   |__  |_/";
            string logo3 = @"|__/   \__/   __/  |__  | \";
            string ip;
            Console.Title = "doser";
            Ping p = new Ping();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine(logo);
            Console.WriteLine(logo1);
            Console.WriteLine(logo2);
            Console.WriteLine(logo3 + "\n");
            Console.WriteLine("shadowdev is not responsible for any kinds of damages");
            Console.WriteLine("if you are using this on an website then you must do it like this");
            Console.WriteLine(@"www.example.com not like this http:\\example.com\");
            Console.WriteLine("doser v1.0.2");
            Console.Write("enter valid ip/website: ");
            ip = Console.ReadLine();
            PingReply reply = p.Send(ip, 1000);
            while (atv == true)
            {
                Thread.Sleep(10);
                try
                {
                    Console.WriteLine("completed in:" + reply.RoundtripTime);
                    if (counter == 20)
                    {
                        Console.Clear();
                        counter = 0;
                        Console.WriteLine(logo);
                        Console.WriteLine(logo1);
                        Console.WriteLine(logo2);
                        Console.WriteLine(logo3 + "\n");
                    }
                    else
                    {
                        counter++;
                    }
                }catch
                {
                    atv = false;
                    Console.WriteLine("host is unable to get a ping\nthere is a couple reasons why this is happening\n n.1 you or he/she is offline\nn.2 his server/computer crashed");
                    Console.ReadLine();
                    Console.Clear();
                    goto l;
                }
            }
        }
    }
}
