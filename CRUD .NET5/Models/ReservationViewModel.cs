using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Globalization;
using CRUD_.NET5.Migrations;
//using System.Globalization;

namespace CRUD_.NET5.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(100)]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Room { get; set; }
        public int NumberOfPeople { get; set; }
        [Required]
        public string ArrivalDate { get; set; }
        [Required]
        public string ArrivalTime { get; set; }
        [Required]
        public string DepartureDate { get; set; }
        [Required]
        public string DepartureTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }
        public DateTime DepartureDateTime { get; set; }

        //public DateTime ArrivalDateTime => DateTime.ParseExact($"{ArrivalDate} {ArrivalTime}", "yyyy/mm/dd hh:mm", CultureInfo.GetCultureInfo(""));
        //public DateTime DepartureDateTime => DateTime.ParseExact($"{DepartureDate} {DepartureTime}", "mm/dd/yyyy", CultureInfo.GetCultureInfo(""));

        public static implicit operator ReservationViewModel(Reservation v)
        {
            throw new NotImplementedException();
        }
    }
}
