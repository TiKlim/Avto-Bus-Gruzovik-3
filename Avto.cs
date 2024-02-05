using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtomobil3
{
    internal class Avto
    {
        protected string? nom; //Номер машины
        protected float bak; //Объём бака
        protected float ras; //Расход топлива
        protected int speed; //Скорость
        protected double top; //Текущее количество бензина
        protected double probeg; //Пробег
        protected double kilometragh; //На сколько километров хватит топлива
        protected double rasst; //Расстояние
        protected int koordinataXa; //Координата X начальная
        protected int koordinataYa; //Координата Y начальная
        protected int koordinataXb; //Координата X конечная
        protected int koordinataYb; //Координата Y конечная
        protected double dist; //Дистанция
        protected int type; //Тип машины
        protected double top2;
        static public List<Avto> cars;
        public string? Nom { get { return nom; } }
        public Avto() { }
        public Avto(int a) { Menu(cars); }
        protected virtual void Info(List<Avto> cars) //Информация об автомобиле
        {
            Console.WriteLine("> Номер машины (А000АА):");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.nom = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            this.bak = 55;
            Console.WriteLine("> Расход топлива (на 100 км):");
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.ras = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            if (ras >= (55 / 2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ваш расход топлива катастрофически велик!");
                Console.ForegroundColor = ConsoleColor.White;
                Info(cars);
            }
            this.speed = 0;
            this.top = 0;
            this.probeg = 0;
            this.kilometragh = 0;
            this.rasst = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Данные сохранены.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        protected virtual void Info2(List<Avto> cars)
        {
            speed = 0;
            Console.WriteLine("'Моя поездка'");
            Console.WriteLine("> Введите координаты Вашего путешествия:");
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
            this.dist = Math.Round(Math.Sqrt(((koordinataXb - koordinataXa) * (koordinataXb - koordinataXa)) + ((koordinataYb - koordinataYa) * (koordinataYb - koordinataYa))));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Данные сохранены.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Ваша цель поездки: {dist}. Счастливого пути!");
            this.rasst = 0;
            Menu2(cars);
        }
        protected virtual void Stop(List<Avto> cars) //Торможение
        {
            speed = 0;
            rasst = 0;
            Out();
            Ezda(cars);
            Menu2(cars);
        }
        protected virtual void Razgon(List<Avto> cars) //Разгон
        {
            if (dist == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("! Цель поездки не задана !");
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
        protected double Zapravka(List<Avto> cars) //Заправка
        {
            Console.WriteLine($"> Сколько литров Вы бы хотели заправить в бак? (ОБЪЁМ ВАШЕГО БАКА: {bak}, СЕЙЧАС УРОВЕНЬ ТОПЛИВА: {top}).");
            Console.ForegroundColor = ConsoleColor.Cyan;
            double zap = Convert.ToDouble(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            if ((top + zap) <= bak) //Условие на случай переполнения бака
            {
                top += zap;
                //top2 += zap;
                Console.WriteLine($"Бак заправлен. Сейчас: {top} литров.");
                //speed += 10;
                Menu2(cars);
            }
            else if ((top + zap) > bak)
            {
                top = bak;
                //top2 = bak;
                Console.WriteLine($"Бак заправлен. Сейчас: {top} литров.");
                Menu2(cars);
            }
            /*else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("! Бак переполнен !");
                Console.ForegroundColor = ConsoleColor.White;
                Menu2(cars);
            }*/
            return top;
        }
        protected virtual void Ezda(List<Avto> cars)
        {
            if (speed > 0) //Если машина в принципе поехала
            {
                if (top > 0)
                {
                    top -= ras;
                    probeg += 100;
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
            if (rasst >= dist & dist != 0) //Для цели поездки
            {
                double v = dist - (rasst - 100);
                top = (v * ras) / 100;
                probeg += v - 100;
                speed = 0;
                dist = 0;
                rasst = 0;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ура! Вы преодолели свою цель поездки!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Хотите задать ещё одну? Обратитесь в соответствующую вкладку меню.");
                Menu2(cars);
            }
            if (top < 2 && rasst < dist && rasst != 0)
            {
                probeg += kilometragh - 100;
                rasst += kilometragh - 100;
                top = 0;
                speed = 0;
            }
            kilometragh = Math.Round((top / ras) * 100); //На сколько километров хватит бензина
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Пройдено:     Пробег:      Остаток топлива:      Километраж при текущем уровне бензина в баке:    Скорость:");
            Console.WriteLine($"\n{rasst}             {probeg}            {top}                     {kilometragh}                                            {speed}");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine($"Ваша цель поездки: {dist} километров.");
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
        protected virtual void Out()
        {

            if (top < 2)
            {
                speed = 0;
            }
            Console.WriteLine($"Номер авто: {nom} \nОбъём бака: {bak} \nРасход топлива (на 100 км): {ras}");
        }
        protected virtual void Menu(List<Avto> cars)
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
        public virtual void Menu2(List<Avto> cars)
        {
            Console.WriteLine("> Бортовое меню:\n1 - Изменить Вашу цель поездки; 2 - Разогнаться; 3 - Тормозить; 4 - Заправиться; 5 - Выход в меню автомобилей; 6 - Авария.");
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
        protected virtual void Avaria(List<Avto> cars) //Авария
        {
            if (cars.Count == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Аварии не случилось.");
                Console.WriteLine("Ваша машина единственная на трассе) ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (cars.Count > 1)
            {
                for (int i = 0; i < cars.Count; i++) //Для одного участника движения ...
                {
                    for (int j = 0; j < cars.Count; j++) //...и для другого
                    {
                        if (i != j)
                        {
                            if (cars[i].koordinataXa == cars[j].koordinataXa && cars[i].koordinataYa == cars[j].koordinataYa) //Если начальные координаты обоих совпадают, то 
                            {
                                if (cars[i].dist < cars[j].dist)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("! ВОЗМОЖНА АВАРИЯ !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Aвтомобиль сопрекоснулся с другим автомобилем на участке, равном {cars[i].dist} км.");
                                    Console.WriteLine("");
                                    Menu2(cars);
                                }
                                else if (cars[j].dist < cars[i].dist)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("! ВОЗМОЖНА АВАРИЯ !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Aвтомобиль сопрекоснулся с другим автомобилем на участке, равном {cars[j].dist} км.");
                                    Console.WriteLine("");
                                    Menu2(cars);
                                }
                            }
                            else if (cars[i].koordinataXb == cars[j].koordinataXb && cars[i].koordinataYb == cars[j].koordinataYb) //Если начальные координаты обоих совпадают, то 
                            {
                                if (cars[i].dist < cars[j].dist)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("! ВОЗМОЖНА АВАРИЯ !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Aвтомобиль сопрекоснулся с другим автомобилем на участке, равном {cars[i].dist} км.");
                                    Console.WriteLine("");
                                    Menu2(cars);
                                }
                                else if (cars[j].dist < cars[i].dist)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("! ВОЗМОЖНА АВАРИЯ !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Aвтомобиль сопрекоснулся с другим автомобилем на участке, равном {cars[j].dist} км.");
                                    Console.WriteLine("");
                                    Menu2(cars);
                                }
                            }
                            if ((cars[i].koordinataXa < cars[j].koordinataXa && cars[i].koordinataYa < cars[j].koordinataYa) && (cars[i].koordinataXb > cars[j].koordinataXb && cars[i].koordinataYb > cars[j].koordinataYb))
                            {
                                if (cars[i].dist < cars[j].dist)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("! ВОЗМОЖНА АВАРИЯ !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Aвтомобиль сопрекоснулся с другим автомобилем на участке, равном {cars[i].dist} км.");
                                    Console.WriteLine("");
                                    Menu2(cars);
                                }
                                else if (cars[j].dist < cars[i].dist)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("! ВОЗМОЖНА АВАРИЯ !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Aвтомобиль сопрекоснулся с другим автомобилем на участке, равном {cars[j].dist} км.");
                                    Console.WriteLine("");
                                    Menu2(cars);
                                }
                            }
                            else if ((cars[i].koordinataXa > cars[j].koordinataXa && cars[i].koordinataYa > cars[j].koordinataYa) && (cars[i].koordinataXb < cars[j].koordinataXb && cars[i].koordinataYb < cars[j].koordinataYb))
                            {
                                if (cars[i].dist < cars[j].dist)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("! ВОЗМОЖНА АВАРИЯ !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Aвтомобиль может сопрекоснуться с другим автомобилем на участке, равном {cars[i].dist} км.");
                                    Console.WriteLine("");
                                    Menu2(cars);
                                }
                                else if (cars[j].dist < cars[i].dist)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("! ВОЗМОЖНА АВАРИЯ !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine($"Aвтомобиль может сопрекоснуться с другим автомобилем на участке, равном {cars[j].dist} км.");
                                    Console.WriteLine("");
                                    Menu2(cars);
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Аварии не случилось.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("");
                                Menu2(cars);
                            }
                        }
                    }
                }
            }
        }
    }
}
