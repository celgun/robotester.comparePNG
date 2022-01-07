using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Threading;



using RoboTester.comparePNG.DataLayer;
using RoboTester.comparePNG.OperationLayer;

namespace RoboTester.comparePNG
{
    /// <summary>
    /// CCE | 06.01.2022: Main entrance point for comparePNG program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// CCE | 06.01.2021: print Usage format for comparePNG.exe
        /// The algorithm will compare test_image.png and reference_image.png
        /// And the result output will be printed on result_image.png
        /// And there will be result: SAME, DIFFERENT (or error messages)
        /// </summary>
        /// 
        public static void printUsage()
        {
            Console.WriteLine("\n\nUSAGE {\n");
            Console.WriteLine("comparePNG.exe test_image.png reference_image.png result_image.png\n");
            Console.WriteLine("}\n");
        }
        public static int Main(string[] args)
        {
            if (args.Length != 3)
            {
                printUsage();
                return Constants.RESULT_ERROR_USAGE;
            }
            if (!File.Exists(args[0].ToString()) || !File.Exists(args[1].ToString()))
                return Constants.RESULT_ERROR_FILE_NOT_FOUND;

            Console.WriteLine("Hello World!!"); Console.WriteLine();
            Console.WriteLine("Test Image: " + args[0]);
            Console.WriteLine("Ref Image: " + args[1]);
            Console.WriteLine("Result Image: " + args[2]); Console.WriteLine();
            Console.Write("..starting to compare..\n");

            int iResult = OpsLayer.compareImages(args[0], args[1], args[2]);
            OpsLayer.printResult(iResult);

            return iResult;
        }
    }
}
