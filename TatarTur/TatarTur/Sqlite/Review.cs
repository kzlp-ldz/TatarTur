using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatarTur.Sqlite
{
    [Table("Reviews")]
    public class Review
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Description { get; set; }
        public int IdUser { get; set; }
        public int IdTour  { get; set; }

    }
}
