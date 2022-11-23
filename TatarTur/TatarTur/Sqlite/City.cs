using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TatarTur.Sqlite
{
    [Table("Cities")]
    public class City
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
