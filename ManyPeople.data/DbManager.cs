using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyPeople.data
{
    public class DbManager
    {
        private string _connectionString;

        public DbManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddOne(Person p)
        {
            if(p.FirstName == null || p.LastName == null || p.Age == 0) 
            {
                return;
            }

            using var connection = new SqlConnection(_connectionString);
            using var command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO People (FirstName, LastName, Age)
                            VALUES (@firstName, @lastName, @age)";
            command.Parameters.AddWithValue("@firstName", p.FirstName);
            command.Parameters.AddWithValue("@lastName", p.LastName);
            command.Parameters.AddWithValue("@age", p.Age);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void AddMany(List<Person> ppl)
        {
            foreach(Person p in ppl)
            {
                AddOne(p);
            }
        }

        public List<Person> GetPeople()
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM People";

            connection.Open();
            var reader = command.ExecuteReader();
            List<Person> people = new List<Person>();

            while (reader.Read())
            {
                people.Add(new Person
                {
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["age"]
                });
            }

            return people;

        }
    }
}
