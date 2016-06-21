using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StickUt.Model
{
    public enum WorkoutStatus
    {
        NotGods,
        Good,
        Great
    }
    public class Workout:EntityBase
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime EndedOn { get; set; }
        public WorkoutStatus WorkoutStatus { get; set; }
    }
}
