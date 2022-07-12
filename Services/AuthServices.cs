﻿using Models;
using DataAccess;
using CustomExceptions;

namespace Services;

public class AuthServices
{
    // public static string connectionString = "Server=tcp:autumn-server.database.windows.net,1433;Initial Catalog=AutumnDB;Persist Security Info=False;User ID=supremeadmin;Password=" + SensitiveVariables.dbpassword + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public User LoginUser(string userName, string password)
    {
        // create temp user object to store data retrieved from DataAccess layer
        User wantsInside;
        // User wantsInside = new User(userName, password);

        try
        {
            // retrieve user from database using DataAccess method
            wantsInside = new UserRepository().GetUserByUserName(userName);
            // if password for parameter user matches password from database user
            if (wantsInside.password == password)
            // return user to UI layer
            {
                return wantsInside;
                // If user is a Manager, display Manager Menu
                // Console.WriteLine("Welcome, " + userName + ".");
            }
            else
            {
                Console.WriteLine("Go away.");
                // throw custom exception if passwords don't match
                throw new InvalidCredentials();
            }
            // throw custom exception if user doesn't exist
            // if (user.userName)
            // {
            //     throw new ResourceNotFound();
            // }

        }
        // catch any exception thrown from DataAccess
        catch (InvalidCredentials e)
        {
            // if exception caught, throw to the UI layer 
            Console.WriteLine(e.Message);
            return new User();
        }

    }

}

