using System.Collections.Generic;
using FileSort.Model;

namespace FileSort.Interface
{
    public interface ISortService
    {
        /// <summary>
        /// Sorts the List of PersonName objects in the direction specified
        /// </summary>
        /// <param name="unsortedList"></param>
        /// <param name="isDescending"></param>
        /// <returns>Sorted List of Person Names</returns>
        List<PersonName> GetSortList(List<PersonName> unsortedList, bool isDescending = false);
    }
}
