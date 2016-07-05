using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickUt.Model
{
    public class ExerciseType:EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public IEnumerable<Exercise> Exercises { get; set; }
        public ExerciseType()
        {
            Exercises = new List<Exercise>();                
        }        
    }
}
