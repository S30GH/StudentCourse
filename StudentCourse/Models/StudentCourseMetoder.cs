using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourse.Models
{
    public class StudentCourseMetoder
    {
        public List<StudentCourseDetalj> GetStudentCourseWithDataSet(out string errormsg)
        {
            //Skapa  SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studentdatabas;Integrated Security=True";

            //Sqlstring och för att hämta alla registrerade studenter
            string sqlstring = "SELECT * FROM Tbl_Student, Tbl_StudentCourse, Tbl_Course WHERE Tbl_StudentCourse.St_Id = Tbl_Student.St_Id AND Tbl_StudentCourse.Co_Id = Tbl_Course.Co_Id";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            //skapa en adapter
            SqlDataAdapter myAdapter = new SqlDataAdapter(dbCommand);
            DataSet myDS = new DataSet();

            List<StudentCourseDetalj> StudentCourseList = new List<StudentCourseDetalj>();

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
                        StudentCourseDetalj scd = new StudentCourseDetalj();
                        scd.St_Firstname = myDS.Tables["myStudent"].Rows[i]["St_Firstname"].ToString();
                        scd.St_Lastname = myDS.Tables["myStudent"].Rows[i]["St_Lastname"].ToString();
                        scd.St_Pnr = myDS.Tables["myStudent"].Rows[i]["St_Pnr"].ToString();
                        scd.St_Id = Convert.ToInt16(myDS.Tables["myStudent"].Rows[i]["St_Id"]);
                        scd.Co_Name = myDS.Tables["myStudent"].Rows[i]["Co_Name"].ToString();
                        scd.Co_Period = myDS.Tables["myStudent"].Rows[i]["Co_Period"].ToString();
                        scd.Co_Studyrate = myDS.Tables["myStudent"].Rows[i]["Co_Studyrate"].ToString();
                        scd.Co_Id = Convert.ToInt16(myDS.Tables["myStudent"].Rows[i]["Co_Id"]);

                        i++;
                        StudentCourseList.Add(scd);
                    }
                    errormsg = "";
                    return StudentCourseList;
                }
                else
                {
                    errormsg = "Det hämtas ingen data.";
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

        public List<StudentCourseDetalj> GetStudentCourseWithDataSet(out string errormsg, int filterId)
        {
            //Skapa  SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studentdatabas;Integrated Security=True";

            //Sqlstring och för att hämta alla studenter
            string sqlstring = "SELECT * FROM Tbl_Student, Tbl_StudentCourse, Tbl_Course WHERE Tbl_StudentCourse.St_Id = Tbl_Student.St_Id AND Tbl_StudentCourse.Co_Id = Tbl_Course.Co_Id AND Tbl_Course.Co_Id = @filterId";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            dbCommand.Parameters.Add("filterId", SqlDbType.Int).Value = filterId;

            //skapa en adapter
            SqlDataAdapter myAdapter = new SqlDataAdapter(dbCommand);
            DataSet myDS = new DataSet();

            List<StudentCourseDetalj> StudentCourseList = new List<StudentCourseDetalj>();

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
                        StudentCourseDetalj scd = new StudentCourseDetalj();
                        scd.St_Firstname = myDS.Tables["myStudent"].Rows[i]["St_Firstname"].ToString();
                        scd.St_Lastname = myDS.Tables["myStudent"].Rows[i]["St_Lastname"].ToString();
                        scd.St_Pnr = myDS.Tables["myStudent"].Rows[i]["St_Pnr"].ToString();
                        scd.St_Id = Convert.ToInt16(myDS.Tables["myStudent"].Rows[i]["St_Id"]);
                        scd.Co_Name = myDS.Tables["myStudent"].Rows[i]["Co_Name"].ToString();
                        scd.Co_Period = myDS.Tables["myStudent"].Rows[i]["Co_Period"].ToString();
                        scd.Co_Studyrate = myDS.Tables["myStudent"].Rows[i]["Co_Studyrate"].ToString();
                        scd.Co_Id = Convert.ToInt16(myDS.Tables["myStudent"].Rows[i]["Co_Id"]);

                        i++;
                        StudentCourseList.Add(scd);
                    }
                    errormsg = "";
                    return StudentCourseList;
                }
                else
                {
                    errormsg = "Det hämtas ingen data.";
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

        public List<StudentCourseDetalj> SortStudentCourseWithDataSet(out string errormsg, string sort)
        {
            //Skapa  SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studentdatabas;Integrated Security=True";

            //Sqlstring och för att hämta alla studenter
            string sqlstring = "SELECT * FROM Tbl_Student, Tbl_StudentCourse, Tbl_Course WHERE Tbl_StudentCourse.St_Id = Tbl_Student.St_Id AND Tbl_StudentCourse.Co_Id = Tbl_Course.Co_Id ORDER BY Tbl_Course.Co_Name";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            //skapa en adapter
            SqlDataAdapter myAdapter = new SqlDataAdapter(dbCommand);
            DataSet myDS = new DataSet();

            List<StudentCourseDetalj> StudentCourseList = new List<StudentCourseDetalj>();

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
                        StudentCourseDetalj scd = new StudentCourseDetalj();
                        scd.St_Firstname = myDS.Tables["myStudent"].Rows[i]["St_Firstname"].ToString();
                        scd.St_Lastname = myDS.Tables["myStudent"].Rows[i]["St_Lastname"].ToString();
                        scd.St_Pnr = myDS.Tables["myStudent"].Rows[i]["St_Pnr"].ToString();
                        scd.St_Id = Convert.ToInt16(myDS.Tables["myStudent"].Rows[i]["St_Id"]);
                        scd.Co_Name = myDS.Tables["myStudent"].Rows[i]["Co_Name"].ToString();
                        scd.Co_Period = myDS.Tables["myStudent"].Rows[i]["Co_Period"].ToString();
                        scd.Co_Studyrate = myDS.Tables["myStudent"].Rows[i]["Co_Studyrate"].ToString();
                        scd.Co_Id = Convert.ToInt16(myDS.Tables["myStudent"].Rows[i]["Co_Id"]);

                        i++;
                        StudentCourseList.Add(scd);
                    }
                    errormsg = "";
                    return StudentCourseList;
                }
                else
                {
                    errormsg = "Det hämtas ingen data.";
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

        public int DeleteStudentCourse(int St_Id, out string errormsg)
        {

            //Skapa  SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studentdatabas;Integrated Security=True";

            //sqlstring och lägg till en user i database
            string sqlstring = "DELETE FROM Tbl_StudentCourse WHERE St_Id = @id";
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

        public int InsertStudentCourse(StudentCourseDetalj scd, out string errormsg)
        {
            //Skapa  SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studentdatabas;Integrated Security=True";

            //sqlstring och lägg till en user i database
            string sqlstring = "INSERT INTO Tbl_StudentCourse (St_Id, Co_Id) VALUES (@st_id, @co_id)";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            dbCommand.Parameters.Add("st_id", SqlDbType.Int).Value = scd.St_Id;
            dbCommand.Parameters.Add("co_id", SqlDbType.Int).Value = scd.Co_Id;
            


            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbCommand.ExecuteNonQuery(); //Skickar fråga till databasen
                if (i == 1) { errormsg = ""; }
                else { errormsg = "Det har inte registrerats någon student."; }
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

        public List<StudentCourseDetalj> Sokning(out string errormsg, string SokString)
        {
            //Skapa  SqlConnection
            SqlConnection dbConnection = new SqlConnection();

            //Koppling mot SQL Server
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studentdatabas;Integrated Security=True";

            //Sqlstring och för att hämta alla studenter
            //string sqlstring = "SELECT * FROM Tbl_Student";
            string sqlstring = "SELECT * FROM Tbl_Student, Tbl_StudentCourse, Tbl_Course WHERE Tbl_StudentCourse.St_Id = Tbl_Student.St_Id AND Tbl_StudentCourse.Co_Id = Tbl_Course.Co_Id AND Tbl_Student.St_pnr = @SokString";
            SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

            dbCommand.Parameters.Add("SokString", SqlDbType.Char, 12).Value = SokString;

            //skapa en adapter
            SqlDataAdapter myAdapter = new SqlDataAdapter(dbCommand);
            DataSet myDS = new DataSet();

            List<StudentCourseDetalj> StudentCourseList = new List<StudentCourseDetalj>();

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
                        StudentCourseDetalj scd = new StudentCourseDetalj();
                        scd.St_Firstname = myDS.Tables["myStudent"].Rows[i]["St_Firstname"].ToString();
                        scd.St_Lastname = myDS.Tables["myStudent"].Rows[i]["St_Lastname"].ToString();
                        scd.St_Pnr = myDS.Tables["myStudent"].Rows[i]["St_Pnr"].ToString();
                        scd.St_Id = Convert.ToInt16(myDS.Tables["myStudent"].Rows[i]["St_Id"]);
                        scd.Co_Name = myDS.Tables["myStudent"].Rows[i]["Co_Name"].ToString();
                        scd.Co_Period = myDS.Tables["myStudent"].Rows[i]["Co_Period"].ToString();
                        scd.Co_Studyrate = myDS.Tables["myStudent"].Rows[i]["Co_Studyrate"].ToString();
                        scd.Co_Id = Convert.ToInt16(myDS.Tables["myStudent"].Rows[i]["Co_Id"]);

                        i++;
                        StudentCourseList.Add(scd);
                    }
                    errormsg = "";
                    return StudentCourseList;
                }
                else
                {
                    errormsg = "Det hämtas ingen data.";
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

    }
}
