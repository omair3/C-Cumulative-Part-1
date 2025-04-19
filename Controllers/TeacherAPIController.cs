using Microsoft.AspNetCore.Mvc;
using C__Cumulative_Part_1.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Cumulative1.Model;

namespace C__Cumulative_Part_1.Controllers
{
    [Route("api/Teacher")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        // Dependency injection of the SchoolDbContext
        private readonly SchoolDbContext _context;

        // Constructor that initializes the database connection
        public TeacherAPIController()
        {
            _context = new SchoolDbContext();
        }

        /// <summary>
        /// Returns a list of teacher names in the system
        /// </summary>
        /// <returns>A list of strings</returns>
        /// <example>
        /// GET api/Teacher/ListTeacherNames -> ["John Smith", "Jane Doe"]
        /// </example>
        [HttpGet]
        [Route("ListTeacherNames")]
        public List<string> ListTeacherNames()
        {
            List<string> TeacherNames = new List<string>();

            using (MySqlConnection conn = _context.AccessDatabase())
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string query = "SELECT teacherfname, teacherlname FROM teachers";
                cmd.CommandText = query;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string fname = reader["teacherfname"].ToString();
                        string lname = reader["teacherlname"].ToString();
                        string fullName = $"{fname} {lname}";
                        TeacherNames.Add(fullName);
                    }
                }
            }

            return TeacherNames;
        }

        /// <summary>
        /// Returns full information about a specific teacher by ID
        /// </summary>
        /// <param name="id">The teacher's ID</param>
        /// <returns>A Teacher object with full information</returns>
        /// <example>
        /// GET api/Teacher/FindTeacher/2
        /// </example>
        [HttpGet]
        [Route("FindTeacher/{id}")]
        public Teacher FindTeacher(int id)
        {
            // Extra Iniative part  to return null if teacher is not found 
            Teacher SelectedTeacher = null;

            using (MySqlConnection conn = _context.AccessDatabase())
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM teachers WHERE teacherid = @id";
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        SelectedTeacher = new Teacher
                        {
                            TeacherId = Convert.ToInt32(reader["teacherid"]),
                            TeacherFirstName = reader["teacherfname"].ToString(),
                            TeacherLastName = reader["teacherlname"].ToString(),
                            EmployeeNumber = reader["employeenumber"].ToString(),
                            HireDate = Convert.ToDateTime(reader["hiredate"]),
                            Salary = Convert.ToDouble(reader["salary"])
                        };
                    }
                }
            }

            return SelectedTeacher;
        }

        /// <summary>
        /// Returns a list of all teachers with full information
        /// </summary>
        /// <returns>A list of Teacher objects</returns>
        /// <example>
        /// GET api/Teacher/ListTeacherRecords
        /// </example>
        [HttpGet]
        [Route("ListTeacherRecords")]
        public List<Teacher> ListTeacherRecords()
        {
            List<Teacher> Teachers = new List<Teacher>();

            using (MySqlConnection conn = _context.AccessDatabase())
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM teachers";

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Teacher t = new Teacher
                        {
                            TeacherId = Convert.ToInt32(reader["teacherid"]),
                            TeacherFirstName = reader["teacherfname"].ToString(),
                            TeacherLastName = reader["teacherlname"].ToString(),
                            EmployeeNumber = reader["employeenumber"].ToString(),
                            HireDate = Convert.ToDateTime(reader["hiredate"]),
                            Salary = Convert.ToDouble(reader["salary"])
                        };

                        Teachers.Add(t);
                    }
                }
            }

            return Teachers;
        }
    }
}