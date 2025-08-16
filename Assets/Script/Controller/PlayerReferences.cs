using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne
{
    [CreateAssetMenu(menuName = "Tundayne/Single Instances/Player References", fileName = "PlayerReferences")]
    public class PlayerReferences : ScriptableObject
    {
        public IntVariable curAmmo;
        public IntVariable curArrying;
        public IntVariable health;
        public FloatVariable targetSpread;
        public GameEvent e_UpdateUI;
    }
}

