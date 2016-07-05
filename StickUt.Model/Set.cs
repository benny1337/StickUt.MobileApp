using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickUt.Model
{
    public class Set
    {
        public int Reps { get; set; }

        [ManyToOne(foreignKey: "ExerciseId", CascadeOperations = CascadeOperation.All)]
        public Exercise Exercise { get; set; }

        [ForeignKey(typeof(ExerciseType))]
        public Guid ExerciseId { get; set; }
    }
}
