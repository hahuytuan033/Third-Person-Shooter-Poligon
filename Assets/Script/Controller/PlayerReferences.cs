using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne
{
    [CreateAssetMenu(menuName = "Tundayne/Single Instances/Player References", fileName = "PlayerReferences")]
    public class PlayerReferences : ScriptableObject
    {
        [Header("HUD")]
        public IntVariable curAmmo;
        public IntVariable curArrying;
        public IntVariable health;

        [Header("States")]
        public BoolVariable isAiming;
        public BoolVariable isLeftPivot;
        public BoolVariable isCrouching;

        [Header("UI")]
        public FloatVariable targetSpread;
        public GameEvent e_UpdateUI;
    }
}

