﻿using Models;
using Sensitive;
// using Services;
using System.Data.SqlClient;

namespace DataAccess;

// The only purpose of DAO or DataAccess layer is to talk to the database

public class TicketRepository
{
    public static string connectionString = "Server=tcp:autumn-server.database.windows.net,1433;Initial Catalog=AutumnDB;Persist Security Info=False;User ID=supremeadmin;Password=" + SensitiveVariables.dbpassword + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public string thoseAll = "select * from AutumnERS.tickets;";





    public List<Ticket> GetTickets(string those)
    {

        List<Ticket> tickets = new List<Ticket>();

        SqlConnection makeConnection = new SqlConnection(connectionString);

        SqlCommand getEveryTicket = new SqlCommand(those, makeConnection);

        try
        {
            makeConnection.Open();
            SqlDataReader reader = getEveryTicket.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                tickets.Add(new Ticket((int)reader[0], (int)reader[1], (int)reader[2], (string)reader[3], (string)reader[4], (decimal)reader[5]));
            }
            reader.Close();
            makeConnection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return tickets;
    }







    public List<Ticket> GetAllTickets()
    {
        List<Ticket> allTickets = new List<Ticket>();
        GetTickets(thoseAll);
        return allTickets;
    }

    public List<Ticket> GetTicketsByUserName(string userIWantTicketsFor)
    {
        string TicketsByUserName = "select * from AutumnERS.tickets where userName='" + userIWantTicketsFor + "';";
        List<Ticket> allTicketsByUserName = new List<Ticket>();
        GetTickets(TicketsByUserName);
        return allTicketsByUserName;
    }

    // UPDATE/process = approve or deny 



    // Get a ticket by ticketID

    public List<Ticket> GetTicketsByTicketID()
    {
        // string TicketsByUserName = "select * from AutumnERS.tickets where userName='" + userIWantTicketsFor + "';";
        // List<Ticket> allTicketsByUserName = new List<Ticket>();
        // GetTickets(TicketsByUserName);
        // return allTicketsByUserName;
        return new List<Ticket>();
    }

    public List<Ticket> CreateTicket()
    {
        // string TicketsByUserName = "select * from AutumnERS.tickets where userName='" + userIWantTicketsFor + "';";
        // List<Ticket> allTicketsByUserName = new List<Ticket>();
        // GetTickets(TicketsByUserName);
        // return allTicketsByUserName;
        return new List<Ticket>();
    }

    // Get all tickets by userID

    public List<Ticket> GetTicketsByUserID()
    {
        // string TicketsByUserName = "select * from AutumnERS.tickets where userName='" + userIWantTicketsFor + "';";
        // List<Ticket> allTicketsByUserName = new List<Ticket>();
        // GetTickets(TicketsByUserName);
        // return allTicketsByUserName;
        return new List<Ticket>();
    }

    // GET TICKET BY STATUS

    /*   
        public string thoseStatusTickets = "select * from AutumnERS.tickets where status = '" + SocialServices.thatStatus + "';";
        public List<Ticket> GetTicketsByStatus(){
            List<Ticket> statusTickets = new List<Ticket>();
            GetTickets(thoseStatusTickets);
            return statusTickets;
        }    


        public bool CreateTicket(Ticket Ticket){

        }

        public List<Ticket> GetTicketByID(ticketID){

        }

        public List<Ticket> GetTicketsByUserName(userName){

        }

        public List<Ticket> resolveTicket(){

        }  

    */
}
