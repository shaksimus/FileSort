using System;
using System.Collections.Generic;
using System.IO;
using FileSort.Interface;
using FileSort.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileSort.Tests
{
    [TestClass]
    public class FileServiceTest
    {
        private IFileService _fileService;
        private string validDataFile = "TestData\\ValidTestData.txt";
        private string invalidDataFile = "TestData\\InValidTestData.txt";

        [TestInitialize]
        public void Setup()
        {
            Bootstrap.Register();
            _fileService = TinyIoC.TinyIoCContainer.Current.Resolve<IFileService>();
        }



        #region File Read Tests
        [TestMethod]
        public void Get_Person_Name_List_From_Valid_File_Then_Returns_List()
        {
            //Act
            var result = _fileService.GetNamesFromFile(validDataFile);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count,3);
        }


        [TestMethod]
        public void Get_Person_Name_List_From_InValid_File_Throws_Exception()
        {
            //Act
            try
            {
                var result = _fileService.GetNamesFromFile(invalidDataFile);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsNotNull(ex);
                Assert.AreEqual(ex.Message, "Invalid Name format in File");

            }
        }


        [TestMethod]
        public void Get_Person_Name_List_From_Unavailable_File_Throws_File_Not_Found_Exception()
        {
            //Act
            try
            {
                var result = _fileService.GetNamesFromFile("TestData\\404.txt");
            }
            catch (Exception ex)
            {
                //Assert
                var assertException = ex as FileNotFoundException;
            
                Assert.IsNotNull(ex);
                Assert.IsNotNull(assertException);
                Assert.AreEqual(ex.Message, assertException.Message);

            }
        }

        #endregion

        #region File Write Tests

        [TestMethod]
        public void Write_File_From_Valid_List_Then_Pass()
        {
            //Arrange
            var listPerson = _fileService.GetNamesFromFile(validDataFile);


            //Act
            var outputFile = _fileService.WriteToFile(validDataFile, listPerson);
            var result = _fileService.GetNamesFromFile(outputFile);


            //Assert
            Assert.IsNotNull(result);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(listPerson[i].FirstName, result[i].FirstName);
                Assert.AreEqual(listPerson[i].LastName, result[i].LastName);
            }

           
        }

        [TestMethod]
        public void Write_File_From_Empty_List_Throw_Exception()
        {

            //Act
            try
            {
               var outputFile = _fileService.WriteToFile(validDataFile,new List<PersonName>());
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsNotNull(ex);
                Assert.AreEqual(ex.Message, "Name List is empty");

            }
        }

        [TestMethod]
        public void Write_File_From_Null_Throw_Exception()
        {

            //Act
            try
            {
               var outputFile =  _fileService.WriteToFile(validDataFile, null);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsNotNull(ex);
                Assert.AreEqual(ex.Message, "Name List is empty");

            }
        }

        #endregion
    }
}
