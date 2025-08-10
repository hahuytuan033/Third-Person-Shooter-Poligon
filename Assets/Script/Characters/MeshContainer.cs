using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne
{
    [CreateAssetMenu(fileName = "MeshContainer", menuName = "Tundayne/Character/MeshContainer", order = 1)]
    public class MeshContainer : ScriptableObject
    {
        public string id;
        public Mesh m_mesh;
        public Mesh m_fish;
        public Material materials;
    }
}

