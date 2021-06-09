using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book");
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

            if (repo.AddAddressBook(addressbook))
            Console.WriteLine("Records added successfully");
            Console.ReadKey();
        }
    }
}
