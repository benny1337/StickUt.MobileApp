using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickUt.Model
{
    public enum WorkoutStatus
    {
        NotStarted,
        NotGods,
        Good,
        Great
    }

    public enum WorkoutType
    {
        Planned,
        Unplanned
    }

    public class WorkoutTypeFriendyNames
    {
        public static Dictionary<WorkoutType, string> FriendyNames = new Dictionary<WorkoutType, string>()
        {
            { WorkoutType.Planned, "Planerad" },
            { WorkoutType.Unplanned, "Inte plan" },
        };
        
    }
    public class Workout:EntityBase
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime EndedOn { get; set; }
        public WorkoutStatus WorkoutStatus { get; set; }
        public WorkoutType WorkoutType { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public IEnumerable<Exercise> Exercises { get; set; }

        public Workout()
        {
            Exercises = new List<Exercise>();                
        }
    }
}
