using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace NumberSortingApplication.DomainLayer
{
    public class NumberSortDomain : INumberSortInterface
    {
        public int[] ListOfSortedPrimeNumbers(int[] listToSortPrimeNumbers)
        {
            // initialising max length in a variable to avaoid using .Length function
            int MaxArrayLength = listToSortPrimeNumbers.Length;
            // array of prime number shall be store here
            int[] sortedNumbersList = new int[MaxArrayLength];
            // initialising starting index of array
            int searchStartIndex = 0;


            // Assuming all elements in the input array are prime
            for (int i = 0; i < MaxArrayLength; i++)
                sortedNumbersList[i] = 1;
                    
            // Start iterating through array to make all composite numbers as 0
            for (int i = 2; i < Math.Sqrt(MaxArrayLength) + 1; i++)
            {
                if (sortedNumbersList[i] == 1)
                {
                    for (int j = i * i; j < MaxArrayLength; j = j + i)
                    {
                        sortedNumbersList[j] = 0;
                    }
                }
            }
            //Load the value of prime numbers in the int array defined 
            for (int i = 1; i < MaxArrayLength; i++)
            {
                if (sortedNumbersList[i] == 0)
                {
                    sortedNumbersList[i] = i;
                }
            }
            return sortedNumbersList;
        }
    
        //Sort the numbers in ascending order in case its jumbled
        public int[] SortTheInputArray(string[] inputArray)
        {
           
           //fetch only numbers from the string input
            string pattern = @"\d+";
            int[] results = new int[inputArray.Length];
            try
            {
                results = inputArray.Select(x => Regex.Match(x, pattern)).Cast<Match>().Select(x => int.Parse(x.Value)).ToArray();
            }
            catch
            {

            }
            Array.Sort(results);
            return results;
        }
    }
}
