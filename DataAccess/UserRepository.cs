﻿using Models;
using Services;
using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public class UserRepository
    {


        public string thoseAll = "select * from AutumnERS.users;";



        public List<User> GetUsers(string those)
        {

            List<User> users = new List<User>();

            SqlConnection makeConnection = new SqlConnection(AuthServices.connectionString);

            SqlCommand getEveryUser = new SqlCommand(those, makeConnection);

            try
            {
                makeConnection.Open();
                SqlDataReader reader = getEveryUser.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}", reader[0], reader[1], reader[2], reader[3]);
                    users.Add(new User((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3]));
                }
                reader.Close();
                makeConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return users;
        }





        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();
            GetUsers(thoseAll);
            return allUsers;
        }




        public List<User> GetUserByUserName(string userWanted)
        {

            List<User> thisUser = new List<User>();

            string getThisUser = "select * from AutumnERS.users where userName ='" + userWanted + "';";

            SqlConnection makeConnection = new SqlConnection(AuthServices.connectionString);

            SqlCommand goGetThisUser = new SqlCommand(getThisUser, makeConnection);

            try
            {
                makeConnection.Open();
                SqlDataReader reader = goGetThisUser.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}", reader[0], reader[1], reader[2], reader[3]);
                    thisUser.Add(new User((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3]));
                }
                reader.Close();
                makeConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return thisUser;
        }

    }
}

