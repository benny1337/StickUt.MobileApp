using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickUt.Model
{
    public class EntityBase
    {
        public DateTime CreateOn { get; set; }        
        
        public EntityBase()
        {
            if (CreateOn == default(DateTime))
                CreateOn = DateTime.Now;
        }
    }
}
