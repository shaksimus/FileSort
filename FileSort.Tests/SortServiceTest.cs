using System;
using System.Collections.Generic;
using System.Linq;
using FileSort.Interface;
using FileSort.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileSort.Tests
{
    [TestClass]
    public class SortServiceTest
    {

        private List<PersonName> testData = new List<PersonName>
        {
            new PersonName() {FirstName = "Luke", LastName = "Skywalker"},
            new PersonName() {FirstName = "Obi-Wan", LastName = "Kenobi"},
            new PersonName() {FirstName = "Leah", LastName = "Skywalker"}
        };

        private ISortService _sortService;


        [TestInitialize]
        public void Setup()
        {
			//IoC container to resolve the service
            Bootstrap.Register();
            _sortService = TinyIoC.TinyIoCContainer.Current.Resolve<ISortService>();

        }


        [TestMethod]
        public void Ascending_Sort_For_Valid_Data_Then_Return_Sorted_List()
        {

            var result = _sortService.GetSortList(testData);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.AreNotSame(result,testData);
            Assert.AreEqual(result[0],testData[1]);
            Assert.AreEqual(result[1], testData[2]);
            Assert.AreEqual(result[2], testData[0]);
        }


        [TestMethod]
        public void Descending_Sort_For_Valid_Data_Then_Return_Sorted_List()
        {

            var result = _sortService.GetSortList(testData,true);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.AreNotSame(result, testData);
            Assert.AreEqual(result[0], testData[0]);
            Assert.AreEqual(result[1], testData[2]);
            Assert.AreEqual(result[2], testData[1]);
        }


        [TestMethod]
        public void Sort_For_Null_Data_Then_Throw_Null_Exception()
        {
            try
            {
                var result = _sortService.GetSortList(null, true);
            }
            catch (Exception ex)
            {
                var assertException = ex as ArgumentNullException;
                Assert.IsNotNull(ex);
                Assert.IsNotNull(assertException);
                Assert.AreEqual(ex.Message , assertException.Message);
                
            }
        }


        [TestMethod]
        public void Sort_For_Empty_List_Then_Throw_Arguement_Exception()
        {
            try
            {
                var result = _sortService.GetSortList(new List<PersonName>(), true);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
                Assert.AreEqual(ex.Message, "Empty list can not be sorted");

            }
        }
    }
}
