using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_.NET5.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime DepartureDateTime { get; set; }
        [StringLength(50)]
        public string Room { get; set; }
        public int NumberOfPeople { get; set; }
        [NotMapped]
        public string ArrivalDate => ArrivalDateTime.ToString("mm/dd/yyyy");
        [NotMapped]
        public string ArrivalTime => ArrivalDateTime.ToString("hh:mm:tt");
        [NotMapped]
        public string Departure => DepartureDateTime.ToString("mm/dd/yyyy");
        [NotMapped]
        public string DepartureTime => DepartureDateTime.ToString("hh:mm:tt");
    }
}
