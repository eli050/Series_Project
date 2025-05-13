using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
class Program()
{
    static void Main(string[] args)
    {
        Menu();

        void Menu()
        {
            bool checker = true;
            List<int> series = InputSeries();
            do
            {
                PrintMenu();
                string choice = Console.ReadLine()!;
                switch (choice)
                {
                    case "a":
                        series = InputSeries();
                        break;

                    case "b":
                        PrintVal(series);
                        break;

                    case "c":
                        PrintVal(ReversedList(series));
                        break;

                    case "d":
                        PrintVal(SortedList(series));
                        break;

                    case "e":
                        Console.WriteLine(MaxVal(series));
                        break;

                    case "f":
                        Console.WriteLine(MinVal(series));
                        break;

                    case "g":
                        Console.WriteLine(AvrageValues(series));
                        break;

                    case "h":
                        Console.WriteLine(countVal(series));
                        break;

                    case "i":
                        Console.WriteLine(SumAllVal(series));
                        break;

                    case "j":
                        checker = false;
                        break;
                    
                    default:
                        Console.WriteLine("We don't have an option for this character yet (: Please choose again");
                        break;


                }

            }
            while (checker);
          
        }

        // Receiving the series of numbers from a user
        List<int> InputSeries()
        {
            List<string> list;
            List<int> input = new List<int>();
            bool checker = true;
            do
            {
                if (!checker)
                {
                    Console.WriteLine("One (or more) of the characters you entered is not a number, please enter it again: ");
                }
                else
                {
                    Console.WriteLine("enter a series of number: ");
                }
                
                list = ChangeStrToLstr(Console.ReadLine()!);
                checker = ValidationList(list);
            }
            while (!checker);
            input = ChangeLStrToLInt(list);
            return input;
        }

        //Converts a string to a list of strings
        List<string> ChangeStrToLstr(string str)
        {
            List<string> stringList = new List<string>();
            string[] tempArr = str.Split();
            stringList = tempArr.ToList();
            return stringList;
        }

        // Goes through a list of strings and checks
        // that they are all numbers
        bool ValidationList(List<string> list)

        {
            bool checker = true;
            foreach (string str in list)
            {
                if (!int.TryParse(str, out int value))
                {
                    checker = false; break;
                }
            }
            return checker;
        }

        // Converts a list of strings to a list of numbers
        List<int> ChangeLStrToLInt(List<string> list)
        {
            List<int> intList = new List<int>();
            foreach (string str in list)
            {
                intList.Add(int.Parse(str));
            }
            return intList;
        }

        // Prints the menu
        void PrintMenu()
        {
            Console.WriteLine("Select one of the following options:\n" +
                "a. Enter a new series of numbers (separate each number with a space)" +
                "\nb. Print the current series of numbers" +
                "\nc. Print the current series of numbers in reverse" +
                "\nd. Print the current series of numbers sorted " +
                "\ne. Print the highest value in the current series of numbers" +
                "\nf. Print the lowest value in the current series of numbers" +
                "\ng. Print the average of the current series of numbers" +
                "\nh. Print the number of numbers in the series" +
                "\ni. Print the sum of the total elements in the series" +
                "\nj. Exit");
        }

        // Prints all elements in a list.
        void PrintVal(List<int> listNum)
        {
            foreach (int item in listNum)
            {
                Console.WriteLine(item);
            }
        }

        // Returns the same list in reverse
        List<int> ReversedList(List<int> listNum)
        {
            List<int> reversList = new List<int>();
            for (int i = countVal(listNum) - 1; i > -1 ; i--)
            {
                reversList.Add(listNum[i]);
            }
            return reversList;
        }

        // Returns a sorted list
        List<int> SortedList(List<int> listNum)
        {
            bool checker = true;
            List<int> sortList = new List<int>();
            for (int i = 1; i < countVal(listNum); i++)
            {
                for (int j = 0; j < countVal(listNum) - i ; j++)
                {
                    if (listNum[j] > listNum[j +1])
                    {
                        int temp = listNum[j];
                        listNum[j] = listNum[j + 1];
                        listNum[j + 1] = temp;
                        checker = false;

                    }
                }
                if (checker)
                {
                    return listNum;
                }
            }
            return listNum;
        }

        // Returns the max number in a list.
        int MaxVal(List<int> listNum)
        {
            int max = listNum[0];
            for (int i = 1; i < countVal(listNum); i++)
            {
                if (listNum[i] > max)
                    max = listNum[i];
            }
            return max;

        }

        // Returns the min number in a list.
        int MinVal(List<int> listNum)
        {
            int min = listNum[0];
            for (int i = 1; i < countVal(listNum); i++)
            {
                if (listNum[i] < min)
                {
                    min = listNum[i];
                }
            }
            return min;
        }

        // Returns the average of the numbers in a list.
        int AvrageValues(List<int> listNum)
        {
            int avr = SumAllVal(listNum) / countVal(listNum);
            return avr;
        }

        // Counts the number of elements in a list.
        int countVal(List<int> listNum)
        {
            int counter = 0;
            foreach (int _ in listNum)
            {
                counter++;
            }
            return counter;
        }

        // Sums the sum of all elements in a list
        int SumAllVal(List<int> listNum)
        {   
            int sum = 0;
            foreach(int num in listNum)
            {
                sum += num;
            }
            return sum;
        }




    }

}

