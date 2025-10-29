using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace BTH2
{
    internal class DatDai
    {
        string? Diadiem;
        double Giaban;
        double Dientich;
        public DatDai(string dd="",double gb=0,double dt = 0)
        {
            Diadiem = dd;
            Giaban = gb;
            Dientich = dt;
        }
        public virtual bool input()
        {
            bool cd;
            Console.Write($"Nhap dia diem {getloai()}: ");
            Diadiem = Console.ReadLine();
            Console.Write($"Nhap gia ban {getloai()}: ");
            cd = double.TryParse(Console.ReadLine(), out Giaban)&&Giaban>=0;
            Console.Write($"Nhap dien tich {getloai()}: ");
            cd = cd && double.TryParse(Console.ReadLine(), out Dientich)&&Dientich>=0;
            return cd;
        }
        public virtual void output()
        {
            Console.WriteLine($"Dia diem la: {Diadiem}");
            Console.WriteLine($"Gia ban la: {Giaban}");
            Console.WriteLine($"Dien tich la: {Dientich}");
        }
        public double getgia()
        {
            return Giaban;
        }
        public double getdientich()
        {
            return Dientich;
        }
        public string getdiadiem()
        {
            return Diadiem;
        }
        public virtual string getloai()
        {
            return "";
        }
    }
    class KhuDat : DatDai
    {
        public override string getloai()
        {
            return "Khu Dat";
        }
    }
    class NhaPho : DatDai
    {
        int Namxd;
        int Sotang;
        public override bool input()
        {
            bool cd1 = base.input();
            Console.Write($"Nhap nam xay dung {getloai()}: ");
            bool cd2 = int.TryParse(Console.ReadLine(), out Namxd)&&Namxd>=0;
            Console.Write($"Nhap so tang {getloai()}: ");
            bool cd3 = int.TryParse(Console.ReadLine(), out Sotang)&&Sotang>=0;
            return cd1 && cd2 && cd3;
        }
        public override void output()
        {
            base.output();
            Console.WriteLine($"Nam xay dung la: {Namxd}");
            Console.WriteLine($"So tang la: {Sotang}");
        }
        public int getnamxd()
        {
            return Namxd;
        }
        public override string getloai()
        {
            return "Nha Pho";
        }
    }
    class ChungCu : DatDai
    {
        int Tang;
        public override bool input()
        {
            bool cd1 = base.input();
            Console.Write($"Nhap tang {getloai()}: ");
            bool cd2 = int.TryParse(Console.ReadLine(), out Tang)&&Tang>=0;
            return cd1 && cd2;
        }
        public override void output()
        {
            base.output();
            Console.WriteLine($"Tang la: {Tang}");
        }
        public override string getloai()
        {
            return "Chung Cu";
        }
    }
    class Bai5
    {
        List<DatDai> l = new List<DatDai>(0);
        public void Run()
        {
            repeat();
        }
        void repeat()
        {
            int ch;
            do
            {
                Console.WriteLine("--Bai5--");
                Console.WriteLine("1. Nhap danh sach");
                Console.WriteLine("2. Xuat danh sach");
                Console.WriteLine("3. Xuat tong gia cho 3 loai");
                Console.WriteLine("4. Loc theo dieu kien da cho");
                Console.WriteLine("5. Tim kiem thong tin");
                Console.WriteLine("6. Thoat");
                Console.Write("Chon: ");
                if (!int.TryParse(Console.ReadLine(), out ch))
                {
                    Console.WriteLine("Khong hop le, chon lai");
                    continue;
                }
                switch (ch)
                {
                    case 1:
                        input();
                        break;
                    case 2:
                        output();
                        break;
                    case 3:
                        sum();
                        break;
                    case 4:
                        filter();
                        break;
                    case 5:
                        search();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Khong hop le, chon lai");
                        break;
                }

            } while (ch != 6);
        }
        void input()
        {
            int n;
            Console.WriteLine("Nhap so phan tu cua mang: ");
            if (int.TryParse(Console.ReadLine(), out n) && n>0)
            {
                l = new List<DatDai>(n);
                for (int i = 0; i < n; i++)
                {
                    int ch;
                    Console.WriteLine($"Nhap phan tu thu {i + 1}: ");
                    Console.WriteLine("1. Khu Dat   2. Nha pho  3. Chung cu");
                    Console.WriteLine("Chon: ");
                    if (int.TryParse(Console.ReadLine(),out ch))
                    {
                        switch (ch)
                        {
                            case 1:
                                l.Add(new KhuDat());
                                break;
                            case 2:
                                l.Add(new NhaPho());
                                break;
                            case 3:
                                l.Add(new ChungCu());
                                break;
                            default:
                                i--;
                                Console.WriteLine("Khong hop le");
                                break;
                        }
                        if (i>=0&&!l[i].input())
                        {
                            i--;
                            l.RemoveAt(l.Count - 1);
                            Console.WriteLine("Khong hop le");
                        }
                    }
                    else
                    {
                        i--;
                        Console.WriteLine("Khong hop le");
                    }

                }
            }
            else Console.WriteLine("Khong hop le");
        }
        void output()
        {
            if (l.Count == 0)
            {
                Console.WriteLine("Mang rong");
                return;
            }
            Console.WriteLine("Danh sach cac phan tu: ");
            for (int i = 0; i < l.Count; i++)
            {
                Console.WriteLine($"{l[i].getloai()}: ");
                l[i].output();
            }
        }
        void sum()
        {
            double tgkd = 0, tgnp = 0, tgcc = 0;
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i] is KhuDat)
                {
                    tgkd += l[i].getgia();
                }
                else if (l[i] is NhaPho)
                {
                    tgnp += l[i].getgia();
                }
                else tgcc += l[i].getgia();
            }
            Console.WriteLine($"Tong gia loai Khu Dat la: {tgkd} VND");
            Console.WriteLine($"Tong gia loai Nha Pho la: {tgnp} VND");
            Console.WriteLine($"Tong gia loai Chung Cu la: {tgcc} VND");
        }
        void filter()
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i] is KhuDat && l[i].getdientich() > 100) 
                {
                    Console.WriteLine(l[i].getloai());
                    l[i].output();
                }
                else if (l[i] is NhaPho && l[i].getdientich() > 60 && ((NhaPho)l[i]).getnamxd() >=2019)
                {
                    Console.WriteLine(l[i].getloai());
                    l[i].output();
                }
            }
        }
        void search()
        {
            string dd;
            double dt, gb;
            Console.WriteLine("Nhap cac thong tin can tim: ");
            Console.Write("Dia diem: ");
            dd = Console.ReadLine();
            bool cd;
            Console.Write("Dien tich: ");
            cd = double.TryParse(Console.ReadLine(), out dt);
            Console.Write("Gia ban: ");
            cd = double.TryParse(Console.ReadLine(), out gb) && cd;
            if (!cd)
            {
                Console.WriteLine("Thong tin khong hop le");
                return;
            }
            for (int i = 0; i < l.Count; i++)
            {
                if (dd!=null&&l[i].getdiadiem()!=null&& l[i].getdiadiem().ToLower().Contains(dd.ToLower()) && l[i].getgia() <= gb && l[i].getdientich() >= dt)
                {
                    Console.WriteLine(l[i].getloai());
                    l[i].output();
                }
            }
        }
    }
}
