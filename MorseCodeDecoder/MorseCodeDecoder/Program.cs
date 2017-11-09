using System;
using System.IO;
using System.Text;

namespace MorseCodeDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 2)
            {
                Console.WriteLine("Input File: " + args[0]);
                Console.WriteLine("Output File: " + args[1]);
            }
            else
            {
                Console.WriteLine("Wrong Parameters: You need an input file and and output file!");
                Environment.Exit(1);
            }

            FileTranslator translator = new FileTranslator(args[0], args[1]);
            translator.ReadFile();
        }
    }
}
