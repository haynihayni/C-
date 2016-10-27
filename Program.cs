using System;
using System.Text;
using System.IO;

namespace Laba_1._2
{
    class Program
    {
        static string Check(string path)// Method checks whether name of file contains prohibited marks and whether file with this name is or isn't
        {
            Console.WriteLine("Введіть назву файла");
            string nameOfFile = Console.ReadLine();

            while (!File.Exists(path + nameOfFile + ".txt"))
            {
                {
                    Console.WriteLine("Ви ввели недозволений символ або файл, з такою назвою, не існує. Спробуйте, будь ласка, ще раз");
                    nameOfFile = Console.ReadLine();
                }
            }
            return nameOfFile;
        }
        static string Comparing(string path) //Method finds line has biggest different words
        {
            StreamReader reader = null;
            string general = "";// variable for save value line
            int q; // counts different words in present line
            int z = 0;//for aссess till variable, that has line with biggest different words
            string biggest = ""; // saves line, that has biggest different words
            try
            {
                reader = new StreamReader(path, Encoding.Default);
                char[] symbol = new char[] { ',', '.', '!', '?', '-', '"', ' ', ':', ';' };// symbols is divide line on substrings
                general = reader.ReadLine();
                string[] subreader;
                while (general != null)
                {
                    subreader = general.Split(symbol, StringSplitOptions.RemoveEmptyEntries);//creating array, elements is substrings of line that divided symbols, that given in parameters of methods Split
                    q = subreader.Length; // amount of biggest  possible different  words
                    for (int i = 0; i < subreader.Length; i++)    //compares every words                                                  
                    {
                        for (int k = i + 1; k < subreader.Length; k++)
                        {
                            if (subreader[i] == subreader[k])
                            {
                                q--;
                                break;// if loop finds the same words, then amount of biggest possible different words decrease
                            }
                        }
                    }
                    if (z < q) // loop compares amount of different  words of present string and already existing
                    {
                        z = q;
                        biggest = general;
                    }
                    general = reader.ReadLine();
                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                reader.Close();
            }
            return biggest;
        }

        static void Main(string[] args)
        {
            try
            {

                string path = @"D:\Навчання\ВНЗ\Програмування\Лабораторні\Лаба №1\Laba 1.2\";
                string nameOffile = Check(path);
                path = path + nameOffile + ".txt";
                string biggest = Comparing(path);
                Console.WriteLine(biggest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
