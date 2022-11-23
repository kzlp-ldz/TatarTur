using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatarTur.Sqlite
{
    [Table("Tours")]
    public class Tour
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }  
        public int IdCity { get; set; }
        public Uri uri { get; set; }
        public string PhotoPath { get; set; }
    }
}
