using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne
{
    [CreateAssetMenu(menuName = "Tundayne/Character/Mask", fileName = "Mask")]
    public class Mask : ScriptableObject
    {
        public string id;
        public bool enableHair;
        public bool enableEyebrows;
        public CharObject obj;
    }
}

