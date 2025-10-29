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
        void solve()
        {
            
            Console.WriteLine("Nhap duong dan thu muc: ");
            string? str = Console.ReadLine();
            check(str);
        }
        void check(string str)
        {
            if (Directory.Exists(str))
            {
                try
                {
                    //in ra file
                    Console.WriteLine("Tap tin: ");
                    string[] files = Directory.GetFiles(str);
                    for (int i = 0; i < files.Length; i++)
                    {
                        Console.WriteLine(files[i]);
                    }
                    //in ra directory
                    Console.WriteLine("Thu muc: ");
                    string[] dir = Directory.GetDirectories(str);
                    for (int i = 0; i < dir.Length; i++)
                    {
                        Console.WriteLine(dir[i]);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine($"Khong co quyen truy cap thu muc: {str}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Loi khac : {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay thu muc.");
            }
        }
    }
}

