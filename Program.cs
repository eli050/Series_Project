using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
class Program()
{
    static void Main(string[] args)
    {
        Menu();

        // Number Series Menu
        void Menu()
        {
            bool notExit = true;
            List<float> series = InputSeries();
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
                        notExit = false;
                        break;
                    
                    default:
                        Console.WriteLine("We don't have an option for this character yet (: Please choose again");
                        break;


                }

            }
            while (notExit);
          
        }

        // Receiving the series of numbers from a user
        List<float> InputSeries()
        {
            List<string> list;
            List<float> input = new List<float>();
            bool validatList = true;
            do
            {
                if (!validatList)
                {
                    Console.WriteLine("One (or more) of the characters you entered is not a number, please enter it again: ");
                }
                else
                {
                    Console.WriteLine("enter a series of number: ");
                }
                
                list = ChangeStrToListStr(Console.ReadLine()!);
                validatList = ValidationList(list);
            }
            while (!validatList);
            input = ChangeListStrToListFloat(list);
            return input;
        }

        //Converts a string to a list of strings
        List<string> ChangeStrToListStr(string str)
        {
            List<string> stringList = new List<string>();
            string[] tempArr = str.Split();
            stringList = tempArr.ToList();
            return stringList;
        }

        // validiton of list
        bool ValidationList(List<string> list)

        {
            return ValidationLen(list) && ValidatListIsPositiveNum(list);
        }

        // Goes through a list of strings and checks
        // that they are all numbers
        bool ValidatListIsPositiveNum(List<string> list)
        {
            bool validatList = true;
            foreach (string str in list)
            {
                if ((!int.TryParse(str, out int value) || value < 0) && (!float.TryParse(str, out float val)|| val < 0))
                {
                    validatList = false; break;
                }
               
            } 
            return validatList;
        }

        // chacking the len of list >= 3
        bool ValidationLen(List<string> list)
        {
            return list.Count >= 3 ;
        }

        


        // Converts a list of strings to a list of numbers
        List<float> ChangeListStrToListFloat(List<string> list)
        {
            List<float> floatList = new List<float>();
            foreach (string str in list)
            {
                floatList.Add(float.Parse(str));
            }
            return floatList;
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
        void PrintVal(List<float> listNum)
        {
            foreach (float item in listNum)
            {
                Console.WriteLine(item);
            }
        }

        // Returns the same list in reverse
        List<float> ReversedList(List<float> listNum)
        {
            List<float> reversList = new List<float>();
            for (int i = countVal(listNum) - 1; i >= 0 ; i--)
            {
                reversList.Add(listNum[i]);
            }
            return reversList;
        }

        // Returns a sorted list
        List<float> SortedList(List<float> listNum)
        {
            bool isSorted = true;
            List<float> sortList = new List<float>();
            for (int i = 1; i < countVal(listNum); i++)
            {
                for (int j = 0; j < countVal(listNum) - i ; j++)
                {
                    if (listNum[j] > listNum[j +1])
                    {
                        float temp = listNum[j];
                        listNum[j] = listNum[j + 1];
                        listNum[j + 1] = temp;
                        isSorted = false;

                    }
                }
                if (isSorted)
                {
                    return listNum;
                }
            }
            return listNum;
        }

        // Returns the max number in a list.
        float MaxVal(List<float> listNum)
        {
            float max = listNum[0];
            for (int i = 1; i < countVal(listNum); i++)
            {
                if (listNum[i] > max)
                    max = listNum[i];
            }
            return max;

        }

        // Returns the min number in a list.
        float MinVal(List<float> listNum)
        {
            float min = listNum[0];
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
        float AvrageValues(List<float> listNum)
        {
            float avr = SumAllVal(listNum) / countVal(listNum);
            return avr;
        }

        // Counts the number of elements in a list.
        int countVal(List<float> listNum)
        {
            int counter = 0;
            foreach (float _ in listNum)
            {
                counter++;
            }
            return counter;
        }

        // Sums the sum of all elements in a list
        float SumAllVal(List<float> listNum)
        {   
            float sum = 0;
            foreach(float num in listNum)
            {
                sum += num;
            }
            return sum;
        }




    }

}

