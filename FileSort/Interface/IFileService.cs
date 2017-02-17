using System.Collections.Generic;
using FileSort.Model;

namespace FileSort.Interface
{
   public interface  IFileService
   {
        /// <summary>
        /// Reads file and generates a list of Person Names
        /// </summary>
        /// <param name="file"></param>
        /// <returns>list of Person Names from file</returns>
        List<PersonName> GetNamesFromFile(string file);

        /// <summary>
        /// Writes the list of Persons in Last Name, First Name format to specified file name
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="personList"></param>
        /// <returns>output file name</returns>
        string WriteToFile(string fileName, List<PersonName> personList);
   }
}
