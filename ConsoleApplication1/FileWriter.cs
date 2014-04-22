using System;
using System.IO;
using System.Text;

namespace ApcUps
{
    class FileWriter
    {
        static string path = "D:/WriteText.txt";     
                
        public static void addValue(byte[] value)
        {
            File.AppendAllText(path, BitConverter.ToString(value) + "\n", Encoding.UTF8);            
        }
    }
}
