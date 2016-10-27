using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            string destination;
            int number, hours, minutes, key, key2, amountOfElement;
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
                TRAIN_Conteiner.CompareDelegate c;
                Console.WriteLine("Entered amoung element in array");
                while (!Int32.TryParse(Console.ReadLine(), out amountOfElement) || amountOfElement < 0)
                    Console.WriteLine("Invalid const");
                TRAIN_Conteiner train = new TRAIN_Conteiner(amountOfElement);
                for (int i = 0; i < train.LengthTrain; i++)
                    train.AddTrain(new TRAIN(qwerty[rand.Next(qwerty.Length)], rand.Next(1000), rand.Next(24), rand.Next(60)));
                Console.WriteLine("\n" + "NOW YOU HAVE NEXT LIST\n");
                train.View();
                string answer = "";
                do
                {
                    Console.WriteLine("Do you want sort array?(y/n)");
                    answer = Console.ReadLine();
                    if (answer == "y")
                    {
                        Console.WriteLine("ENTER KEY FOR SORTING:\n1-distination of train\n2-departure time of train\n3-number of train\n4-first for destination, second for departure time\n5- first for destination, second for number of train");
                        while ((!(Int32.TryParse(Console.ReadLine(), out key))))
                            Console.WriteLine("You have entered fail key for sorting, try more one time");

                        c = train.DelChange(key);
                        train.Sort(c);
                        train.View();
                    }
                }
                while (answer == "y");
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
        public TRAIN(TRAIN train)
        {
            this.numberOfTrain = train.numberOfTrain;
            this.departureTime = train.departureTime;
            this.destination = train.destination;
        }
        /// <summary>
        /// Initial struct type of TRAIN
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="numberOfTrain"> cannot less 0 or is 0</param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        public TRAIN(string destination, int numberOfTrain, int hours, int minutes)
        {
            if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59)
                throw new ArgumentException("Time is invalid");
            if (numberOfTrain <= 0)
                throw new ArgumentException("Number of train is not may to be zero or less zero");
            this.departureTime = new DateTime(2016, 1, 1, hours, minutes, 0);
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

        /// <summary>
        /// Compares destination of trains
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int CompareForDestination(TRAIN a, TRAIN b)
        {
            return a.destination.CompareTo(b.destination);
        }

        /// <summary>
        /// Compares number of trains
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int CompareForNumberOfTrain(TRAIN a, TRAIN b)
        {
            return a.numberOfTrain.CompareTo(b.numberOfTrain);
        }

        /// <summary>
        /// Compares departure time of trains
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int CompareForDepartureTime(TRAIN a, TRAIN b)
        {
            return a.departureTime.CompareTo(b.departureTime);
        }

        public static int CompareFirstDestinationSecondDepartureTime(TRAIN a, TRAIN b)
        {
            int one_or_zero = CompareForDestination(a, b);
            if (one_or_zero != 0) //if two train the same for destination, method compares for departure time
                return one_or_zero;
            return CompareForDepartureTime(a, b);
        }
        public static int CompareFirstDestinationSecondNumberOfTrain(TRAIN a, TRAIN b)
        {
            int one_or_zero = CompareForDestination(a, b);
            if (one_or_zero != 0) //if two train the same for destination, method compares for number of train
                return one_or_zero;
            return CompareForNumberOfTrain(a, b);
        }
        public TRAIN_Conteiner.CompareDelegate DelDeparture
        {
            get { return CompareForDepartureTime; }
        }
        public TRAIN_Conteiner.CompareDelegate DelDestination
        {
            get { return CompareForDestination; }
        }
        public TRAIN_Conteiner.CompareDelegate DelNumber
        {
            get { return CompareForNumberOfTrain; }
        }
    }

    class TRAIN_Conteiner
    {
        public delegate int CompareDelegate(TRAIN a, TRAIN b);

        /// <summary>
        /// Array that contain of all information about trains
        /// </summary>
        TRAIN[] train;

        int amountInGeneral;

        /// <summary>
        /// Initial train with size 10
        /// </summary>
        public TRAIN_Conteiner(int amountOfElement)
        {
            if (amountOfElement < 0)
                throw new ArgumentException("Index < 0");
            train = new TRAIN[amountOfElement];
            amountInGeneral = 0;
        }

        /// <summary>
        /// Get information about length of train-array
        /// </summary>
        public int LengthTrain { get { return train.Length; } }

        /// <summary>
        /// Allows to change reference of delegate
        /// </summary>
        /// <param name="key">The parametr that determinates reference of delegate</param>
        public TRAIN_Conteiner.CompareDelegate DelChange(int key)
        {
            switch (key)
            {
                case 1:
                    return TRAIN.CompareForDestination;
                case 2:
                    return TRAIN.CompareForDepartureTime;
                case 3:
                    return TRAIN.CompareForNumberOfTrain;
                case 4:
                    return TRAIN.CompareFirstDestinationSecondDepartureTime;
                case 5:
                    return TRAIN.CompareFirstDestinationSecondNumberOfTrain;
                default:
                    throw new ArgumentException("Invalid key for sorting");
            }
        }
        /// <summary>
        /// Sort array of train for one of three way: destination, departure time, number of train
        /// </summary>
        /// <param name="train">Array that contain of all information about trains </param>
        public void Sort(CompareDelegate c)
        {
            TRAIN temp;
            for (int i = 0; i < train.Length; ++i)
                for (int j = i + 1; j < train.Length; ++j)
                    if (c(train[i], train[j]) > 0)
                    {
                        temp = train[i];
                        train[i] = train[j];
                        train[j] = temp;
                    }
        }

        /// <summary>
        /// Allows to review list of all trains
        /// </summary>
        /// <param name="train">Array that contain of all information about trains</param>
        public void View()
        {
            for (int i = 0; i < amountInGeneral; ++i)
                Console.WriteLine(train[i] + "\n");
        }

        /// <summary>
        /// Access to array of trains
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TRAIN this[int index]
        {
            get
            {
                if (index < 0 || index >= amountInGeneral)
                    throw new IndexOutOfRangeException();
                return train[index];
            }
            set
            {
                if (index < 0 || index >= amountInGeneral)
                    throw new IndexOutOfRangeException();
                train[index] = value;
            }
        }

        /// <summary>
        /// Add train to array 
        /// </summary>
        /// <param name="tr"></param>
        public void AddTrain(TRAIN tr)
        {
            if (train.Contains(tr) || train.Length == amountInGeneral) //if in this array same train already exist, then method is not add train to array
                Console.WriteLine("This train also exist or place is not");
            else
            {
                train[amountInGeneral++] = tr;
                Console.WriteLine("Train {0} succesfuly has added", tr.numberOfTrain);
            }

        }
    }
}
