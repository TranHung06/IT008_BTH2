using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    internal class Bai3
    {
        int n, m, minv, maxv;
        int[,] v = new int[0, 0];
        public void Run()
        {
            repeat();
        }
        void repeat()
        {
            int ch;
            do
            {
                Console.WriteLine("--Bai3--");
                Console.WriteLine("1. Nhap ma tran");
                Console.WriteLine("2. Xuat ma tran");
                Console.WriteLine("3. Tim kiem phan tu");
                Console.WriteLine("4. Xuat cac phan tu la SNT");
                Console.WriteLine("5. Cho biet dong co nhieu SNT nhat");
                Console.WriteLine("6. Thoat");
                Console.WriteLine("Chon: ");
                if (!int.TryParse(Console.ReadLine(), out ch))
                {
                    Console.WriteLine("Nhap lai");
                    continue;
                }
                switch (ch)
                {
                    case 1:
                        if (!input())
                        {
                            Console.WriteLine("Khong hop le");
                        }else
                        {
                            createarr();
                            break;
                        }
                            break;
                    case 2:
                        printarr();
                        break;
                    case 3:
                        Console.WriteLine("Nhap gia tri muon tim: ");
                        int k;
                        if (!int.TryParse(Console.ReadLine(),out k))
                        {
                            Console.WriteLine("Khong hop le");
                            break;
                        }
                        if (!findelement(k))
                        {
                            Console.WriteLine("Khong tim thay phan tu trong ma tran");
                        }
                        break;
                    case 4:
                        List<int> l = printprime();
                        Console.WriteLine("Cac phan tu la SNT: ");
                        for (int i = 0; i < l.Count; i++)
                        {
                            Console.Write(l[i] + " ");
                        }
                        Console.WriteLine();
                        break;
                    case 5:
                        List<int> l1 = countrowprime();
                        Console.WriteLine("Cac dong chua nhieu SNT nhat: ");
                        for (int i = 0; i < l1.Count; i++)
                        {
                            Console.Write(l1[i] + " ");
                        }
                        Console.WriteLine();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Chon lai");
                        break;
                }
            } while (ch != 6);
        }
        //Nhập thông tin
        bool input()
        {
            int cd = 1;
            Console.WriteLine("Nhap so dong > 0: ");
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                cd = 0;
            }
            Console.WriteLine("Nhap so cot > 0: ");
            if (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
            {
                cd = 0;
            }
            Console.WriteLine("Nhap gia tri be nhat cua phan tu: ");
            if (!int.TryParse(Console.ReadLine(), out minv))
            {
                cd = 0;
            }
            Console.WriteLine("Nhap gia tri lon nhat cua phan tu: ");
            if (!int.TryParse(Console.ReadLine(), out maxv) || minv > maxv)
            {
                cd = 0;
            }
            return cd == 1 ? true:false;
        }
        //In mảng
        void printarr()
        {
            if (v.GetLength(0) == 0 && v.GetLength(1) == 0)
            {
                Console.WriteLine("Mang rong.");
                return;
            }
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                    Console.Write(v[i, j] + " ");
                Console.Write('\n');
            }
        }
        //Tạo mảng
        void createarr()
        {
            v = new int[n, m];
            Random rd = new Random();
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    v[i, j] = rd.Next(minv, maxv + 1);
                }
            }
        }
        //Kiểm tra SNT
        static bool isprime(int v)
        {
            if (v < 2) return false;
            for (int i = 2; i * i <= v; i++)
            {
                if (v % i == 0) return false;
            }
            return true;
        }
        //Tìm kiếm phần tử 
        bool findelement(int k)
        {
            bool cd = false;
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    if (v[i,j] == k)
                    {
                        Console.WriteLine($"Phan tu o vi tri hang {i + 1} cot {j + 1}");
                        cd = true;
                    }
                }                    
            }
            return cd;
        }
        //Xuất các phần tử là SNT
        List<int> printprime()
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    if (isprime(v[i, j]))
                    {
                        temp.Add(v[i, j]);
                    }
                }
            }
            return temp;
        }
        //Kiểm tra dòng có nhiều SNT I
        List<int> countrowprime()
        {
            int max = 0;
            List<int> row = new List<int>();
            for (int i = 0; i < v.GetLength(0); i++)
            {
                int temp = 0;
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    if (isprime(v[i, j]))
                    {
                        temp++;
                    }
                }
                if (temp > max)
                {
                    row.Clear();
                    row.Add(i + 1);
                    max = temp;
                }else if (temp == max)
                {
                    row.Add(i + 1);
                }
            }
            return row;
        }
    }   
}
