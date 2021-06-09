using AddressBook_DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AddressBookRepo repo = new AddressBookRepo();
            AddressBookModel addressbook = new AddressBookModel();
            addressbook.FirstName = "Rakesh";
            addressbook.LastName = "Singhal";
            addressbook.Address = "Street 20";
            addressbook.City = "Mumbai";
            addressbook.State = "Maharashtra";
            addressbook.ZipCode = 414414;
            addressbook.PhoneNo = "922299292";
            addressbook.Email = "rakesh@gmail.com";
           
            var result = repo.AddAddressBook(addressbook);
            Assert.IsTrue(result);
        }

    }
}
