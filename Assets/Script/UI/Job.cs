using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne
{
    [CreateAssetMenu(fileName = "Job", menuName = "Tundayne/Job")]
    public class Job : ScriptableObject
    {
        public string targetLevel;
        public JobType type;
        public int maxPlayers = 10;

        public string jobDescription;
        public Sprite jobImg;
    }

    public enum JobType
    {
        shootout,
        heist,
        copsNrobbers,
        teamDeathmatch
    }
}

