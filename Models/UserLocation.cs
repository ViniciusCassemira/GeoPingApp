using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GeoPingApp.Models
{
    public class UserLocation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Note { get; set; }
        public int UserId { get; set; }
        public string Latitude { get; set;  }
        public string Longitude { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
    }
}
