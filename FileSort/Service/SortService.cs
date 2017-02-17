using System;
using System.Collections.Generic;
using System.Linq;
using FileSort.Interface;
using FileSort.Model;

namespace FileSort.Service
{
    class SortService : ISortService
    {

        public List<PersonName> GetSortList(List<PersonName> unsortedList, bool isDescending = false)
        {
        
            if (unsortedList == null)
            {
                throw new ArgumentNullException();
            }

            if (!unsortedList.Any())
            {
                throw new Exception("Empty list can not be sorted");
            }

            var sortedList = isDescending
                ? unsortedList.OrderByDescending(p => p.LastName).ThenByDescending(p => p.FirstName).ToList()
                : unsortedList.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ToList();

            return sortedList;
        }
    }
}
