using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne
{
    [CreateAssetMenu(menuName = "Tundayne/Variables/Float", fileName = "FloatVariable")]
    public class FloatVariable : ScriptableObject
    {
        public float value;

        public void Apply(FloatVariable v)
        {
            value += v.value;
        }

        public void Apply(float v)
        {
            value += v;
    
        }
    }
}
