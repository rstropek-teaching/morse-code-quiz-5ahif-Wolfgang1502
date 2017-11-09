using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MorseCodeDecoder
{
    public class FileTranslator
    {

        public string inputFile { get; set; }
        private string outputFile { get; set; }
        private bool deletedFile = false;

        public StringBuilder morseText { get; set; }
        public StringBuilder solution { get; set; }

        private List<string> letters = new List<string>();
        private Codes codes = new Codes();

        public FileTranslator(string inputFile, string outputFile)
        {
            this.inputFile = inputFile;
            this.outputFile = outputFile;

            morseText = new StringBuilder("");
            solution = new StringBuilder("");
        }

        public void ReadFile()
        {
            if (File.Exists(inputFile))
            {
                string[] lines = File.ReadAllLines(inputFile);
                for (int i = 0; i < lines.Length; i++)
                {
                    // Using StringBuilder for very Big Data
                    // Clear the memory every Line, if the file is very big
                    morseText = new StringBuilder("");
                    morseText.Append(lines[i]);
                    Translate();
                }
            }
            else
            {
                Console.WriteLine("inputfile doesn't exist");
            }
  //          Console.WriteLine(morseText);
        }

        public void Translate()
        {

            char[] arr = this.morseText.ToString().ToCharArray();
            string letter = "";

            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == ' ' || arr[i] == '.' || arr[i] == '-')
                {
                    if (arr[i] == ' ')
                    {
                        letters.Add(letter);
                        letter = "";
                    }
                    else
                    {
                        letter = letter + arr[i];
                    }
                }
                else
                {
                    Console.WriteLine("Wrong char in the morse code: |" + arr[i] + "|");
                    Environment.Exit(2);
                }
            }
            letters.Add(letter);

            
            for(int i = 0; i < letters.Count; i++)
            {
                if(letters[i] != "")
                {
        //            Console.WriteLine(letterAllocation(letters[i]));
                    solution.Append(LetterAllocation(letters[i]));
                }
                else
                {
                    if(i + 2 < letters.Count && letters[i + 1].Equals("") && letters[i + 2].Equals(""))
                    {
       //                 Console.WriteLine("");
                        solution.Append(" ");
                        i = i + 2;
                    }
                    else
                    {
                        Console.WriteLine("Wrong spaces between the words!");
                    }
                    
                }
                
            }
            WriteinFile();
            solution.Clear();
            letters.Clear();
            //        Console.WriteLine(solution);
        }

        public char LetterAllocation(string l)
        {
            if (codes.morseAlphabetDictionary.TryGetValue(l, out char result))
            {
        //        Console.WriteLine("GEHHEIM: " + result);
                return result;
            }
            else
            {
                Console.WriteLine("Wrong morse code: " + l);
                Environment.Exit(3);
                return ' ';
            }
        }

        public void WriteinFile()
        {

            if (File.Exists(outputFile))
            {
                if(!deletedFile)
                {
                    using (StreamWriter sw = new StreamWriter(outputFile))
                    {
                        sw.Write("");
                    }
                    deletedFile = true;
                }

                CommandOutput();
                
                using (StreamWriter sw = new StreamWriter(outputFile, true))
                {
                    sw.WriteLine(solution);
                }
            }
            else
            {
                Console.WriteLine("Output file does not exist!");
                Environment.Exit(4);
            }

        }

        private void CommandOutput()
        {
            Console.WriteLine();
            Console.WriteLine(morseText);
            Console.WriteLine(solution);
        }

    }
}
