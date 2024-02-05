namespace Avtomobil3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Avto.cars = new List<Avto>();
            Console.WriteLine("> Доброго времени суток.");
            Avtosalon.Menu3(Avto.cars);
        }
    }
}