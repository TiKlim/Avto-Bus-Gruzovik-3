using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Avtomobil3
{
    internal class Gruzovik : Avto
    {
        protected int ves;
        protected int pogruzka;
        protected double ot;
        protected double ido;
        protected double kilometrdoraz;
        protected double topost;
        protected int pogruz;
        protected int razgruz;
        protected int kuzov;
        public string? Nom { get { return nom; } }
        public Gruzovik() { Menu(cars); }
        protected override void Info(List<Avto> cars)
        {
            Console.WriteLine("> Номер машины (А000АА):");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.nom = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            this.bak = 80;
            Console.WriteLine("> Расход топлива (на 100 км):");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.ras = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            if (ras >= (80 / 2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ваш расход топлива катастрофически велик!");
                Console.ForegroundColor = ConsoleColor.White;
                Info(cars);
            }
            Console.WriteLine("> Грузоподъёмность:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.ves = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            this.speed = 0;
            this.top = 0;
            this.probeg = 0;
            this.kilometragh = 0;
            this.rasst = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Данные сохранены.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        protected override void Menu(List<Avto> cars)
        {
            Console.WriteLine("> Бортовое меню:\n1 - Внести информацию по машине; 2 - Выход в меню автомобилей.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? vybor2 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            switch (vybor2)
            {
                case "1":
                    Info(cars); break;
                case "2":
                    Avtosalon.Menu3(cars); break;
            }
        }
        public override void Menu2(List<Avto> cars)
        {

            Console.WriteLine("> Бортовое меню:\n1 - Изменить Ваш маршрут; 2 - Разогнаться; 3 - Тормозить; 4 - Заправиться; 5 - Выход в меню автомобилей; 6 - Авария.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? vybor2 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            switch (vybor2)
            {
                case "1":
                    Info2(cars); break;
                case "2":
                    Razgon(cars); break;
                case "3":
                    Stop(cars); break;
                case "4":
                    Zapravka(cars); break;
                case "5":
                    Avtosalon.Menu3(cars); break;
                case "6":
                    Avaria(cars); break;
            }
        }
        protected override void Info2(List<Avto> cars)
        {
            if (dist > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("! МАРШРУТ УЖЕ ЗАДАН !");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("> Желаете обнулить? (да/нет)");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string? yesno = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                switch (yesno)
                {
                    case "да":
                        dist = 0;
                        break;
                    case "нет":
                        Console.WriteLine("");
                        break;
                }
                Menu2(cars);
            }
            if (dist == 0)
            {
                speed = 0;
                Console.WriteLine("'МАРШРУТ'");
                Console.WriteLine("> Введите координаты Вашего маршрута: ");
                Console.WriteLine("> Начало пути: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                this.koordinataXa = Convert.ToInt32(Console.ReadLine());
                this.koordinataYa = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("> Конец пути: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                this.koordinataXb = Convert.ToInt32(Console.ReadLine());
                this.koordinataYb = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("> Точка погрузки (через сколько километров будет погрузка): ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                this.pogruzka = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                this.dist = 2 * (Math.Round(Math.Sqrt(((koordinataXb - koordinataXa) * (koordinataXb - koordinataXa)) + ((koordinataYb - koordinataYa) * (koordinataYb - koordinataYa)))));
                if (pogruzka > dist)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Вы не можете назначить точку погрузки дальше точки разгрузки {dist} км!");
                    Console.ForegroundColor = ConsoleColor.White;
                    dist = 0;
                    Info2(cars);
                }
                if (pogruzka <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пожалуйста, введите точку погрузки!");
                    Console.ForegroundColor = ConsoleColor.White;
                    dist = 0;
                    Info2(cars);
                }
                this.ot = 0 + pogruzka;
                this.ido = (dist / 2) - pogruzka;
                this.kilometrdoraz = ot;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Данные сохранены.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Ваш маршрут: {dist / 2} км. \nТочка погрузки через: {pogruzka} км. \nУдачи на дороге!"); //!!!
                this.rasst = 0;
                Menu2(cars);
            }
        }
        protected override void Stop(List<Avto> cars)
        {
            speed = 0;
            //rasst = 0;
            //Out();
            Ezda(cars);
            Menu2(cars);
        }
        protected override void Razgon(List<Avto> cars)
        {
            if (dist == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("! Маршрут не задан !");
                Console.ForegroundColor = ConsoleColor.White;
                Menu2(cars);
            }
            else if (dist > 0)
            {
                if (top > 0)
                {
                    speed += 10;
                    Out();
                    Ezda(cars);
                    Menu2(cars);
                }
                else if (top == 0)
                {
                    rasst = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!      Бак пуст      !");
                    Console.WriteLine($"! Требуется заправка !");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("> Заправиться? (да/нет)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string? zap = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (zap)
                    {
                        case "да":
                            Zapravka(cars); break;
                        case "нет":
                            Stop(cars); break;
                    }
                }
                else if (top < 0)
                {
                    rasst = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!      Бак пуст      !");
                    Console.WriteLine($"! Требуется заправка !");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("> Заправиться? (да/нет)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string? zap = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (zap)
                    {
                        case "да":
                            Zapravka(cars); break;
                        case "нет":
                            Stop(cars); break;
                    }
                }
            }
        }
        protected override void Ezda(List<Avto> cars)
        {
            if (speed > 0) //Если машина в принципе поехала
            {
                if (top > 0)
                {
                    top -= ras;
                    probeg += 100;
                    rasst += 100;
                }
                else if ((top - ras) < 0 && speed > 0)
                {
                    probeg -= 100;
                    rasst -= 100;
                    probeg += kilometragh;
                    rasst += kilometragh;
                    top = 0;
                }
                else if (top == 0)
                {
                    //rasst = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!      Бак пуст      !");
                    Console.WriteLine($"! Требуется заправка !");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("> Заправиться? (да/нет)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string? zap = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (zap)
                    {
                        case "да":
                            Zapravka(cars); break;
                        case "нет":
                            Stop(cars); break;
                    }
                }
            }
            while (probeg <= dist / 2)
            {
                
                if (top < 2 && rasst < dist / 2 && rasst != 0)
                {
                    rasst += kilometragh - 100;
                    top = 0;
                    speed = 0;
                }
                if (rasst >= ot && kilometrdoraz == ot) //Для маршрута
                {
                    //topost = ((ido * ras) / 100);
                    //top -= topost;
                    double a = kilometrdoraz - rasst;
                    topost = (a * ras) / 100;
                    top -= topost;
                    probeg = ot;
                    kilometrdoraz = ido;
                    speed = 0;
                    //rasst = 0;
                    rasst = ot;
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ВЫ ПРИБЫЛИ В ТОЧКУ ПОГРУЗКИ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine($"Остаток топлива: {Math.Round(top, 1)} литров.");
                    Console.WriteLine($"Пробег: {Math.Round(probeg)} километров.");
                    Console.WriteLine("Сколько грузить?");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    pogruz = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                    if (pogruz <= ves)
                    {
                        kuzov += pogruz;
                    }
                    else if (pogruz > ves)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("! НЕЛЬЗЯ ЗАГРУЗИТЬ В ГРУЗОВИК БОЛЬШЕ ЕГО ГРУЗОПОДЪЁМНОСТИ !");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Сколько грузить?");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        pogruz = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                kilometragh = Math.Round((top / ras) * 100); //На сколько километров хватит бензина
                //topost = ((ido * ras) / 100);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("Пройдено:     Километраж до следующей точки:    Скорость:");
                Console.WriteLine($"\n{rasst}            {kilometrdoraz}                                  {speed}");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine($"Ваш маршрут: {dist / 2} километров.");
                if (top == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!      Бак пуст      !");
                    Console.WriteLine($"! Требуется заправка !");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("> Заправиться? (да/нет)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string? zap = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (zap)
                    {
                        case "да":
                            Zapravka(cars); break;
                        case "нет":
                            Stop(cars); break;
                    }
                }
                else
                {
                    Menu2(cars);
                }
            }
            while (probeg >= dist / 2)
            {
                if (rasst >= dist / 2 && kilometrdoraz == ido) //Для маршрута
                {
                    //topost = ((ido * ras) / 100);
                    //top -= topost;
                    double a = (dist/2) - rasst;
                    topost = (a * ras) / 100;
                    top -= topost;
                    kilometrdoraz = dist / 2;
                    probeg = dist / 2;
                    speed = 0;
                    rasst = 0;
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ВЫ ПРИБЫЛИ В ТОЧКУ РАЗГРУЗКИ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine($"Остаток топлива: {Math.Round(top, 1)} литров.");
                    Console.WriteLine("Сколько выгрузить?");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    pogruz = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                    if (pogruz <= kuzov)
                    {
                        kuzov -= razgruz;
                    }
                    else if (pogruz > kuzov)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("! НЕЛЬЗЯ ВЫГРУЗИТЬ БОЛЬШЕ ЧЕМ ЗАГРУЖЕННО !");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Сколько выгрузить?");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        pogruz = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                if (rasst >= dist / 2 && probeg >= dist / 2 && kilometrdoraz == dist / 2) //Для маршрута
                {
                    double a = kilometrdoraz - rasst;
                    topost = (a * ras) / 100;
                    top -= topost;
                    kilometrdoraz = 0;
                    probeg = dist;
                    speed = 0;
                    rasst = 0;
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ДЕПО");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine($"Остаток топлива: {Math.Round(top, 1)} литров.");
                    Console.WriteLine($"Пробег: {Math.Round(probeg)} километров.");
                    dist = 0;
                }
                if (top < 2 && rasst < dist && rasst != 0)
                {
                    probeg += kilometragh - 100;
                    rasst += kilometragh - 100;
                    top = 0;
                    speed = 0;
                }
                kilometragh = Math.Round((top / ras) * 100); //На сколько километров хватит бензина
                //topost = ((ido * ras) / 100);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("Пройдено:     Километраж до следующей точки:    Скорость:");
                Console.WriteLine($"\n{rasst}            {kilometrdoraz}                                  {speed}");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine($"Ваш маршрут: {dist / 2} километров.");
                if (top == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!      Бак пуст      !");
                    Console.WriteLine($"! Требуется заправка !");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("> Заправиться? (да/нет)");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string? zap = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (zap)
                    {
                        case "да":
                            Zapravka(cars); break;
                        case "нет":
                            Stop(cars); break;
                    }
                }
                else
                {
                    Menu2(cars);
                }
            }
        }
        protected override void Avaria(List<Avto> cars)
        {
            base.Avaria(cars);
        }
    }
}
