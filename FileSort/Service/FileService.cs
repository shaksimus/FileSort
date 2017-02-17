using System;
using System.Collections.Generic;
using System.IO;
using FileSort.Interface;
using FileSort.Model;

namespace FileSort.Service
{
    class FileService : IFileService
    {



        public List<PersonName> GetNamesFromFile(string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException();
            }

            var lines = File.ReadAllLines(file);

            var personList = new List<PersonName>();

            foreach (var line in lines)
            {
                var names = line.Split(',');
                if (names.Length > 3)
                {
                    throw new Exception("Invalid Name format in File");
                }
                personList.Add(new PersonName() {FirstName = names[1].Trim() , LastName = names[0].Trim()});

            }

            return personList;
        }



        public string WriteToFile(string fileName, List<PersonName> personList)
        {

            var fileNames = fileName.Split('.');
            var outputFile = fileNames[0] + "-sorted." + fileNames[1];

            if (personList == null || personList.Count == 0)
            {
                throw new Exception("Name List is empty");
            }
           

            using (var fileStreamWriter = new System.IO.StreamWriter(outputFile))
            {
                //TODO: clear existing file if exists
                personList.ForEach(p =>
                {
                    fileStreamWriter.WriteLine(p.LastName + ", " + p.FirstName);
                    
                });

            }

            return outputFile;
        }
        
    }
}
