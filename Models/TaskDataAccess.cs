using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application_Trial.Models
{
    public class TaskDataAccess
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\siris\Documents\Projects\Application_Trial\App_Data\Application_Trial.mdf;Integrated Security=True";

        // To view all Stories
        public IEnumerable<Taski> GetAllTasks()
        {
            List<Taski> LstStrory = new List<Taski>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllTasks", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Taski Task = new Taski();
                    Task.TaskID = Convert.ToInt32(rdr["TaskID"]);
                    Task.StoryID = Convert.ToInt32(rdr["StoryID"]);
                    Task.TaskName = rdr["TaskName"].ToString();
                    Task.TaskType = rdr["TaskType"].ToString();
                    Task.TaskDesc = rdr["TaskDescription"].ToString();
                    Task.TaskStatus = rdr["TaskStatus"].ToString();

                    LstStrory.Add(Task);
                }
                con.Close();
            }
            return LstStrory;
        }
        //Add a new Task
        public void AddTask(Taski Task)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddTask", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StoryID", Task.StoryID);
                cmd.Parameters.AddWithValue("@TaskName", Task.TaskName);
                cmd.Parameters.AddWithValue("@TaskType", Task.TaskType);
                cmd.Parameters.AddWithValue("@TaskDesc", Task.TaskDesc);
                cmd.Parameters.AddWithValue("@TaskStatus", Task.TaskStatus);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //Update a Task
        public void UpdateTask(Taski Task)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateTask", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TaskID", Task.TaskID);
                cmd.Parameters.AddWithValue("@TaskDesc", Task.TaskDesc);
                cmd.Parameters.AddWithValue("@TaskStatus", Task.TaskStatus);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //Delete a Task
        public void DeleteTask(int? TaskID)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteTask", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TaskID", TaskID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //Get a SpecifiC Task
        public Taski GetTask(int? TaskID)
        {
            Taski Task = new Taski();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tblStory WHERE TaskID= " + TaskID;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Task.TaskID = Convert.ToInt32(rdr["TaskID"]);
                    Task.StoryID = Convert.ToInt32(rdr["StoryID"]);
                    Task.TaskName = rdr["TaskName"].ToString();
                    Task.TaskType = rdr["TaskType"].ToString();
                    Task.TaskDesc = rdr["TaskDescription"].ToString();
                    Task.TaskStatus = rdr["TaskStatus"].ToString();
                }
            }
            return Task;
        }
        //Get Task based on Status
        public IEnumerable<Taski> GetAllStatusTasks(String TaskStatus)
        {
            List<Taski> LstSTTask = new List<Taski>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tblStory WHERE TaskStatus= " + TaskStatus;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Taski task = new Taski();
                    task.TaskID = Convert.ToInt32(rdr["TaskID"]);
                    task.StoryID = Convert.ToInt32(rdr["StoryID"]);
                    task.TaskName = rdr["TaskName"].ToString();
                    task.TaskType = rdr["TaskType"].ToString();
                    task.TaskDesc = rdr["TaskDescription"].ToString();
                    task.TaskStatus = rdr["TaskStatus"].ToString();

                    LstSTTask.Add(task);
                }
                con.Close();
            }
            return LstSTTask;

        }
    }
}