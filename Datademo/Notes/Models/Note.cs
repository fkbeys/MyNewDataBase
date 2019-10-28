using System;
using SQLite;

namespace Notes.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        [Unique]
        public DateTime Date { get; set; }

        public  string Gender { get; set; }
    }
}
