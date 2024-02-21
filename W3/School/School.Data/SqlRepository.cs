using System;
using System.Data.SqlClient;
using School.Logic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace School.Data
{
    public class SqlRepository : IRepository
    {

        // Fields
        private readonly string _connectionString;
        private readonly ILogger<SqlRepository> _logger;

        // Constructors
        public SqlRepository(string connectionString, ILogger<SqlRepository> logger)
        {
            this._connectionString = connectionString; ;
            this._logger = logger;
        }

        // Methods       
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {     
            using SqlConnection connection = new SqlConnection(this._connectionString);

            connection.OpenAsync();
            string cmdText = "SELECT * From [School].[Students];";
            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            Console.WriteLine("Reader Executed...");
            List<Student> students = new List<Student>();

            while (await reader.ReadAsync())
            {
                int Id = (int)reader["Id"];
                string name = reader["Name"].ToString() ?? "";
                string email = reader["Email"].ToString() ?? "";
                string address1 = reader["Address1"].ToString() ?? "";
                string address2 = reader["Address2"].ToString() ?? "";
                string city = reader["City"].ToString() ?? "";
                string state = reader["State"].ToString()?? "";
                string zip = reader["Zip"].ToString();
                object gpa_d = reader["GPA"];

                double gpa = System.Convert.ToDouble(gpa_d);
                students.Add(new Student(Id, name, email, address1, address2, city, state, zip, gpa));
            }
            connection.CloseAsync();

            _logger.LogInformation("Executed GetAllStudentsAsync, returned {0} results.", students.Count);
            return students;            
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {     
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.OpenAsync();

            string cmdText = "SELECT * From [School].[Students] WHERE Id = @id;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            Student tmpstudent = new Student();

            while (await reader.ReadAsync())
            {
                int Id = (int)reader["Id"];
                string name = reader["Name"].ToString() ?? "";
                string email = reader["Email"].ToString() ?? "";
                string address1 = reader["Address1"].ToString() ?? "";
                string address2 = reader["Address2"].ToString() ?? "";
                string city = reader["City"].ToString() ?? "";
                string state = reader["State"].ToString()?? "";
                string zip = reader["Zip"].ToString();
                object gpa_d = reader["GPA"];

                double gpa = System.Convert.ToDouble(gpa_d);
                tmpstudent = new Student(Id, name, email, address1, address2, city, state, zip, gpa);
            }
            connection.CloseAsync();
            return tmpstudent;            
        }


        public string MichaelsGetTeachersInfo()
        {
            var sb = new StringBuilder();
            using SqlConnection connection = new SqlConnection(this._connectionString);
 
            try{
                connection.Open();
                string cmdText = "SELECT * FROM [School].[Teachers];";
                using SqlCommand cmd = new SqlCommand(cmdText, connection);
                using SqlDataReader reader = cmd.ExecuteReader();
               
                while(reader.Read())
                {
                    // string Id = reader.GetInt32(0); // Id INT PRIMARY KEY,
                    string name = reader.GetString(1); // Name VARCHAR(255) NOT NULL,
                    string email = reader.GetString(2); // Email VARCHAR(255) NOT NULL,
                    string address1 = reader.GetString(3); // Address1 VARCHAR(255)NOT NULL,
                    string address2 = reader.GetString(4); // Address2 VARCHAR(255),
                    string city = reader.GetString(5); // City VARCHAR(255) NOT NULL,
                    string state = reader.GetString(6); // State VARCHAR(255) NOT NULL,
                    int zip = reader.GetInt32(7); // Zip INT NOT NULL,
                    int office = reader.GetInt32(8); // Office INT NOT NULL,
                    double salary = (double)reader.GetDecimal(9); // Salary DECIMAL NOT NULL,
                    string subject = reader.GetString(10); // Subject VARCHAR(255) NOT NULL          
                   
                    sb.AppendLine(new Teacher(office, salary, subject, name, email, address1, address2, city, state, zip.ToString()).ToString());
                }
                connection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                connection.Close();
            }
 
            return sb.ToString();
        }

        public List<Student> JessiraesGetStudent()
        {
            using SqlConnection connection = new SqlConnection(this._connectionString);
            string cmd2Text = "SELECT * From [School].[Students] WHERE Id = 12;";
            using SqlCommand cmd2 = new SqlCommand(cmd2Text, connection);
            using SqlDataReader reader = cmd2.ExecuteReader();
            Console.WriteLine("Reader Executed...");
            List<Student> students = new List<Student>();

            while (reader.Read())
            {
                int Id = reader.GetInt32(0);
                string name = reader.GetString(1) ?? "";
                string email = reader.GetString(2) ?? "";
                string address1 = reader.GetString(3) ?? "";
                string address2 = reader.GetString(4) ?? "";
                string city = reader.GetString(5) ?? "";
                string state = reader.GetString(6) ?? "";
                int zip = reader.GetInt32(7);
                //double? gpa = reader.GetDouble(8);
                students.Add(new Student(Id, name, email, address1, address2, city, state, zip.ToString()));
            }
            return students;
        }

        public void NabinsAddStudent()
        {
            using SqlConnection connection = new SqlConnection(this._connectionString);
            try{
                connection.Open();
                Student student =  new Student("New Guy", "guy@no.com", "1500 Pen. Ave", "apt 1", "Washington", "DC", "12345");
                string query1 = "INSERT INTO [School].[Students] (name, email, address1, address2, city, state, zip, GPA) VALUES(@id, @name,@email,@address1, @address2,@city,@state, @zip, @GPA)";
                using SqlCommand cmd1 = new SqlCommand(query1, connection);
                cmd1.Parameters.AddWithValue("@id",student.studentId);
                cmd1.Parameters.AddWithValue("@name", student.name);
                cmd1.Parameters.AddWithValue("@email", student.email);
                cmd1.Parameters.AddWithValue("@address1", student.address1);
                cmd1.Parameters.AddWithValue("@address2", student.address2);
                cmd1.Parameters.AddWithValue("@city", student.city);
                cmd1.Parameters.AddWithValue("@state", student.state);
                cmd1.Parameters.AddWithValue("@zip", student.zip);
                cmd1.Parameters.AddWithValue("@GPA", student.gpa);
                cmd1.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error on Database "+ e.Message);
                connection.Close();
            }
        }
    }
}