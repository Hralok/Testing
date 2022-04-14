using System;
using System.IO;

namespace FileManager
{
    public class ChadFile
    {
        static string inputPath = "input.txt";
        static string outputPath = "output.txt";

        static void Main(string[] args)
        {

        }

        public static void WriteOutput(string[] output)
        {
            File.WriteAllLines(outputPath, output);
        }


        public static string[] GetInput()
        {
            //File.WriteAllText(inputPath, "321");
            return File.ReadAllLines(inputPath);
        }
    }
}
