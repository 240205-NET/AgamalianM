using System;
using System.Data.SqlClient;

namespace SQLDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("SQL Demo Running...");

            string connectionString = "";

            using SqlConnection connection = new SqlConnection(connectionString);
            try
                {
                connection.Open();
                                        //  0           1           2       3       4       5
                // string cmdText = "SELECT CustomerId, FirstName, LastName, Address, City, State From [dbo].[Customer] WHERE Country='Brazil';";

                string cmdText = "SELECT CustomerId, FirstName, LastName, Address, City, State From [dbo].[Customer] WHERE CustomerId = 5;";

                using SqlCommand cmd = new SqlCommand(cmdText, connection);

                using SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("Reader Executed...");

                // List<string> names = new List<string>();

                // while (reader.Read())
                // {
                //     names.Add(reader.GetString(0));                    
                // }

                List<Customer> customers = new List<Customer>();
                while (reader.Read())
                {
                    int? Id = reader.GetInt32(0);
                    string? firstName = reader.GetString(1) ?? ""; // ?? = if this is null
                    string? lastName = reader.GetString(2) ?? "";
                    string? address = reader.GetString(3) ?? "";
                    string? city = reader.GetString(4) ?? "";
                    string? state = reader["State"].ToString() ?? "";

                    customers.Add(new Customer(Id, firstName, lastName, address, city, state));
                }

                connection.Close();

                foreach(Customer c in customers)
                {
                    c.introduction();
                }

                // Customer NewCustomer = new Customer(9999, "Rich'); GO DROP TABLE table_name; GO ", "Bufford", "Revature", "1 NoWhere Lane", "New York", "NY", "USA", 01234, "(123)456-7890", "(098)765-4321", "JBuff@nomail.com", 1);

                Customer NewCustomer = new Customer(9999,"Jessirae", "Bufford", "Revature", "1 NoWhere Lane", "New York", "NY", "USA", 01234, "(123)456-7890", "(098)765-4321", "JBuff@nomail.com", 1);

                connection.Open();
                // string cmdText1 = $"INSERT INTO Customer (CustomerId, FirstName, LastName, Company, Address, City, State, Country, PostalCode, Phone, Fax, Email, SupportRepId) VALUES ({NewCustomer.Id}, '{NewCustomer.firstName}', '{NewCustomer.lastName}', '{NewCustomer.company}', '{NewCustomer.address}', '{NewCustomer.city}', '{NewCustomer.state}', '{NewCustomer.country}', {NewCustomer.postal}, '{NewCustomer.phone}', '{NewCustomer.fax}', '{NewCustomer.email}', {NewCustomer.repId});";

                string cmdText1 = @"INSERT INTO Customer (CustomerId, FirstName, LastName, Company, Address, City, State, Country, PostalCode, Phone, Fax, Email, SupportRepId) VALUES (@ID, '@fName', '@lName', '@company', '@address', '@city', '@state', '@country', @postal, '@phone', '@fax', '@email', @rep);";

                using SqlCommand cmd1 = new SqlCommand(cmdText1, connection);

                cmd1.Parameters.AddWithValue("@ID", NewCustomer.Id);
                cmd1.Parameters.AddWithValue("@fName", NewCustomer.firstName);
                cmd1.Parameters.AddWithValue("@lName", NewCustomer.lastName);
                cmd1.Parameters.AddWithValue("@company", NewCustomer.company);
                cmd1.Parameters.AddWithValue("@address", NewCustomer.address);
                cmd1.Parameters.AddWithValue("@city", NewCustomer.city);
                cmd1.Parameters.AddWithValue("@state", NewCustomer.state);
                cmd1.Parameters.AddWithValue("@country", NewCustomer.country);
                cmd1.Parameters.AddWithValue("@postal", NewCustomer.postal);
                cmd1.Parameters.AddWithValue("@phone", NewCustomer.phone);
                cmd1.Parameters.AddWithValue("@fax", NewCustomer.fax);
                cmd1.Parameters.AddWithValue("@email", NewCustomer.email);
                cmd1.Parameters.AddWithValue("@rep", NewCustomer.repId);

                cmd1.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }

            Console.WriteLine("SQL Demo Ending...");
        }
    }

    public class Customer
    {
        // fields
        public int? Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? company { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? country {get; set; }
        public int? postal { get; set; }
        public string? phone { get; set; }
        public string? fax { get; set; }
        public string? email { get; set; }
        public int? repId { get; set; }

        // constructor
        public Customer (int? Id, string? firstName, string? lastName, string? company, string? address, string? city, string? state, string? country, int? postal, string? phone, string? fax, string? email, int? repId)
        {
            this.Id = Id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.company = company;
            this.address = address;
            this.state = state;
            this.city = city;
            this.country = country;
            this.postal = postal;
            this.phone = phone;
            this.fax = fax;
            this.email = email;
            this.repId = repId;
        }

        public Customer (int? Id, string? firstName, string? lastName, string? address, string? city, string? state)
        {
            this.Id = Id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.state = state;
            this.city = city;
        }

        // methods
        public void introduction()
        {
            Console.WriteLine($"ID: {this.Id}\n Name: {this.firstName} {this.lastName}");
        }
    }
}