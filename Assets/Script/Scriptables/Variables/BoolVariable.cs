using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne
{
    [CreateAssetMenu(menuName = "Tundayne/Variables/Boolean", fileName = "BoolVariable")]
    public class BoolVariable : ScriptableObject
    {
        public bool value;
    }
}

