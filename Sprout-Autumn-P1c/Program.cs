﻿//using UI;
using DataAccess;

//MainMenu intro = new MainMenu();
//intro.Begin();

// Console.WriteLine("Here is a list of all users:");
// UserRepository peeps = new UserRepository();
// peeps.GetAllUsers();


// UserRepository peepIWant = new UserRepository();
// Console.WriteLine("Which user do you want?");
// string userIWant = Console.ReadLine();
// peepIWant.GetUserByUserName(userIWant);

Console.WriteLine("Here is a list of all users:");
UserRepository peeps = new UserRepository();
peeps.GetAllUsers();

Console.WriteLine("Here is a list of all Tickets:");
TicketRepository tickets = new TicketRepository();
tickets.GetAllTickets();