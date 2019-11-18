using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BansheePelican
{
    class Program
    {
        public static void BPheader()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(@"   _ )                    |                 _ \      | _)      ");
            Console.WriteLine(@"   _ \   _` |    \  (_-<    \    -_)   -_)  __/ -_)  |  |   _|   _` |    \  ");
            Console.WriteLine(@"  ___/ \__,_| _| _| ___/ _| _| \___| \___| _| \___| _| _| \__| \__,_| _| _| ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"                               ..--...__                                        ");
            Console.WriteLine(@"        \|/       .           /``.__    ``.          +  .             -*-          ");
            Console.WriteLine(@"        -*-                  |``/  `'-- \|/.                          '          ");
            Console.WriteLine(@"        /|\          -+-     |`|       -(o)-)                                 ");
            Console.WriteLine(@"                      '       \`\     _'/|\ `.                  .                 ");
            Console.WriteLine(@" +                             \``\  (( ` .   `.         |                          ");
            Console.WriteLine(@"        .|       |              `.``.  `.` . `  `.      -*-              |            ");
            Console.WriteLine(@"      creosote - * -             `.``\  `._.  `.  `.     |             - O -          ");
            Console.WriteLine(@"     *   '       |               __\``), )\ `-. `.  `.                   |          ");
            Console.WriteLine(@"                      __ _.- - -'    /     '    `-. `.`.                             ");
            Console.WriteLine(@"       '    *      ,-'               *     /        `-.`.`.    +      `1 o  1           ");
            Console.WriteLine(@"        ,      ,-'  * -            .    +-             `-. `.        1 \||./o     ");
            Console.WriteLine(@" _____ __  -+ '                       -*-       -*-       `-.)        \ |/_/           ");
            Console.WriteLine(@"   ___           _        -    '      '_         '                     \|/__     ");
            Console.ResetColor();
        }


        public static void Help()
        {
            BPheader();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("*  *  *  *  *  *  *  *  *    BITS Metadata Parser   *  *  *  *  *  *  *  *  *");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("Switches: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-p:  Full path of BITS file, enclosed in double quotes");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("     BITS files are generally located here: ");
            Console.WriteLine("     C:\\ProgramData\\Microsoft\\Network\\Downloader\\");
            Console.WriteLine("     Default files may be in use by BITS service which will cause an error");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Examples: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("C:\\>BansheePelican.exe -p \"C:\\ProgramData\\Microsoft\\Network\\Downloader\\qmgr0.dat\"");
            Console.WriteLine("C:\\>BansheePelican.exe -p \"C:\\Evidence\\edb00028.log\"");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.ResetColor();
            System.Environment.Exit(1);
        }


        /// ////////////////////////////////////////////     
        /// ////    Parse HTTP(s)                   ////
        /// ////////////////////////////////////////////
        public static void BitsHttp(ref string[] xbetcha)
        {
            foreach (String line in xbetcha)
            {
                Regex xHttp = new Regex(@"http[s]?://", RegexOptions.IgnoreCase);
                Match mHttp = xHttp.Match(line);

                if (mHttp.Success)
                {
                    // Remove last char of each line due to mangling
                    Console.WriteLine(line.TrimEnd(line[line.Length - 1]));
                }
            }
        }


        /// ////////////////////////////////////////////     
        /// ////    Parse non-BITs files            ////
        /// ////////////////////////////////////////////
        public static void BitsUnq(ref string[] xbetcha)
        {
            foreach (String line in xbetcha)
            {
                Regex xUnq = new Regex(@"\\(?![bit])[\w-]+\.[\w-]+(?!.)", RegexOptions.IgnoreCase);
                Match mUnq = xUnq.Match(line);

                if (mUnq.Success)
                {
                    // Remove last char of each line due to mangling
                    Console.WriteLine(line.TrimEnd(line[line.Length - 1]));
                }
            }
        }

        /// ////////////////////////////////////////////     
        /// ////    Parse Unique HTTP(s)            ////
        /// ////////////////////////////////////////////
        public static void BitsHU(ref string[] xdontcha)
        {
            foreach (String line in xdontcha)
            {
                Regex xHttp = new Regex(@"http[s]?://", RegexOptions.IgnoreCase);
                Match mHttp = xHttp.Match(line);

                if (mHttp.Success)
                {
                    // Remove last char of each line due to mangling
                    //Console.WriteLine(line.TrimEnd(line[line.Length - 1]));
                    String a = Regex.Replace(line, @"(.*).adobe.com/(.*)", string.Empty);
                    String g = Regex.Replace(a, @"(.*).googleapis.com/(.*)", string.Empty);
                    String m = Regex.Replace(g, @"(.*).mozilla.org/(.*)", string.Empty);
                    String mn = Regex.Replace(m, @"(.*).mozilla.net/(.*)", string.Empty);
                    String mi = Regex.Replace(mn, @"(.*).live.com/(.*)", string.Empty);
                    bool minull = string.IsNullOrEmpty(mi);

                    if (minull == true)
                    {
                        //
                    }
                    else
                    {
                        Console.WriteLine(mi.TrimEnd(line[line.Length - 1]));
                    }

                }
            }
        }

        /// ////////////////////////////////////////////     
        /// ////    Codename: BansheePelican        ////
        /// ////////////////////////////////////////////
        static void Main(string[] args)
        {
            // Check if 2 arguments are given
            if (args.Length != 2) { Help(); }

            foreach (string arg in args)
            {
                switch (arg.Substring(0).ToUpper())
                {
                    case "-P":
                        String bFile = arg.Substring(0);
                        String pathFile = arg.Substring(2);
                        //Console.WriteLine(args.Length);
                        //Console.WriteLine(args.GetValue(1));
                        Object fPath = args.GetValue(1).ToString();
                        String xPath = fPath.ToString();

                        try
                        {
                            if (!File.Exists(xPath))
                                throw new FileNotFoundException();
                        }
                        catch (FileNotFoundException e)
                        {
                            BPheader();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("-----------------------------------------------------------------------------");
                            Console.WriteLine("[!] File: " + xPath + " NOT found!  ");
                            Console.WriteLine("-----------------------------------------------------------------------------");
                            Console.ResetColor();
                            System.Environment.Exit(1);

                        }

                        // Check is higher privs are needed to access file
                        try { File.ReadAllLines(xPath); }
                        catch (UnauthorizedAccessException uax)
                        {
                            BPheader();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("-----------------------------------------------------------------------------");
                            Console.WriteLine("[!] Unauthorized Access to file: ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("    " + xPath);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("   [!] Are you running as Administrator?");
                            Console.WriteLine("-----------------------------------------------------------------------------");
                            Console.ResetColor();
                            System.Environment.Exit(1);
                        }

                        BPheader();
                        //////////////////////////////
                        ////  Do initial parsing   ///
                        //////////////////////////////
                        StreamReader reader;
                        //reader = new StreamReader("C:\\test\\qmgr0.dat");
                        //reader = new StreamReader("C:\\test\\edb00028.log");
                        reader = new StreamReader(xPath);
                        String ok = reader.ReadToEnd();
                        String yah = Regex.Replace(ok, @"[^\u0020-\u007E]", string.Empty);
                        String sure = Regex.Replace(yah, @"http[s]?://", "\n\n$&");
                        String you = Regex.Replace(sure, @"[A-Z]:\\", "\n\n$&");
                        string[] betcha = you.Split(new[] { "\n" }, StringSplitOptions.None);

                        // Dedupe strings from parsed results
                        string[] dontcha = betcha.Distinct().ToArray();


                        //////////////////////////////
                        ////  Do parsing methods   ///
                        //////////////////////////////
                        // Parses for http(s) 
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-----------------------------------------------------------------------------");
                        Console.WriteLine("[+] Listing deduped strings with Http(s)");
                        Console.WriteLine("-----------------------------------------------------------------------------");
                        Console.ResetColor();
                        BitsHttp(ref dontcha);
                        Console.Write("\n");

                        // Parses for non-BIT.tmp files
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-----------------------------------------------------------------------------");
                        Console.WriteLine("[+] Listing deduped Files - excluding BITS tmp files");
                        Console.WriteLine("-----------------------------------------------------------------------------");
                        Console.ResetColor();
                        BitsUnq(ref dontcha);
                        Console.Write("\n");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("-----------------------------------------------------------------------------");
                        Console.WriteLine("[+] Listing deduped Unique Http(s) Strings");
                        Console.WriteLine("-----------------------------------------------------------------------------");
                        Console.ResetColor();
                        BitsHU(ref dontcha);
                        Console.Write("\n");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("------------------------------  COMPLETE  -----------------------------------");
                        Console.ResetColor();

                        break;

                    case "-H":
                        Help();
                        break;
                    default:                      
                        //Help();
                        break;
                }
            }
            Console.ResetColor();
            //Console.ReadLine();
        }
    }
}




