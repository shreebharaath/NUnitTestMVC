using System;
using System.Data.SqlClient;
using UnitTestCICD.Controllers;
using UnitTestCICD.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;https://www.youtube.com/watch?v=pksLVOtRfno&t=7s

namespace UnitTestProjCICD
{
    [TestClass]
    public class UnitTest1
    {
        string Conn = "Server=INFINITY\\SQL2014;Initial Catalog=UnitTestCICD;uid=sa;pwd=Sudhaamma@1259";
        [TestMethod]
        public void CheckEmployee()
        {
            bool ExpectedValue = true;
            UnitTestMethods empDetailsMethods = new UnitTestMethods();
            bool ActualValue = empDetailsMethods.GetEmployee("100", Conn);
            Assert.AreEqual(ExpectedValue, ActualValue, "TestPassed");
        }
    }
}
