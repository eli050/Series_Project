using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
class Program()
{
    static void Main(string[] args)
    {
        
        void menu()
        {
            List<int> series = new List<int>();
        }

        //Converts a string to a list of strings
        List<string> changeStrToLstr(string str)
        {
            List<string> stringList = new List<string>();
            string[] tempArr = str.Split();
            stringList = tempArr.ToList();
            return stringList;
        }

        bool validationList(List<string> list)

        {
            bool checker = true;
            return checker;
        }

        List<int> changeLStrToLInt(List<string> list)
        {
            List<int> intList = new List<int>();
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
        List<int> reversedList(List<int> listNum)
        {
            List<int> reversList = new List<int>();
            for (int i = countVal(listNum); i > 0; i--)
            {
                reversList.Add(i);
            }
            return reversList;
        }

        List<int> soortedList(List<int> listNum)
        {
            bool checker = true;
            List<int> sortList = new List<int>();
            for (int i = 1; i < countVal(listNum); i++)
            {
                for (int j = 0; j < countVal(listNum) - i ; j++)
                {
                    if (listNum[j] < listNum[j +1])
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

        int avrageValues(List<int> listNum)
        {
            int avr = sumAllVal(listNum) / countVal(listNum);
            return avr;
        }

        int countVal(List<int> listNum)
        {
            int counter = 0;
            foreach (int item in listNum)
            {
                counter++;
            }
            return counter;
        }

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

