using DSW03A1.Persistence;
using DSW03A1.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DSW03A1
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Loader();
            Console.Clear();
            Console.WriteLine("Welcome to my Contact Application");
            DrawSeparator(50);
            
            bool isNotExit = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Choose an option below :\n");
                Console.WriteLine("A) View all contacts \n" +
                                  "B) Search contact+\n" +
                                  "C) Display Contact by ID");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("D) Exit Program");
                Console.ForegroundColor = ConsoleColor.White;

                char userOption =Convert.ToChar(Console.ReadLine().Trim().ToLower().First());

                if (char.IsWhiteSpace(userOption))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Wrong Input!!");

                }
                else
                {
                    DisplayData(userOption);
                }
            } while (isNotExit);
        }


        static void DisplayData(char option)
        {
            var viewModel = new ContactsViewModel();
            
            switch (option)
            {
                case 'a':
                    Console.Clear();
                    var contacts = viewModel.DisplayAllContacts();

                    foreach(var contact in contacts)
                    {
                        Console.WriteLine($"{contact.Id}\t: {contact.FirstName} {contact.LastName} :{contact.TelephoneNumber}");
                    }
                    break;
                case 'b':
                    {
                        Console.Clear();
                        Console.WriteLine("Enter user firstName");
                        var username = Console.ReadLine();
                        var results = viewModel.DisplaySearchResults(username);
                        foreach (var contact in results)
                        {
                            Console.WriteLine($"{contact.Id}   : {contact.FirstName} {contact.LastName} :{contact.TelephoneNumber}");
                        }
                        break;
                    }
                case'c':
                    Console.Clear();
                    Console.WriteLine("Enter Contact ID");
                    var usernameId = Convert.ToInt32(Console.ReadLine());
                    viewModel.DisplayContactById(usernameId);
                    break;    
                case 'd':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    
                    break;
            }
        }


        static void Loader()
        {
            var rand = new Random();
            for(var x = 0; x<5; x++)
            {
                for (var y= 0;y <4;y++)
                {
                    Console.Write("*");
                    Thread.Sleep(2);
                    
                }
                Console.ForegroundColor =(ConsoleColor) rand.Next(0, 14);

            }
        }
        static void DrawSeparator(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

    }
}
