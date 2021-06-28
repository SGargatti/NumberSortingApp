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
            int[] primeNumbersList = new int[MaxArrayLength];
            // initialising starting index of array
            int searchStartIndex = 0;


            // Assuming all elements in the input array are prime
            for (int i = 0; i < MaxArrayLength; i++)
                primeNumbersList[i] = 1;

            // Removing 1 as it is neither prime nor composite number if the given array which is sorted has first number as 1
            if (listToSortPrimeNumbers[0] == 1)
            {
                primeNumbersList[0] = 0;
                searchStartIndex = 1;
            }
            //if the first number in array index is not 1 then retaining that as our index number to sort prime numbers
            else if (listToSortPrimeNumbers[0] > 1)
                searchStartIndex = 0;
            // if first value in array is 2 then increment the search index by 1
            if (listToSortPrimeNumbers[searchStartIndex] == 2)
            {
                searchStartIndex = 2;

            }

            // Start iterating through array to make all composite numbers as 0
            for (int i = searchStartIndex; i < Math.Sqrt(MaxArrayLength) + 1; i++)
            {
                if (primeNumbersList[i] == 1)
                {
                    for (int j = i * i; j < MaxArrayLength; j = j + i)
                    {
                        primeNumbersList[j] = 0;
                    }
                }
            }
            //Load the value of prime numbers in the int array defined 
            for (int i = 1; i < MaxArrayLength; i++)
            {
                if (primeNumbersList[i] == 1)
                {
                    primeNumbersList[i] = i;
                }
            }
            return primeNumbersList;
        }
    
        public int[] SortTheInputArray(string[] inputArray)
        {
           // string[] arrayList = new string[] { inputArray };
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
