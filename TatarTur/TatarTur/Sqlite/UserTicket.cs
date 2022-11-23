using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TatarTur.Sqlite
{
    [Table("UserTickets")]
    public class UserTicket
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdTicket { get; set; }
    }
}
