using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Movie_Group_project
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, DateTime> filmRental = new Dictionary<string, DateTime>();
            string answer1 = "Squirrels are amazing";//Variable needs to be set to something, even though this information is not relevant. 
                                                    //But this line is still important because squirrels.

            while (answer1 != "close")
            {
                Console.WriteLine("enter add, returns, overdue, close");
                string answerxx = Console.ReadLine();
                answer1 = answerxx.ToLower();
                if (answer1 == "add")
                {
                    addEntries(filmRental); //calling method to add entry
                }

                else if (answer1 == "overdue")
                {
                    printOverdue(filmRental);
                    // calling method to print all overdue
                }
                else if (answer1 == "returns")
                {
                    returns(filmRental);
                }

                else
                {
                    Console.WriteLine("Check syntax or spelling.");
                }


            }


        } //closing for main 
        static void printOverdue(Dictionary<string, DateTime> filmRental)  //method that prints overdue
        {
            foreach (KeyValuePair<string, DateTime> film in filmRental)
            {
                DateTime x = DateTime.Now.AddDays(6); //if after due date negative number using 6 prints negative 
                DateTime kValue = film.Value;
                int diff = DateTime.Compare(kValue, x);     //prints overdue movies
                if (diff == -1)
                {
                    Console.WriteLine(film + " is overdue");
                }
                else
                {
                    continue;
                }
            }
        }  //closing for overdue method


        static Dictionary<string, DateTime> addEntries(Dictionary<string, DateTime> filmRental)  //add entries method 
        {

            DateTime dueDate2 = DateTime.Now.Date.AddDays(3);  //prints as overdue 
                                                               //  DateTime dueDate = DateTime.Now.Date.AddDays(7); //value of the key

            // filmRental.Add(" tim, donut", dueDate2);
            // filmRental.Add(" tom, snow piercer", dueDate);
            // return filmRental;





            Console.WriteLine("Enter the customer's name.");
            string key = Console.ReadLine();   //asigning the input to the key



            DateTime dueDate = DateTime.Now.Date.AddDays(7); //value of the key 
            //We can change the 7 to a 3 if we wish to demonstrate the overdue feature. 
//If we were running this program in real time, it would probably be good for us to change the due date to 3. 
//Right now we are comparing this to x (DateTimeNow + 6). So if we Want to run in real time, we can make the overdue date whatever day we want. 

            filmRental.Add(key, dueDate);  //adding entry to the dictionary 
            Console.WriteLine("Entry added.");
            return filmRental;

        }




        static Dictionary<string, DateTime> returns(Dictionary<string, DateTime> filmRental)  //add entries method 
        {
            Console.WriteLine("Enter the customer's name to return the movie.");

            string returnedMovie = Console.ReadLine();
            if (filmRental.ContainsKey(returnedMovie))
            {


                DateTime x = DateTime.Now.AddDays(6); //if after due date negative number using 6 prints negative//This is for testing purposes. If we were doing this in real time, we could remove .AddDays.
                DateTime kValue = filmRental[returnedMovie];
                int diff = DateTime.Compare(kValue, x);     //prints overdue movies
                if (diff == -1) //if the difference between the due date (entry date plus 7 days) and the variable x(entry date plus 6 days) is -1 or more, the person owes extra monies. Program only prints +1 or -1, regardless of how late the film actually is.
                { 
                    Console.WriteLine(returnedMovie + " is overdue and owes $7");

                }
                else
                {
                    Console.WriteLine(returnedMovie + " owes $5");
                }

            }
            else
            {
                Console.WriteLine("Entry Not Found");
            }
            filmRental.Remove(returnedMovie);
            return filmRental;

        }
    }
}


