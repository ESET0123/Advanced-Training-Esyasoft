using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Movie
    {
        string movieName;
        int totalSeats;
        int bookedSeats;

        public Movie(string movieName, int totalSeats, int bookedSeats=0)
        {
            this.movieName = movieName;
            this.totalSeats = totalSeats;
            this.bookedSeats = bookedSeats;
        }
        public void BookSeats(int count) {
            this.bookedSeats = this.bookedSeats + count;
            Console.WriteLine($"{count} seats booked");

        }
        public void CancelSeats(int count) {
            this.bookedSeats = this.bookedSeats - count;
            Console.WriteLine($"{count} seats cancelled");
        }
        public void DisplayAvailableSeats()
        {
            Console.WriteLine($"Movie Name: {this.movieName}");
            Console.WriteLine($"Total Seats: {this.totalSeats}");
            Console.WriteLine($"Booked Seats: {this.bookedSeats}");
            Console.WriteLine($"Remaining Seats: {this.totalSeats - this.bookedSeats}");
        }
    }
}
