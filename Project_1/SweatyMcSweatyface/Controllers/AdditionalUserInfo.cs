using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweatyMcSweatyface.Controllers
{
    public class AdditionalUserInfo
    {
        private static IAdditionalUserInfo _MoreUserData = new JsonMoreUserData();
        
        public void CreateWorkout(string _UserId, string _WorkoutId, string _WorkoutType,
            string _Duration, string _Description)
        {
            _MoreUserData.AddUserInfo(_UserId, _WorkoutId, _WorkoutType, _Duration, _Description);
        }
    }
    
    public class AdditionalUserInfo
    {
        
    }

    
    public class AdditionalUserInfo
    {
        
    }

    
    public class AdditionalUserInfo
    {
        
    }
}