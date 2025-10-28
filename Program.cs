using System;
namespace BTH2
{
    class Program
    {
        static void Main()
        {
            int ch;
            do
            {
                Console.WriteLine("==MENU==");
                Console.WriteLine("1. Bai 1");
                Console.WriteLine("2. Bai 2");
                Console.WriteLine("3. Bai 3");
                Console.WriteLine("4. Bai 4");
                Console.WriteLine("5. Bai 5");
                Console.WriteLine("6. Thoat");
                Console.WriteLine("Chon: ");
                if(!int.TryParse(Console.ReadLine(),out ch))
                {
                    Console.WriteLine("Nhap lai");
                    continue;
                }
                switch(ch){
                    case 1:
                        Bai1 b1 = new Bai1();
                        b1.Run();
                        break;
                    case 2:
                        Bai2 b2 = new Bai2();
                        b2.Run();
                        break;
                    case 3:
                        Bai3 b3 = new Bai3();
                        b3.Run();
                        break;
                    case 4:
                        Phanso b4 = new Phanso();
                        b4.Run();
                        break;
                    case 5:
                        Bai5 b5 = new Bai5();
                        b5.Run();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Chon lai");
                        break;
                }
            } while (ch != 6);
            
        }

    }
}
