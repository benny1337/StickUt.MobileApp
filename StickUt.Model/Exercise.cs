using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickUt.Model
{
    public class Exercise : EntityBase
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [ManyToOne(foreignKey: "WorkoutId", CascadeOperations = CascadeOperation.All)]
        public Workout Workout { get; set; }

        [ForeignKey(typeof(Workout))]
        public Guid WorkoutId { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public IEnumerable<Set> Sets { get; set; }

        [ManyToOne(foreignKey: "WorkoutId", CascadeOperations = CascadeOperation.All)]
        public ExerciseType ExerciseType { get; set; }

        [ForeignKey(typeof(ExerciseType))]
        public Guid ExerciseTypeId { get; set; }

        public Exercise()
        {
            Sets = new List<Set>();
        }
    }
}
