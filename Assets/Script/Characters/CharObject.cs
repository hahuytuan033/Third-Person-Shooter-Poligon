using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne
{
    [CreateAssetMenu(menuName = "Tundayne/Character/Char Object", fileName = "CharObject")]
    public class CharObject : ScriptableObject
    {
        public string id;
        public MyBones parentBone;
        public GameObject male_prefab;
        public GameObject female_prefab;
    }
}

