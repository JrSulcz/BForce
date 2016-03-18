using System;
using System.Net;
using System.IO;
using System.Text;
using System.Web;
using System.Diagnostics;
using System.Threading;
using SMSDevelopmentAndSupport.RmsV.bi.Common;

namespace MiningBForce
{
    class BForce
    {
        public static string Shuffle(string str)
        {
            char[] array = str.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }
        public static string nnc_hash(int line){
            string A = "0123456789abcdef0123456789abcdef0123456789abcdef"+
                       "0123456789abcdef0123456789abcdef0123456789abcdef"+
                       "0123456789abcdef0123456789abcdef0123456789abcdef"+
                       "0123456789abcdef0123456789abcdef0123456789abcdef"+
                       "0123456789abcdef";
        	string B = "012345678901234567890123456789012345678901234567890123456789";
            string hash = Shuffle(A);
            string code = Shuffle(B);
	        string C = Shuffle(hash).Substring(0,13)+"doc"+Shuffle(code);
	        string K = C.Substring(0,16+5);
	        string L = C.Substring(0,16+4);
	        string M = C.Substring(0,16+3);
	        string N = C.Substring(0,16+6);
	        string O = C.Substring(0,16+2);
	        string P = C.Substring(0,16+1);
            string[] end = {
                BCrypt.HashPassword(K, "$2a$08$WGtSTDQ4dkhjNTNrejB3Mw==$"),
                BCrypt.HashPassword(L, "$2a$08$WGtSTDQ4dkhjNTNrejB3Mw==$"),
                BCrypt.HashPassword(M, "$2a$08$WGtSTDQ4dkhjNTNrejB3Mw==$"),
                BCrypt.HashPassword(N, "$2a$08$WGtSTDQ4dkhjNTNrejB3Mw==$"),
                BCrypt.HashPassword(O, "$2a$08$WGtSTDQ4dkhjNTNrejB3Mw==$"),
                BCrypt.HashPassword(P, "$2a$08$WGtSTDQ4dkhjNTNrejB3Mw==$"),
                K,
                L,
                M,
                N,
                O,
                P
            };
            return end[line];
        }

        static void Main()
        {
            try
            {
                string server = string.Format("http://nanocoin-global.com/blockchain/mine");
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(server);
                WebResponse respons = request.GetResponse();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Welcome to software Nanocoin \u00A9 Mining BForce!");
                Console.WriteLine();
                Console.WriteLine("This is a generic version of the code, BForce is open source,");
                Console.WriteLine("so you can enhances it can then achieve better performance and mining speed.");
                Console.WriteLine("Good Farm!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[username/pool] ");
                Console.ForegroundColor = ConsoleColor.White;
                var seeker = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[confirm] ");
                Console.ForegroundColor = ConsoleColor.White;
                var seeker2 = Console.ReadLine();
                if(seeker.ToLower() == seeker2.ToLower()){}else{
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error, input values are not equal.");
                    Console.WriteLine();
                    Console.WriteLine("Be sure to type the correct name,");
                    Console.WriteLine("or will be subject to not receiving their rewards.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to try again!");
                    Console.ReadKey();
                    Console.Clear();
                    Main();
                }
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("========");
                Console.WriteLine("  MENU  ");
                Console.WriteLine("========");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Enter key [S]: To mine a specific hash.");
                Console.WriteLine("Enter key [R]: To try random combinations.");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                string menu = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                if (menu.ToUpper() == "S" || menu.ToUpper() == "R") {
                    Console.Clear();
                    if (menu.ToUpper() == "S") {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Enter the hash code:");
                        Console.Write(">> ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string find = Console.ReadLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("You typed: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("{0}", find);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That's right? If you are sure, press any key!");
                        Console.ReadKey();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        var search = find;
                        Console.WriteLine("======================================================================");
                        Console.WriteLine("[hash] " + search);
                        string trynote = "======  TRYING COMBINATIONS  ======";
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (trynote.Length / 2)) + "}", trynote));
                        for (int i = 1; i > 0; i++)
                        {
                            int[] p = { 6, 7, 8, 9, 10, 11 };
                            foreach (var _id in p)
                            {
                                var id = nnc_hash(_id);
                                Console.WriteLine("[code] " + id);
                                string page = string.Format("http://nanocoin-global.com/blockchain/mine?address=" + seeker + "&hash=" + search + "&id=" + id);
                                System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(page);
                                req.Method = "GET";
                                req.ContentType = "application/x-www-form-urlencoded";
                                WebResponse response = req.GetResponse();
                            }
                        }
                    }
                } else {
                    Console.WriteLine("Invalid command, will be restarting in 5 seconds.");
                    Thread.Sleep(5000);
                    Main();
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 1; i > 0; i++)
                {
                    int[] x = { 0, 1, 2, 3, 4, 5 };
                    int[] p = { 6, 7, 8, 9, 10, 11 };
                    foreach (var array in x)
                    {
                        var stopwatch = new Stopwatch();
                        stopwatch.Start();
                        var stopwatch2 = new Stopwatch();
                        stopwatch2.Start();
                        var search = nnc_hash(array);
                        stopwatch.Stop();
                        TimeSpan timems = stopwatch.Elapsed;
                        string ms = String.Format("{0:00}s {1:00}ms", timems.Seconds, timems.Milliseconds / 10);
                        Console.WriteLine("======================================================================");
                        Console.WriteLine("[Hash/ms: " + ms + "]");
                        Console.WriteLine("[hash] " + search);
                        string trynote = "======  TRYING COMBINATIONS  ======";
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (trynote.Length / 2)) + "}", trynote));
                        foreach (var _id in p)
                        {
                            var id = nnc_hash(_id);
                            Console.WriteLine("[code] " + id);
                            string page = string.Format("http://nanocoin-global.com/blockchain/mine?address=" + seeker + "&hash=" + search + "&id=" + id);
                            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(page);
                            req.Method = "GET";
                            req.ContentType = "application/x-www-form-urlencoded";
                            WebResponse response = req.GetResponse();
                        }
                        stopwatch2.Stop();
                        TimeSpan timems2 = stopwatch2.Elapsed;
                        string ms2 = String.Format("{0:00}m {1:00}s {2:00}ms", timems2.Minutes, timems2.Seconds, timems2.Milliseconds / 10);
                        Console.WriteLine("[Timing: " + ms2 + "]");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error, you can't connect to the network...");
                Console.WriteLine("Check your internet connection.");
                Console.WriteLine("If the problem persists, please contact: http://fb.com/Nanocoin");
                Console.WriteLine();
                Console.WriteLine("Press any key to try again!");
                Console.ReadKey();
                Console.Clear();
                Main();
            }
        }
    }
}