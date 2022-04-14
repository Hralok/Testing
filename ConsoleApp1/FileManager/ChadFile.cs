using System;
using System.IO;

namespace FileManager
{
    public class ChadFile
    {
        static void Main(string[] args)
        {

        }

        public static void WriteOutput(string[] output, string outputName)
        {
            File.WriteAllLines(outputName + ".txt", output);
        }


        public static string[] GetInput(string inputName)
        {
            //File.WriteAllText(inputPath, "321");
            return File.ReadAllLines(inputName + ".txt");
        }
    }
}
