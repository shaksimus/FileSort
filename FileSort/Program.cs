using System;
using System.IO;
using FileSort.Interface;

namespace FileSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Error : Missing File Name. Please provide file name.");
                return;
            }

            Bootstrap.Register();

            var fileService = TinyIoC.TinyIoCContainer.Current.Resolve<IFileService>();
            var sortService = TinyIoC.TinyIoCContainer.Current.Resolve<ISortService>();


            if (!File.Exists(args[0]))
            {
                Console.WriteLine("File Does Not Exist");
            }

            var fileName = args[0];

            try
            {
                var inputList = fileService.GetNamesFromFile(fileName);

                var sortedList = sortService.GetSortList(inputList);
                
                var outputFile = fileService.WriteToFile(fileName, sortedList);

                sortedList.ForEach(p =>
                {
                    Console.WriteLine($"{p.LastName},{p.FirstName}");
                });

                Console.WriteLine($"Finished: created {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
