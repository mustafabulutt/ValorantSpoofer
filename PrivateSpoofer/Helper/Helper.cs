using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSpoofer.Helper
{
    public class Helper
    {
        public static void RunAsProcess(string Code)
        {
            Process? process = Process.Start(new ProcessStartInfo("cmd.exe", "/c " + Code)
            {
                CreateNoWindow = true,
                UseShellExecute = false
            });
            process?.WaitForExit();
            process?.Close();
        }

        private static readonly Random random = new(Environment.TickCount);
        public static string RandomString(int length)
        {
            char[] array = "abcdefghlijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToArray();
            string text = string.Empty;
            for (int i = 0; i < length; i++)
            {
                text += array[random.Next(array.Length)].ToString();
            }
            return text;
        }

        public static string RandomNumberString(int length)
        {
            char[] array = "0123456789".ToArray();
            string text = string.Empty;
            for (int i = 0; i < length; i++)
            {
                text += array[random.Next(array.Length)].ToString();
            }
            return text;
        }

        public static void DeleteDirectory(DirectoryInfo dir)
        {
            foreach (FileInfo f in dir.GetFiles()) f.Delete();
            foreach (DirectoryInfo SubDir in dir.GetDirectories()) SubDir.Delete(true);
        }



        public static String RandomUniqueHexShuffle(int length)
        {
            Random random = new Random();
           
                byte[] buffer = new byte[length / 2];
                random.NextBytes(buffer);
                string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
                if (length % 2 == 0)
                    return result;
                return result + random.Next(16).ToString("X");
            
        }




    }
}

