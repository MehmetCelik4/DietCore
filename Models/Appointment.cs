using System;
using System.ComponentModel.DataAnnotations;

namespace Dietcore.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int DietitianID { get; set; }
        public int CustomerId { get; set; }
        public Dietitian Dietitian { get; set; }
        public Customer Customer { get; set; }








    }
}