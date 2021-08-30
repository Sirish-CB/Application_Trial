using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application_Trial.Models
{
    public class StoryDataAccessLayer
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\siris\Documents\Projects\Application_Trial\App_Data\Application_Trial.mdf;Integrated Security=True";

        // To view all Stories
        public IEnumerable<Story> GetAllStories()
        {
            List<Story> LstStrory = new List<Story>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllStories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Story story = new Story();
                    story.StoryID = Convert.ToInt32(rdr["StoryID"]);
                    story.Nooftasks = Convert.ToInt32(rdr["Nooftasks"]);
                    story.Name = rdr["Name"].ToString();
                    story.Department = rdr["Department"].ToString(); 
                    story.Description = rdr["Description"].ToString();
                    story.Status = rdr["Status"].ToString();

                    LstStrory.Add(story);
                }
                con.Close();
            }
            return LstStrory;
        }
        //Add a new Story
        public void AddStory(Story story)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddStory", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nooftasks", story.Nooftasks);
                cmd.Parameters.AddWithValue("@Name", story.Name);
                cmd.Parameters.AddWithValue("@Department", story.Department);
                cmd.Parameters.AddWithValue("@Description", story.Description);
                cmd.Parameters.AddWithValue("@Status", story.Status);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //Update a Story
        public void UpdateStory(Story story)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateStory", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StoryID", story.StoryID);
                cmd.Parameters.AddWithValue("@Nooftasks", story.Nooftasks);
                cmd.Parameters.AddWithValue("@Description", story.Description);
                cmd.Parameters.AddWithValue("@Status", story.Status);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //Delete a Story
        public void DeleteStory(int? StoryID)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStory", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StoryID", StoryID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //Get a SpecifiC Story
        public Story GetStory(int? StoryID)
        {
            Story story = new Story();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tblStory WHERE TaskID= " + StoryID;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    story.StoryID = Convert.ToInt32(rdr["StoryID"]);
                    story.Nooftasks = Convert.ToInt32(rdr["Nooftasks"]);
                    story.Name = rdr["Name"].ToString();
                    story.Department = rdr["Department"].ToString();
                    story.Description = rdr["Description"].ToString();
                    story.Status = rdr["Status"].ToString();
                }
            }
            return story;
        }
        public IEnumerable<Story> GetAllStatusStories(String Status)
        {
            List<Story> LstSTStrory = new List<Story>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tblStory WHERE Status= " + Status;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Story story = new Story();
                    story.StoryID = Convert.ToInt32(rdr["StoryID"]);
                    story.Nooftasks = Convert.ToInt32(rdr["Nooftasks"]);
                    story.Name = rdr["Name"].ToString();
                    story.Department = rdr["Department"].ToString();
                    story.Description = rdr["Description"].ToString();
                    story.Status = rdr["Status"].ToString();

                    LstSTStrory.Add(story);
                }
                con.Close();
            }
            return LstSTStrory;
        }
    }
}