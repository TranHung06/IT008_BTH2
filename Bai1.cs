using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    internal class Bai1
    {
        int th, n;
        public void Run()
        {
            if (!input())
            {
                Console.WriteLine("Khong hop le");
                return;
            }
            solve();
        }
        // xử lý các khoảng cách khi in ra
        void solve()
        {
            if (test(1, th, n))
            {
                int sum = timngay();
                string[] str = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
                for (int i = 0; i < str.Length; i++)
                {
                    Console.Write(str[i] + ' ');
                }
                Console.WriteLine();
                int thu = timthu(1, th, n);
                string[] blank = { "", " ", "  ", "   ", "    " };
                for (int i = 0; i <= thu; i++)
                {
                    if (thu == 6) break;
                    Console.Write(blank[4]);
                }
                int start = 1;
                for (int i = thu == 6 ? 0 : thu + 1; i < 7; i++)
                {
                    Console.Write(start + blank[3]);
                    start++;
                }
                Console.WriteLine();
                for (int count = 0; start <= sum; start++)
                {
                    string s = start >= 10 ? blank[2] : blank[3];
                    count++;
                    Console.Write(start + s);
                    if (count == 7)
                    {
                        Console.WriteLine();
                        count = 0;
                    }
                }
                Console.WriteLine();
            }
            else Console.WriteLine("Ngay khong hop le.");
        }
        bool input()
        {
            Console.WriteLine("Nhap thang: ");
            if (!int.TryParse(Console.ReadLine(), out th) && (th<0||th>12)) return false;
            Console.WriteLine("Nhap nam: ");
            string str= Console.ReadLine();
            if (!int.TryParse(str, out n)) return false;
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 && str[i] == '-')
                {
                    continue;
                }else if (str[i] <'0' || str[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }

        int timngay()
        {
            switch (th)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if (n % 400 == 0 || (n % 4 == 0 && n % 100 != 0))
                    {
                        return 29;
                    }
                    else return 28;
                default:
                    return -1;
            }
        }
        //Kiểm tra hợp lệ
        static bool test(int ng,int th,int n)
        {
            if (ng <= 0) return false;
            switch (th)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (ng > 31)
                        return false;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (ng > 30) return false;
                    break;
                case 2:
                    if (n % 400 == 0 || (n % 4 == 0 && n % 100 != 0))
                    {
                        if (ng > 29) return false;
                    }
                    else if (ng > 28) return false;
                    break;
                default:
                    return false;
            }
            return true;
        }

        //Tính tổng số ngày đã qua trong tháng
        static int tongngay(int th, int n)
        {
            int sum = 0;
            int start = 1;
            while (start < th)
            {
                switch (start)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        sum += 31;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        sum += 30;
                        break;
                    case 2:
                        if (n % 400 == 0 || (n % 4 == 0 && n % 100 != 0))
                        {
                            sum += 29;
                        }
                        else sum += 28;
                        break;
                    default:
                        return sum;
                }
                start++;
            }
            return sum;
        }
        //Tính tổng ngày kể từ 1/1/0001 xong mod cho 7
        static int timthu(int ng,int th,int n)
        {
            int sum = 0;
            for (int i = 1; i < Math.Abs(n); i++)
            {
                if (i % 400 == 0 || (i % 4 == 0 && i % 100 != 0))
                {
                    sum += 366;
                }
                else
                {
                    sum += 365;
                }
                sum %= 7;
            }
            sum += tongngay(th, n);
            sum += ng - 1;
            return sum % 7;

        }
    }
}
