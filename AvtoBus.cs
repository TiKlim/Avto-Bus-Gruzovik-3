using Avtomobil3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Avtomobil3
{
    internal class AvtoBus : Avto
    {
        protected double otsihdosih;
        protected int ostanovky;
        protected int mesta;
        protected double topost;
        protected double kilometrdoost;
        protected double kilom;
        protected int ludy;
        //protected double top2;
        public string? Nom { get { return nom; } }
        public AvtoBus() { Menu(cars); }
        public static int metod = 0;
        protected override void Info(List<Avto> cars)
        {
            Console.WriteLine("> Номер машины (А000АА):");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.nom = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            this.bak = 60;
            Console.WriteLine("> Расход топлива (на 100 км):");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.ras = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            if (ras >= (60 / 2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ваш расход топлива катастрофически велик!");
                Console.ForegroundColor = ConsoleColor.White;
                Info(cars);
            }
            Console.WriteLine("> Вместительность:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.mesta = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            this.speed = 0;
            this.top = 0;
            //this.top2 = top;
            this.probeg = 0;
            this.kilometragh = 0;
            this.rasst = 0;
            this.ludy = 0;
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
                Console.WriteLine("> Количество остановок на маршруте: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                this.ostanovky = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                this.dist = 2 * (Math.Round(Math.Sqrt(((koordinataXb - koordinataXa) * (koordinataXb - koordinataXa)) + ((koordinataYb - koordinataYa) * (koordinataYb - koordinataYa)))));
                this.otsihdosih = Math.Round((dist / 2) / ostanovky);
                this.kilometrdoost = dist / 2; //*
                //this.topost = ((otsihdosih * ras) / 100);
                this.kilometragh = Math.Round((top / ras) * 100); //На сколько километров хватит бензина
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Данные сохранены.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Ваш маршрут: {dist / 2}. \nОстановок: {ostanovky}. \nСчастливого пути!");
                this.rasst = 0;
                Menu2(cars);
            }
        }
        protected override void Stop(List<Avto> cars)
        {
            speed = 0;
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
                    //top = top2;
                    speed += 10;
                    Out();
                    Ezda(cars);
                    Menu2(cars);
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
                else if (top <= 0)
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
        }
        protected override void Ezda(List<Avto> cars)
        {
            if (speed > 0) //Если машина в принципе поехала
            {
                if (top > 0)
                {
                    top -= ras; //*
                    //probeg += 100;
                    rasst += 100;
                }
                else if ((top - ras) < 0 & speed > 0)
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
                else if (top < 0)
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
                else if ((top - ras) < topost)
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
            }
            while (probeg <= dist / 2)
            {
                /*if (rasst >= otsihdosih && otsihdosih != 0 && probeg >= dist / 2 && probeg >= otsihdosih * ostanovky) //Для маршрута !!!
                {
                    kilometrdoost = 0;
                    probeg = dist / 2;
                    speed = 0;
                    rasst = 0;
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("АВТОБУС ПРИБЫЛ НА КОНЕЧНУЮ ОСТАНОВКУ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine($"Остаток топлива: {Math.Round(top, 1)} литров.");
                }*/
                if (top < 2 && rasst < dist / 2 && rasst != 0)
                {
                    rasst += kilometragh - 100;
                    top = 0;
                    speed = 0;
                }
                if (rasst >= otsihdosih & otsihdosih != 0) //Для маршрута
                {
                    double a = otsihdosih - rasst;
                    topost = (a * ras) / 100;
                    top -= topost;
                    kilometrdoost -= otsihdosih;
                    //top2 -= topost;
                    probeg += otsihdosih;
                    //double a = rasst - probeg; 
                    //double b = (a * ras) / 100; 
                    //top -= b;
                    speed = 0;
                    rasst = 0;
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("ОСТАНОВКА");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine($"Остаток топлива: {Math.Round(top, 1)} литров.");
                    Console.WriteLine($"Пробег: {Math.Round(probeg)} километров.");
                    Console.WriteLine($"Пассажиры: {ludy}.");
                    Found:
                    Console.WriteLine("Сколько людей вошло?");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    int prihod = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                    if (prihod > mesta || (ludy + prihod) > mesta)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("! МЕСТ НЕТ !");
                        Console.ForegroundColor = ConsoleColor.White;
                        //ludy += mesta;
                        goto Found;

                    }
                    else
                    {
                        ludy += prihod;
                    }
                    /*if ((ludy + prihod) > mesta)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("! МЕСТ НЕТ !");
                        Console.ForegroundColor = ConsoleColor.White;
                        ludy += mesta;
                    }*/
                    Round:
                    Console.WriteLine("Сколько людей вышло?");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    int uhod = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                    if (uhod > mesta || (ludy - uhod) < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("     ! МЁРТВЫХ ДУШ НЕ ВОЗИМ ! \nВ САЛОНЕ НЕТ ТАКОГО КОЛИЧЕСТВА ПАССАЖИРОВ");
                        Console.ForegroundColor = ConsoleColor.White;
                        //ludy -= mesta;
                        goto Round;
                    }
                    else
                    {
                        ludy -= uhod;
                    }
                    if (probeg == dist / 2 || probeg == ostanovky * otsihdosih)
                    {
                        probeg = dist / 2;
                        kilometrdoost = dist / 2;
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("АВТОБУС ПРИБЫЛ НА КОНЕЧНУЮ ОСТАНОВКУ");
                        Console.WriteLine("         обратный маршрут");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                    }
                }
                kilometragh = Math.Round((top / ras) * 100); //На сколько километров хватит бензина
                kilom = Math.Round((bak / ras) * 100);
                //topost = ((otsihdosih * ras) / 100);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("Пройдено:     Километраж до конечной остановки:    Скорость:");
                Console.WriteLine($"\n{rasst}            {kilometrdoost}                                  {speed}");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine($"Ваш маршрут: {dist / 2} километров.");
                if (top == 0 || top <= 0)
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
            while (probeg <= dist && probeg >= dist / 2)
            {
                if (rasst >= kilometrdoost && otsihdosih != 0 && probeg >= dist / 2 && probeg >= dist && probeg >= otsihdosih * ostanovky) //Для маршрута !!!
                {                   
                    kilometrdoost = 0;
                    probeg = dist;
                    /*double a = rasst - probeg;
                    double b = (a * ras) / 100;
                    top -= b;*/
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
                    probeg = 0;
                }
                if (top < 2 && rasst < dist && rasst != 0)
                {
                    probeg += kilometragh - 100;
                    rasst += kilometragh - 100;
                    top = 0;
                    speed = 0;
                }
                if (rasst >= otsihdosih && otsihdosih != 0 && probeg < dist) //Для маршрута
                {
                    if (kilometrdoost > otsihdosih && probeg < dist)
                    {
                        kilometrdoost -= otsihdosih;
                        //top2 -= topost;
                        probeg += otsihdosih;
                        speed = 0;
                        rasst = 0;
                        /*double a = rasst - probeg; 
                        double b = (a * ras) / 100; 
                        top -= b;*/
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("ОСТАНОВКА");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                        Console.WriteLine($"Остаток топлива: {Math.Round(top, 1)} литров.");
                        Console.WriteLine($"Пробег: {Math.Round(probeg)} километров.");
                        Console.WriteLine($"Пассажиры: {ludy}.");
                        Gound:
                        Console.WriteLine("Сколько людей вошло?");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        int prihod = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;
                        if (prihod > mesta || (ludy + prihod) > mesta)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("! МЕСТ НЕТ !");
                            Console.ForegroundColor = ConsoleColor.White;
                            //ludy += mesta;
                            goto Gound;
                        }
                        else
                        {
                            ludy += prihod;
                        }
                        /*if ((ludy + prihod) > mesta)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("! МЕСТ НЕТ !");
                            Console.ForegroundColor = ConsoleColor.White;
                            ludy += mesta;
                        }*/
                        Pound:
                        Console.WriteLine("Сколько людей вышло?");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        int uhod = Convert.ToInt32(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;
                        if (uhod > mesta || (ludy - uhod) < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("     ! МЁРТВЫХ ДУШ НЕ ВОЗИМ ! \nВ САЛОНЕ НЕТ ТАКОГО КОЛИЧЕСТВА ПАССАЖИРОВ");
                            Console.ForegroundColor = ConsoleColor.White;
                            //ludy -= mesta;
                            goto Pound;
                        }
                        else
                        {
                            ludy -= uhod;
                        }
                    }
                    else if (kilometrdoost <= otsihdosih) //*
                    {
                        kilometrdoost -= kilometrdoost;
                        kilometrdoost = 0;
                        probeg = dist;
                        speed = 0;
                        rasst = 0;
                        /*double a = rasst - probeg; 
                        double b = (a * ras) / 100; 
                        top -= b;*/
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("ДЕПО");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                        Console.WriteLine($"Остаток топлива: {Math.Round(top, 1)} литров.");
                        Console.WriteLine($"Пробег: {Math.Round(probeg)} километров.");
                        dist = 0;
                        probeg = 0;
                    }
                    //top -= topost;
                }
                kilometragh = Math.Round((top / ras) * 100); //На сколько километров хватит бензина
                kilom = Math.Round((bak / ras) * 100);
                topost = ((otsihdosih * ras) / 100);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("Пройдено:     Километраж следующей остановки:    Скорость:");
                Console.WriteLine($"\n{rasst}             {kilometrdoost}                                     {speed}");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
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