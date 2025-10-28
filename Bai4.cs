using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BTH2
{
    internal class Phanso:IComparable<Phanso>
    {
        int tu, mau;
        public Phanso(int ts=0,int ms=1)
        {
            tu = ts;
            mau = ms;
        }
        public void Run()
        {
            repeat();
        }
        void repeat()
        {
            int ch;
            Phanso[] mps = new Phanso[0];
            Phanso a, b;
            do
            {
                Console.WriteLine("--Bai4--");
                Console.WriteLine("1. Nhap vao hai phan so in tong, hieu, tich, thuong");
                Console.WriteLine("2. Nhap vao mang phan so");
                Console.WriteLine("3. Tim phan so lon nhat trong mang");
                Console.WriteLine("4. Sap xep cac phan so trong day tang dan");
                Console.WriteLine("5. Thoat");
                Console.WriteLine("Chon: ");
                if (!int.TryParse(Console.ReadLine(), out ch))
                {
                    Console.WriteLine("Khong hop le");
                }
                switch (ch)
                {
                    case 1:
                        a = input();
                        b = input();
                        Phanso tong = a + b;
                        toigian(tong);
                        Phanso hieu = a - b;
                        toigian(hieu);
                        Phanso tich = a * b;
                        toigian(tich);
                        Phanso thuong = a / b;
                        toigian(thuong);
                        Console.WriteLine($"Tong: {tong}");
                        Console.WriteLine($"Hieu: {hieu}");
                        Console.WriteLine($"Tich: {tich}");
                        Console.WriteLine($"Thuong: {thuong}");
                        break;
                    case 2:
                        inputmps(ref mps);
                        break;
                    case 3:
                        if (mps.Length <=0)
                        {
                            Console.WriteLine("Mang rong");
                        }else
                        {
                            Console.WriteLine($"Phan so lon nhat: {findmax(mps)}");
                        }
                        break;
                    case 4:
                        if (mps.Length <= 0)
                        {
                            Console.WriteLine("Mang rong");
                        }
                        else
                        {
                            sortps(mps);
                            Console.WriteLine("Mang sau khi sort");
                            printmps(mps);
                        }
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Chon lai");
                        break;

                }
            } while (ch != 5);
        }
        //nhập vào ps
        Phanso input()
        {
            int ts,ms;
            bool check = false;
            do
            {
                if (check) Console.WriteLine("Khong hop le");
                Console.Write("Nhap vao tu so: ");
                check = false;
                if (!int.TryParse(Console.ReadLine(), out ts)) check = true;
                Console.Write("Nhap vao mau so: ");
                if (!int.TryParse(Console.ReadLine(), out ms)||ms==0) check = true;
            }
            while (check);
            return new Phanso(ts, ms);
        }
        //nhập vào mảng ps
        void inputmps(ref Phanso[] mps)
        {
            int size;
            bool check = false;
            do
            {
                if (check) Console.WriteLine("Khong hop le");
                Console.Write("Nhap vao so phan tu cua mang ps: ");
                check = false;
                if (!int.TryParse(Console.ReadLine(), out size)|| size<=0) check = true;
            }
            while (check);
            mps = new Phanso[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Phan so thu {i + 1}");
                mps[i] = input();
                toigian(mps[i]);
            }
        }
        void printmps(Phanso[] mps)
        {
            for (int i = 0; i < mps.Length; i++)
            {
                Console.Write(mps[i]+" ");
            }
            Console.WriteLine();
        }
        //tìm ps lớn nhất
        Phanso findmax(Phanso[] mps)
        {
            Phanso max = mps[0];
            double maxval = getvalue(max);
            for (int i = 1; i < mps.Length; i++)
            {
                double currval = getvalue(mps[i]);
                if ( currval > maxval)
                {
                    max = mps[i];
                    maxval = currval;
                }
            }
            return max;
        }
        //làm tối giản ps
        void toigian(Phanso ps)
        {
            if (ps.tu == ps.mau)
            {
                ps.tu = 1;
                ps.mau = 1;
                return;
            }
            int min = Math.Min(Math.Abs(ps.tu), Math.Abs(ps.mau));
            int ucln=1;
            for (int i = 2; i <= min; i++)
            {
                if (ps.tu % i == 0 && ps.mau % i ==0)
                {
                    ucln = i;
                }
            }
            ps.tu /= ucln;
            ps.mau /= ucln;
        }
        //nạp chồng +
        public static Phanso operator +(Phanso a, Phanso b)
        {
            int ts = a.tu * b.mau + a.mau * b.tu;
            int ms = a.mau * b.mau;
            return new Phanso(ts, ms);
        }
        //nạp chồng -
        public static Phanso operator -(Phanso a, Phanso b)
        {
            int ts = a.tu * b.mau - a.mau * b.tu;
            int ms = a.mau * b.mau;
            return new Phanso(ts, ms);
        }
        //nạp chồng *
        public static Phanso operator *(Phanso a, Phanso b)
        {
            int ts = a.tu * b.tu;
            int ms = a.mau * b.mau;
            return new Phanso(ts, ms);
        }
        //nạp chồng /
        public static Phanso operator /(Phanso a, Phanso b)
        {
            int ts = a.tu * b.mau;
            int ms = a.mau * b.tu;
            return new Phanso(ts, ms);
        }
        //chuyển về double
        double getvalue(Phanso ps)
        {
            return (double)ps.tu / ps.mau;
        }
        //cách in ra
        public override string ToString()
        {
            if ((tu>0 && mau <0) || (tu < 0 && mau > 0))
            {
                return $"{-Math.Abs(tu)}/{Math.Abs(mau)}";
            }
            return $"{Math.Abs(tu)}/{Math.Abs(mau)}";
        }
        //viết phương thức để dùng sort
        public int CompareTo(Phanso ps)
        {
            double val1 = getvalue(this);
            double val2 = getvalue(ps);
            if (val1 < val2) return -1;
            else if (val1 == val2) return 0;
            else return 1;
        }
        //sort mảng ps
        void sortps(Phanso[] mps)
        {
            Array.Sort(mps);
        }
    }
}
