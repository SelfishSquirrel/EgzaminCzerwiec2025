using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace Program
{
    class MainProgramm
    {
        //static void FillArrayWithRandomSymbols(ref List<char> FillArray, ref List<char> FromArray, int Amount)
        //{
        //    var random = new Random();

        //    for (int i = 0; i < Amount; i++)
        //    {
        //        int RandomIndex = random.Next(0, FromArray.Count);
        //        char symbol = FromArray[RandomIndex];
        //        FillArray.Add(symbol);
        //    }
        //}
        //static string GetPassword()
        //{
        //    var random = new Random();
        //    string password = String.Empty;

        //    List<char> smallSymbols = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        //    List<char> bigSymbols = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        //    List<char> specialSymbols = new List<char> { 'ą', 'ę', 'ł', 'ń', 'ó', 'ś', 'ż', 'ź', 'Ą', 'Ę', 'Ł', 'Ń', 'Ó', 'Ś', 'Ż', 'Ź' };
        //    List<char> numbers = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        //    List<char> uniqueSymbols = new List<char> { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+' };

        //    List<char> small_3 = new List<char>(3);
        //    List<char> big_3 = new List<char>(3);
        //    List<char> special_2 = new List<char>(2);
        //    List<char> numbers_2 = new List<char>(2);
        //    List<char> unique_2 = new List<char>(2);

        //    FillArrayWithRandomSymbols(ref small_3, ref smallSymbols, 3);
        //    FillArrayWithRandomSymbols(ref big_3, ref bigSymbols, 3);
        //    FillArrayWithRandomSymbols(ref special_2, ref specialSymbols, 2);
        //    FillArrayWithRandomSymbols(ref numbers_2, ref numbers, 2);
        //    FillArrayWithRandomSymbols(ref unique_2, ref uniqueSymbols, 2);

        //    List<char> AllSymbols = new List<char>();
        //    AllSymbols.AddRange(small_3);
        //    AllSymbols.AddRange(big_3);
        //    AllSymbols.AddRange(special_2);
        //    AllSymbols.AddRange(numbers_2);
        //    AllSymbols.AddRange(unique_2);

        //    while(AllSymbols.Count > 0)
        //    {
        //        int RandomIndex = random.Next(0, AllSymbols.Count);
        //        char Symbol = AllSymbols[RandomIndex];
        //        AllSymbols.Remove(Symbol);
        //        password += Symbol;
        //    }
        //    return password;
        //}

        static List<HashSet<int>> GenerateHashSets(int Amount, Random Generator)
        {
           List<HashSet<int>> Losowania = new List<HashSet<int>>();

            for (int i = 0; i < Amount; i++)
            {
                HashSet<int> set = new HashSet<int>();

                while (set.Count < 6)
                {
                    int randomNumber = Generator.Next(1, 49);
                    set.Add(randomNumber);
                }

                Losowania.Add(set);
            }


            return Losowania;
        }

        static void PrintGeneratedNumsHashSet(List<HashSet<int>> Losowania)
        {
            for(int i = 0; i < Losowania.Count; i++)
            {
                HashSet<int> set = Losowania[i];

                int j = i + 1;

                Console.Write($"Losowanie {j}: ");
                Console.WriteLine(string.Join(" ", set));
            }
        }

        static int DoesSetHasNumber(int number, List<HashSet<int>> Losowania)
        {
            int liczbaWystapien = 0;
            foreach(var set in Losowania)
            {
               if(set.Contains(number))
               {
                 liczbaWystapien++;
               }
            }

            return liczbaWystapien;
        }


        static void PrintLiczbaWystapien(List<HashSet<int>> Losowania)
        {
            for(int i = 1; i <= 49; i++)
            {
                int liczbaWyst = DoesSetHasNumber(i, Losowania);
                Console.WriteLine($"Wystapienie liczby {i}: {liczbaWyst}");
            }
        }
        static void Main(string[] args)
        {
            //string password = String.Empty;

            //password = GetPassword();
            //Console.WriteLine(password);

            Random random = new Random();
            int liczbaLosowan = 0;

            Console.WriteLine("Ile wygenerowac losowan?");
            liczbaLosowan = Int32.Parse(Console.ReadLine());

            var Losowania = GenerateHashSets(liczbaLosowan, random);
            Console.WriteLine("Zestawy wylosowanych liczb:");
            PrintGeneratedNumsHashSet(Losowania);
            PrintLiczbaWystapien(Losowania);

        } 
    };
};