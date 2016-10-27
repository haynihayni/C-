using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        /// <summary>
        /// Sort array for destination
        /// </summary>
        /// <param name="train"></param>
        public static void Destination(TRAIN[] train)
        {
            string temp;
            for (int i = 0; i < train.Length; ++i)
                for (int j = 0; j < train.Length; ++j)
                    if (train[i].destination.CompareTo(train[j].destination) == 1)
                    {
                        temp = train[i].destination;
                        train[i].destination = train[j].destination;
                        train[j].destination = temp;
                    }
        }
        /// <summary>
        /// Sort array for number of train
        /// </summary>
        /// <param name="train"></param>
        public static void NumberOfTraint(TRAIN[] train)
        {
            int temp;
            for (int i = 0; i < train.Length; ++i)
                for (int j = 0; j < train.Length; ++j)
                    if (train[i].numberOfTrain > train[j].numberOfTrain)
                    {
                        temp = train[i].numberOfTrain;
                        train[i].numberOfTrain = train[j].numberOfTrain;
                        train[j].numberOfTrain = temp;
                    }
        }
        /// <summary>
        /// sort train for departure time
        /// </summary>
        /// <param name="train"></param>
        public static void DepartureTime(TRAIN[] train)
        {
            DateTime temp;
            for (int i = 0; i < train.Length; ++i)
                for (int j = 0; j < train.Length; ++j)
                    if (train[i].departureTime > train[j].departureTime)
                    {
                        temp = train[i].departureTime;
                        train[i].departureTime = train[j].departureTime;
                        train[j].departureTime = temp;
                    }
        }
        /// <summary>
        /// gets train after this time
        /// </summary>
        /// <param name="train"></param>
        /// <param name="time"></param>
        public static void Filtration(TRAIN[] train, DateTime time)
        {
            bool check = true;
            for (int i = 0; i < train.Length; i++)
            {
                if (train[i].departureTime >= time)
                {
                    Console.WriteLine(train[i]);
                    check = false;// tell us that some trains today are
                }
            }
            if (check)
                Console.WriteLine("Today train are not");
        }
        static void Main(string[] args)
        {
            string destination;
            int number, hours, minutes, key;
            TRAIN[] train = new TRAIN[8];
            try
            {
                //for (int i = 0; i < train.Length; i++)
                //{
                //    Console.WriteLine("Enter destination of train");
                //    destination = Console.ReadLine();
                //    Console.WriteLine("Enter number of train");
                //    while (!Int32.TryParse(Console.ReadLine(), out number) || number <= 0)
                //        Console.WriteLine("Number of train is not may to be zero or less zero");
                //    Console.WriteLine("Enter departure time hours");
                //    while (!Int32.TryParse(Console.ReadLine(), out hours) || hours < 0 || hours > 23)
                //        Console.WriteLine("Invalid hours, try more time");
                //    Console.WriteLine("Enter departure time minutes");
                //    while (!Int32.TryParse(Console.ReadLine(), out minutes) || minutes < 0 || minutes > 59)
                //        Console.WriteLine("Invalid minutes, try more time");
                //    train[i] = new TRAIN(destination, number, hours, minutes);
                //}
                Random rand = new Random();
                string[] qwerty = { "Vinnitsa", "Kiev", "Cherkassy", "Lvov", "London", "Singapur", "Dubay" };

                for (int i = 0; i < train.Length; i++)
                {
                    train[i] = new TRAIN(qwerty[rand.Next(qwerty.Length)], 23 - i * 2, 23 - i - 1, 60 - 3 * i - 4);
                }
                foreach (TRAIN tr in train)
                    Console.WriteLine(tr + "\n");
                Console.WriteLine("Enter key for sorting trains:\n1-distination of train\n2-departure time of train\n3-number of train");
                while ((!(Int32.TryParse(Console.ReadLine(), out key))))
                    Console.WriteLine("You have entered fail key for sorting, try more one time");
                switch (key)
                {
                    case 1:
                        Destination(train);
                        break;
                    case 2:
                        DepartureTime(train);
                        break;
                    case 3:
                        NumberOfTraint(train);
                        break;
                }
                Console.WriteLine("Entered departure time of train for view list of train");
                Console.WriteLine("Enter departure time hours");
                while (!Int32.TryParse(Console.ReadLine(), out hours) || hours < 0 || hours > 23)
                    Console.WriteLine("Invalid hours, try more time");
                Console.WriteLine("Enter departure time minutes");
                while (!Int32.TryParse(Console.ReadLine(), out minutes) || minutes < 0 || minutes > 59)
                    Console.WriteLine("Invalid minutes, try more time");
                DepartureTime(train);//sort array for departure time
                DateTime time = new DateTime(2016, 1, 1, hours, minutes, 0);
                Filtration(train, time);

                foreach (TRAIN tr in train)
                    Console.WriteLine(tr + "\n");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    /// <summary>
    /// Contain information about train: destination of train, departure time of train and number of train
    /// </summary>
    struct TRAIN
    {
        public string destination;
        public int numberOfTrain;
        public DateTime departureTime;


        /// <summary>
        /// Initial struct type of TRAIN
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="numberOfTrain"> cannot less 0 or is 0</param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        public TRAIN(string destination, int numberOfTrain, int hours, int minutes)
        {
            departureTime = new DateTime(2016, 1, 1, hours, minutes, 0);
            if (numberOfTrain <= 0)
                throw new ArgumentException("Number of train is not may to be zero or less zero");
            this.numberOfTrain = numberOfTrain;
            this.destination = destination;
        }

        /// <summary>
        /// Give information about this train
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Number of train: " + numberOfTrain + "\nDeparture time of train: " + departureTime + "\nTrain go to: " + destination;
        }

    }
}
