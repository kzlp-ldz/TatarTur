using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatarTur.Sqlite
{
    [Table("Tickets")]
    public class Ticket
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public DateTime TourDate { get; set; }
        public int IdTour { get; set; }
    }
}
