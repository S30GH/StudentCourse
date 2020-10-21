using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourse.Models
{
    public class StudentMetoder
    {
        public StudentMetoder()
        {

        }

        public int InsertStudent(StudentDetalj pd, out string errormsg)
        {
            //Skapa  SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studentdatabas;Integrated Security=True";

            //sqlstring och lägg till en user i database
            string sqlstring = "INSERT INTO Tbl_Student (St_Firstname, St_Lastname, St_Pnr) VALUES (@firstname, @lastname, @pnr)";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            dbCommand.Parameters.Add("firstname", SqlDbType.Char, 50).Value = pd.St_Firstname;
            dbCommand.Parameters.Add("lastname", SqlDbType.Char, 50).Value = pd.St_Lastname;
            dbCommand.Parameters.Add("pnr", SqlDbType.Char, 12).Value = pd.St_Pnr;


            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery(); //Skickar fråga till databasen
                if (i == 1) { errormsg = ""; }
                else { errormsg = "Det skapas inte en student i databasen."; }
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
        public int DeleteStudent(int St_Id, out string errormsg)
        {

            //Skapa  SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studentdatabas;Integrated Security=True";

            //sqlstring och lägg till en user i database
            string sqlstring = "DELETE FROM Tbl_Student WHERE St_Id = @id";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            dbCommand.Parameters.Add("id", SqlDbType.Int).Value = St_Id;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery(); //Skickar fråga till databasen
                if (i == 1) { errormsg = ""; }
                else { errormsg = "Det togs inte bort någon student i databasen."; }
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

        public List<StudentDetalj> GetStudentWithDataSet(out string errormsg)
        {
            //Skapa  SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studentdatabas;Integrated Security=True";

            //Sqlstring och för att hämta alla studenter
            string sqlstring = "SELECT * FROM Tbl_Student";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            //skapa en adapter
            SqlDataAdapter myAdapter = new SqlDataAdapter(dbCommand);
            DataSet myDS = new DataSet();

            List<StudentDetalj> StudentList = new List<StudentDetalj>();

            try
            {
                dbConnection.Open();

                //Fyller dataset med data i en tabell med nament myStudent
                myAdapter.Fill(myDS, "myStudent");

                int count = 0;
                int i = 0;
                count = myDS.Tables["myStudent"].Rows.Count;

                if (count > 0)
                {
                    while (i < count)
                        {
                        //Läser ut data från datasetet
                        StudentDetalj sd = new StudentDetalj();
                        sd.St_Firstname = myDS.Tables["myStudent"].Rows[i]["St_Firstname"].ToString();
                        sd.St_Lastname = myDS.Tables["myStudent"].Rows[i]["St_Lastname"].ToString();
                        sd.St_Pnr = myDS.Tables["myStudent"].Rows[i]["St_Pnr"].ToString();
                        sd.St_Id = Convert.ToInt16(myDS.Tables["myStudent"].Rows[i]["St_Id"]);

                        i++;
                        StudentList.Add(sd);
                    }
                    errormsg = "";
                    return StudentList;
                }
                else
                {
                    errormsg = "Det hämtas ingen student.";
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
