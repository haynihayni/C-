using System;

using System.IO;

namespace Laba_1
{
    class Program
    {
        static string Check(string path) // Method checking whether name of file has prohibited marks or whether file is or isn't.
        {
            string nameOfFile = Console.ReadLine();
            while ((nameOfFile.IndexOfAny(Path.GetInvalidFileNameChars()) != -1) || File.Exists(path + nameOfFile + ".dat"))
            {
                Console.WriteLine("You input prohibited marks or file with this name is. Please, try more one");
                nameOfFile = Console.ReadLine();
            }
            return nameOfFile;
        }
        static void CreateAndInputData(string path) // Method create binary file and input integer
        {
            Console.WriteLine("Iput name of file");
            string nameOfFile = Check(path);
            BinaryWriter writer = null;
            try
            {
                writer = new BinaryWriter(new FileStream(path + nameOfFile + ".dat", FileMode.Create));
                Console.WriteLine("Input amount integer in the file");
                int count;           // amount of integer  
                while (!Int32.TryParse(Console.ReadLine(), out count) || count <= 0) // Loop checks whether user input integer and whether integer>0
                {
                    Console.WriteLine("Mean of file isn't less zero or is zero");
                    Console.WriteLine();
                    Console.WriteLine("Input amount integer in the file");
                }
                int integer; // variable for saveing integer
                for (int i = 0; i < count; i++) // Loop fills file integer
                {
                    Console.WriteLine("Input {0} integer", i + 1);
                    while (!Int32.TryParse(Console.ReadLine(), out integer)) // Loop check whether user input an integer
                    {
                        Console.WriteLine("It isn't a integer, try more one");
                        Console.WriteLine("Input {0} integer", i + 1);
                    }
                    writer.Write(integer);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            finally
            {
                writer.Close();
            }
        }
        static string CheckHaving(string path) // Method checks availabillity file
        {
            string nameOfFile = Console.ReadLine();
            while (!File.Exists(path + nameOfFile + ".dat"))
            {
                Console.WriteLine("Sorry, but this file isn't or you input prohibited marks, please repeat your attempt ");
                nameOfFile = Console.ReadLine();
            }
            return nameOfFile;
        }
        static int FindingInterval(string path, out double ariphmetic_mean)// Method finds biggest interval of integer and seek arithmetic mean of interval
        {
            BinaryReader reader = null;
            int p = 1, //length of biggest interval
                i = 1, //i - for save length of interval, while he isn't end;
                k = 4,
                s1 = 0, // s1 - for save sum of interval? while he isn't end, 
                a2;//  for saving next value integer;   
                ariphmetic_mean = 0;
            try
            {
                reader = new BinaryReader(new FileStream(path, FileMode.Open));

                if (reader.BaseStream.Length <= 3)
                {
                    return -1;
                }
                int a1 = reader.ReadInt32(); // Variable for read an integer 
                ariphmetic_mean = s1=a1;
                
                if (reader.BaseStream.Length <= 7)
                {
                    return 1;
                }
                
                while (k < reader.BaseStream.Length - 3) // loop for finding interval
                {
                    a2 = reader.ReadInt32(); // reads next number
                    if (a2 > a1)
                    {
                        s1 += a2;
                        i++; //if condition is true that length of present interval increase          
                    }       
                    else // else we gave first element of new interval
                    {
                        i = 1; // return length of new interval till 1
                        s1 = a2; // retutn length of new interval till 0
                    }
                    if (p < i) // we compare length of present interval and alreasy existing
                    {
                        p = i; ariphmetic_mean = s1;
                    }
                    a1 = a2;
                    k += 4;
                }


                ariphmetic_mean = ariphmetic_mean / p;
            }


            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                reader.Close();
            }
            return p;
        }
        static void Main(string[] args)
        {
            int a;
            int b;
            a = 10 + 11 * 12; b = a / 13 + 14; a = 15 + b % 16;
            Console.WriteLine(a);
            //string path = @"D:\Навчання\ВНЗ\Програмування\Лабораторні\Лаба №1\Laba 1\";
            //try
            //{
            //    CreateAndInputData(path);

            //    Console.WriteLine("Input name of file if you want to read");
            //    string nameOfFile = CheckHaving(path);
            //    int length;
            //    double ariphmetic_mean;
            //    path = path + nameOfFile + ".dat";
            //    length = FindingInterval(path, out ariphmetic_mean);
            //    if (length == -1)
            //    {
            //        Console.WriteLine("File is invalid");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Arighemitic mean {0}\nLength of there interval {1}", ariphmetic_mean, length);
            //    }

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }
    }
}



