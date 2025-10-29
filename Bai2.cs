using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    internal class Bai2
    {
        public void Run()
        {
            solve();
        }
        static void solve()
        {
            
            Console.WriteLine("Nhap duong dan thu muc: ");
            string? str = Console.ReadLine();
            if (Directory.Exists(str))
            {
                string[] files = Directory.GetFiles(str);
                for (int i = 0; i < files.Length; i++)
                {
                    Console.WriteLine(files[i]);
                }
                string[] dir = Directory.GetDirectories(str);
                for (int i = 0; i < dir.Length; i++)
                {
                    Console.WriteLine(dir[i]);
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay thu muc.");
            }
        }
    }
}

