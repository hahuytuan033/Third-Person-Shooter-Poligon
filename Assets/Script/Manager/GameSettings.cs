using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Tundayne/Single Instances/Game Settings")]
    public class GameSettings : ScriptableObject
    {
        public ResourcesManager r_manager;
        public int version = 0;
        public bool isConnected;
        public UISettings uiSettings;

        public PlayerProfile playerProfile;

        [System.Serializable]
        public class UISettings
        {
            public Job currentJob;
            public GameEvent onJobChanged;
            public StringVariable jobType;
            public StringVariable job_description;
            public SpriteVariable jobImg;
        }

        public void UpdateCurrentjob(Job targetJob)
        {
            uiSettings.currentJob = targetJob;

            uiSettings.job_description.value = targetJob.jobDescription;
            uiSettings.jobType.value = StaticFunction.JobTypeToString(targetJob.type);
            uiSettings.jobImg.sprite = targetJob.jobImg;
            if (uiSettings.onJobChanged != null)
            {
                uiSettings.onJobChanged.Raise();
            }
        }
    }
}

