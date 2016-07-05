using StickUt.Interface;
using StickUt.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickUt.MobileApp.Data.api
{
    public class ExerciseCommunicator: CommunicatorBase
    {
        public ExerciseCommunicator(ILocalStorage store) :base(store) { }

        public async Task<IEnumerable<Exercise>> LoadExercisesAsync(Guid Workoutid)
        {
            return await Task.Factory.StartNew(() => 
            {
                var exercises = _store.Query<Exercise>(x => x.WorkoutId == Workoutid).ToList();
                Debug.WriteLine(exercises[0].ExerciseTypeId);
                var types = _store.Query<ExerciseType>(x => exercises.Select(y => y.ExerciseTypeId).Contains(x.Id)).ToList();   
                var sets = _store.Query<Set>(x => exercises.Select(y => y.Id).Contains(x.ExerciseId));
                foreach (var e in exercises)
                {
                    e.ExerciseType = types.Where(x => x.Id == e.ExerciseTypeId).FirstOrDefault();
                    e.Sets = sets.Where(x => x.ExerciseId == e.Id);
                }
                return exercises;
            });
        }
    }
}
