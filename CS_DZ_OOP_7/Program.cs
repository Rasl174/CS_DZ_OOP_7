using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DZ_OOP_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Administration administration = new Administration();
            administration.Work();
        }
    }

    class Administration
    {
        public void Work()
        {
            Route route = new Route();
            Passengers passengers = new Passengers();
            Train train = new Train();

            bool isWork = true;

            Console.WriteLine("Программа администрирование поездов.");

            while (isWork)
            {
                route.CreateRoute();
                passengers.SellTicketsPassengers();
                train.GetTrain(passengers);
                train.SendTrain(route, passengers, train);
            }
        }
    }

    class Route
    {
        public string Name { get; private set; }

        public void CreateRoute()
        {
            Console.Write("Введите направление: ");
            Name = Console.ReadLine();
        }
    }

    class Passengers
    {
        public int Count { get; private set; }

        public void SellTicketsPassengers()
        {
            Random random = new Random();
            Count = random.Next(20, 400);
            Console.WriteLine("На это направление продано - " + Count + " билетов");
        }
    }

    class Train
    {
        public int WagonsCount { get; private set; }

        public int WagonCapacity { get; private set; }

        public void GetTrain(Passengers passengers)
        {
            WagonsCount = 1;
            Console.Write("Введите вместимость одного вагона не мение 10 и не больше 50: ");
            bool correctInput = false;

            while(correctInput == false)
            {
                if(int.TryParse(Console.ReadLine(), out int userinput) && userinput >= 10 && userinput <= 50)
                {
                    correctInput = true;
                    WagonCapacity = userinput;
                }
                else
                {
                    Console.WriteLine("Не верный ввод повторите попытку!");
                }
            }

            WagonsCount += passengers.Count / WagonCapacity;
            Console.WriteLine("Сформирован поезд с количеством вагонов - " + WagonsCount);
        }

        public void SendTrain(Route route, Passengers passengers, Train train)
        {
            Console.WriteLine("Поезд - " + route.Name + " с пассажирами в количестве - " + passengers.Count + " человек и составом из " + train.WagonsCount + " вагонов отправлен!");
        }
    }
}
