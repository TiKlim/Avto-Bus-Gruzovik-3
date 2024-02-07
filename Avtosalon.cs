using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtomobil3
{
    internal class Avtosalon
    {
        public static void Menu3(List<Avto> cars)
        {
            Avto car;
            while (true)
            {
                Console.WriteLine("> Общее меню:\n1 - Выбрать новый автомобиль; 2 - Выбрать обкатанный автомобиль.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string? vybor1 = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (vybor1 == "1")
                {
                    Console.WriteLine("> Тип машины (1 - Легковая; 2 - Грузовая; 3 - Общественно-городская.)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    int type = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (type)
                    {
                        case 1:
                            cars.Add(new Avto(1));
                            break;
                        case 2:
                            cars.Add(new Gruzovik());
                            break;
                        case 3:
                            cars.Add(new AvtoBus());
                            break;
                    }
                }
                else if (vybor1 == "2")
                {
                    //foreach (Avto a in cars)
                    //{
                        Console.WriteLine("Введите номер автомобиля: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        string? s = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                    var names = from g in Avto.cars
                                where g.Nom == s
                                select g;
                    foreach (var name in names)
                    {
                        name.Menu2(Avto.cars);
                    }
                    /*if (s == a.Nom)
                        {
                            car = a;
                            car.Menu2(cars);
                        }*/
                    //}
                }
            }
        }
    }
}
