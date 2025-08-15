using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne
{
    [CreateAssetMenu(menuName = "Tundayne/Variables/String", fileName = "StringVariable")]
    public class StringVariable : ScriptableObject
    {
        public string value;
    }
}

