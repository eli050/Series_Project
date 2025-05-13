using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
class Program()
{
    static void Main(string[] args)
    {
        menu();

        void menu()
        {
            bool checker = true;
            List<int> series = inputSeries();
            do
            {
                printMenu();
                string choice = Console.ReadLine()!;
                switch (choice)
                {
                    case "a":
                        series = inputSeries();
                        break;

                    case "b":
                        printVal(series);
                        break;

                    case "c":
                        printVal(reversedList(series));
                        break;

                    case "d":
                        printVal(sortedList(series));
                        break;

                    case "e":
                        Console.WriteLine(maxVal(series));
                        break;

                    case "f":
                        Console.WriteLine(minVal(series));
                        break;

                    case "g":
                        Console.WriteLine(avrageValues(series));
                        break;

                    case "h":
                        Console.WriteLine(countVal(series));
                        break;

                    case "i":
                        Console.WriteLine(sumAllVal(series));
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
        List<int> inputSeries()
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
                
                list = changeStrToLstr(Console.ReadLine()!);
                checker = validationList(list);
            }
            while (!checker);
            input = changeLStrToLInt(list);
            return input;
        }

        //Converts a string to a list of strings
        List<string> changeStrToLstr(string str)
        {
            List<string> stringList = new List<string>();
            string[] tempArr = str.Split();
            stringList = tempArr.ToList();
            return stringList;
        }

        // Goes through a list of strings and checks
        // that they are all numbers
        bool validationList(List<string> list)

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
        List<int> changeLStrToLInt(List<string> list)
        {
            List<int> intList = new List<int>();
            foreach (string str in list)
            {
                intList.Add(int.Parse(str));
            }
            return intList;
        }

        // Prints the menu
        void printMenu()
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
        void printVal(List<int> listNum)
        {
            foreach (int item in listNum)
            {
                Console.WriteLine(item);
            }
        }

        // Returns the same list in reverse
        List<int> reversedList(List<int> listNum)
        {
            List<int> reversList = new List<int>();
            for (int i = countVal(listNum) - 1; i > -1 ; i--)
            {
                reversList.Add(listNum[i]);
            }
            return reversList;
        }

        // Returns a sorted list
        List<int> sortedList(List<int> listNum)
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
        int maxVal(List<int> listNum)
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
        int minVal(List<int> listNum)
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
        int avrageValues(List<int> listNum)
        {
            int avr = sumAllVal(listNum) / countVal(listNum);
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
        int sumAllVal(List<int> listNum)
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

