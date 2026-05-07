using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GeoPingApp.Models
{
    public class UserLocation
    {

        public UserLocation()
        {
            CreatedAtTicks = DateTime.Now.Ticks;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Note { get; set; }
        public int UserId { get; set; }
        public string Latitude { get; set;  }
        public string Longitude { get; set; }
        public long CreatedAtTicks { get; set; }

        [Ignore]
        public DateTime CreatedAt
        {
            get => new DateTime(CreatedAtTicks, DateTimeKind.Local);
            set => CreatedAtTicks = value.Ticks;
        }
    }
}
