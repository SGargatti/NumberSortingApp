using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSortingApplication.DomainLayer
{
    public interface INumberSortInterface
    {
        // Interface lets you add more methods for furture implementation
        int[] SortTheInputArray(string[] inputArray);
        int[] ListOfSortedPrimeNumbers(int[] listToSortPrimeNumbers);
    }
}
