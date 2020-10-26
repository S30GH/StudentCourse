using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourse.Models
{
    public class CourseMetoder
    {
        public CourseMetoder()
        {

        }

        public int InsertCourse(CourseDetalj cd, out string errormsg)
        {
            //Skapa  SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studentdatabas;Integrated Security=True";

            //sqlstring och lägg till en user i database
            string sqlstring = "INSERT INTO Tbl_Course (Co_Name, Co_Period, Co_Studyrate) VALUES (@name, @period, @studyrate)";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            dbCommand.Parameters.Add("name", SqlDbType.Char, 50).Value = cd.Co_Name;
            dbCommand.Parameters.Add("period", SqlDbType.Char, 4).Value = cd.Co_Period;
            dbCommand.Parameters.Add("studyrate", SqlDbType.Char, 4).Value = cd.Co_Studyrate;


            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery(); //Skickar fråga till databasen
                if (i == 1) { errormsg = ""; }
                else { errormsg = "Det skapas inte en kurs i databasen."; }
                return (i);
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        //Uppdatera SQL-anrop och dbCommand
        public int DeleteCourse(int Co_Id, out string errormsg)
        {
            //Skapa  SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studentdatabas;Integrated Security=True";

            //sqlstring och lägg till en user i database
            string sqlstring = "DELETE FROM Tbl_Course WHERE Co_Id = @id";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            dbCommand.Parameters.Add("id", SqlDbType.Int).Value = Co_Id;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery(); //Skickar fråga till databasen
                if (i == 1) { errormsg = ""; }
                else { errormsg = "Det togs inte bort någon kurs i databasen."; }
                return (i);
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public List<CourseDetalj> GetCourseWithDataSet(out string errormsg)
        {
            //Skapa  SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studentdatabas;Integrated Security=True";

            //Sqlstring och för att hämta alla studenter
            string sqlstring = "SELECT * FROM Tbl_Course";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            //skapa en adapter
            SqlDataAdapter myAdapter = new SqlDataAdapter(dbCommand);
            DataSet myDS = new DataSet();

            List<CourseDetalj> CourseList = new List<CourseDetalj>();

            try
            {
                dbConnection.Open();

                //Fyller dataset med data i en tabell med nament myStudent
                myAdapter.Fill(myDS, "myCourse");

                int count = 0;
                int i = 0;
                count = myDS.Tables["myCourse"].Rows.Count;

                if (count > 0)
                {
                    while (i < count)
                        {
                        //Läser ut data från datasetet
                        CourseDetalj cd = new CourseDetalj();
                        cd.Co_Name = myDS.Tables["myCourse"].Rows[i]["Co_Name"].ToString();
                        cd.Co_Period = myDS.Tables["myCourse"].Rows[i]["Co_Period"].ToString();
                        cd.Co_Studyrate = myDS.Tables["myCourse"].Rows[i]["Co_Studyrate"].ToString();
                        cd.Co_Id = Convert.ToInt16(myDS.Tables["myCourse"].Rows[i]["Co_Id"]);

                        i++;
                        CourseList.Add(cd);
                    }
                    errormsg = "";
                    return CourseList;
                }
                else
                {
                    errormsg = "Det hämtas ingen kurs.";
                    return (null);
                }
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public int UpdateCourse(CourseDetalj cd, int Co_Id, out string errormsg)
        {
            SqlConnection dbConnection = new SqlConnection();
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studentdatabas;Integrated Security=True";

            string sqlstring = "UPDATE Tbl_Course SET Co_Name = @name, Co_Period = @period, Co_Studyrate = @studyrate";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            dbCommand.Parameters.Add("name", SqlDbType.Char, 50).Value = cd.Co_Name;
            dbCommand.Parameters.Add("period", SqlDbType.Char, 4).Value = cd.Co_Period;
            dbCommand.Parameters.Add("studyrate", SqlDbType.Char, 4).Value = cd.Co_Studyrate;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery();
                if (i == 1) { errormsg = ""; }
                else { errormsg = "Gick ej att uppdatera kurs"; }
                return (i);
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        /*
        public List<StudentDetalj> GetStudentWithReader (out string errormsg)
        {
            //Skapa  SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studentdatabas;Integrated Security=True";

            //Sqlstring och för att hämta alla studenter
            String sqlstring = "SELECT * FROM Tbl_Student";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            //Where Fornamn = 'Marcus' (går att lägga till för att testa om det blir noll poster)
            //String sqlstring = "SELECT * FROM Tbl_Student Where St_Firstname = 'Marcus'";

            // declare the SqlDataReader, which is used in both the try block and the finally block.
            SqlDataReader reader = null;

            List<StudentDetalj> StudentList = new List<StudentDetalj>();

            errormsg = "";

            try
            {
                // open the connection
                dbConnection.Open();

                // 1. get an instace of the SqlDataReader
                reader = dbCommand.ExecuteReader();

                // 2. read necessary columns of each record

                while (reader.Read())
                {
                    StudentDetalj Student = new StudentDetalj();
                    Student.St_Firstname = reader["St_Firstname"].ToString();
                    Student.St_Lastname = reader["St_Lastname"].ToString();
                    Student.St_Pnr = reader["St_Pnr"].ToString();
                    Student.St_Id = Convert.ToInt16(reader["St_Id"]);

                    Student.Add(Student);
                }
                reader.Close();
                return StudentList;
            }
            catch (Exception e)
            {
                errormsg = e.Message;
                return null;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        */
    }
}
