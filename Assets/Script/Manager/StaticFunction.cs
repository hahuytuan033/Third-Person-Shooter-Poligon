using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tundayne
{
    public static class StaticFunction
    {
        public static string JobTypeToString(JobType t)
        {
            switch (t)
            {
                case JobType.shootout:
                    return "SHOOTOUT";
                case JobType.heist:
                    return "HEIST";
                case JobType.teamDeathmatch:
                    return "TEAM DEATHMATCH";
                default:
                    return "";
            }
        }
    }
}

