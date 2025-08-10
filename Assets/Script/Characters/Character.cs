using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne
{
    
    public class Character : MonoBehaviour
    {
        public string outfitId;
        public bool isFemale;
        public SkinnedMeshRenderer bodyRenderer;

        public void LoadCharacter(ResourcesManager r)
        {
            MeshContainer m = r.GetMesh(outfitId);
            LoadMeshContainer(m); 
        }

        public void LoadMeshContainer(MeshContainer m)
        {
            bodyRenderer.sharedMesh = (isFemale) ? m.m_fish : m.m_mesh;
            bodyRenderer.sharedMaterial = m.materials;
        }
    }
}
