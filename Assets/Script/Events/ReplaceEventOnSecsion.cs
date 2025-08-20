using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne
{
    public class ReplaceEventOnSecsion : MonoBehaviour
    {
        public SecsionManager sess;
        public GameEvent targetEvent;

        public void ReplaceSceneSingleEvent()
        {
            sess.onSceneLoadedSingle = targetEvent;
        }

        public void ReplaceSceneAdditiveEvent()
        {
            sess.onSceneLoadedAdditive = targetEvent;
        }
    }
}

