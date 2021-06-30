using NumberSortingApplication.DomainLayer;
using System;


namespace NumberSortingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // User input to type in the data
            Console.WriteLine("Input a range of comma separated numbers to fetch primenumbers");
            //Receiving the user input as string          
            string inputArray= (Console.ReadLine());
            string[] userInputs = inputArray.Split(',');
          

            //Sort the input array so that it is easy to implemen Sieve of erthsoneans algorithm to fetch prime numbers
            int[] sortedInput = new int[inputArray.Length];
            NumberSortDomain numberSort = new NumberSortDomain();
            sortedInput=numberSort.SortTheInputArray(userInputs);


            //Now fetch the primenumbers from the sorted list
            int[] listOfNonPrimeNumbers = new int[sortedInput.Length];
            listOfNonPrimeNumbers = numberSort.ListOfSortedPrimeNumbers(sortedInput);
            foreach (var item in listOfNonPrimeNumbers)
            {
                if(item!=1)
                Console.WriteLine(item.ToString());
                Console.ReadKey();
            }
           


           
        }
    }
}
