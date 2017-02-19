using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityPanel
{
    class FileUtils
    {
        private static System.IO.FileStream fs;

        public static void WriteMessageToFile(string FileURL, string message)
        {
            fs = new System.IO.FileStream(FileURL, FileMode.Append, FileAccess.Write, FileShare.None);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(message);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
