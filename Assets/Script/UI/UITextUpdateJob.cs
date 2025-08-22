using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tundayne
{
    public class UITextUpdateJob : MonoBehaviour
    {
        public Text modeType;
        public Text levelName;
        public Text currentPlayers;
        public Text maxPlayers;
        public Job targetJob;

        void Start()
        {
            LoadJob(targetJob);
        }

        public void LoadJob(Job j)
        {
            targetJob = j;
            modeType.text = StaticFunction.JobTypeToString(j.type);
            levelName.text = j.targetLevel;
        }

        public void UpdatejobOnGamesettings()
        {
            GameSettings gs = Resources.Load("GameSettings") as GameSettings;
            gs.UpdateCurrentjob(targetJob);
        }
    }
}
