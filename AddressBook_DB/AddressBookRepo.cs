using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_DB
{
    public class AddressBookRepo
    {
        public static string Connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Address_book;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static string connectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllAddress_book()
        {
            try
            {
                AddressBookModel addressbook = new AddressBookModel();
                using (this.connection)
                {
                    string query = @"Select * from Address_book";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            addressbook.ID = dr.GetInt32(0);

                            addressbook.FirstName = dr.GetString(1);
                            addressbook.LastName = dr.GetString(2);
                            addressbook.Address = dr.GetString(3);
                            addressbook.City = dr.GetString(4);
                            addressbook.State = dr.GetString(5);
                            addressbook.ZipCode = dr.GetInt32(6);
                            addressbook.PhoneNo = dr.GetString(7);
                            addressbook.Email = dr.GetString(8);
                            System.Console.WriteLine(addressbook.FirstName + " " + addressbook.LastName + " " + addressbook.Address + " " + addressbook.City + " " + addressbook.State + " " + addressbook.ZipCode + " " + addressbook.PhoneNo + " " + addressbook.Email);
                            System.Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        public bool AddAddressBook(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    //var qury=values()
                    SqlCommand command = new SqlCommand("SpAddAddressBookDetails", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@ZipCode", model.ZipCode);
                    command.Parameters.AddWithValue("@PhoneNo", model.PhoneNo);
                    command.Parameters.AddWithValue("@Email", model.Email);
               
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
    }
}
