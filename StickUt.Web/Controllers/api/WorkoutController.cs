using Microsoft.Azure.Mobile.Server.Config;
using StickUt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StickUt.Web.Controllers.api
{
    [Authorize]
    [MobileAppController]
    public class WorkoutController : ApiController
    {
        public IEnumerable<Workout> Get()
        {
            return new List<Workout>()
            {
                new Workout()
                {
                    WorkoutStatus = WorkoutStatus.Good
                }
            };
        }
    }
}
