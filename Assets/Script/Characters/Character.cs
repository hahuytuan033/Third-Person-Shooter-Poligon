using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne
{

    public class Character : MonoBehaviour
    {
        public Animator anim;
        public string outfitId;

        public CharObject hairObj;
        public CharObject eyebrowsObj;

        GameObject hair;
        GameObject eyebrows;

        public bool isFemale;
        public SkinnedMeshRenderer bodyRenderer;

        public Transform eyebrowsBone;
        List<GameObject> instancedObj =new List<GameObject>();

        public void Init(StatesManager st)
        {
            anim = st.anim;

            hair = LoadCharObject(hairObj);
            eyebrows = LoadCharObject(eyebrowsObj);


        }

        public void LoadCharacter(ResourcesManager r)
        {
            MeshContainer m = r.GetMesh(outfitId);
            LoadMeshContainer(m);
        }

        public GameObject LoadCharObject(CharObject o)
        {
            Transform b = GetBone(o.parentBone);
            GameObject prefab = o.female_prefab;
            if (prefab == null || !isFemale)
            {
                prefab = o.male_prefab;
            }
            GameObject go = Instantiate(prefab);
            go.transform.parent = b;
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;
            instancedObj.Add(go);

            return go;
            
        }

        public void LoadMeshContainer(MeshContainer m)
        {
            bodyRenderer.sharedMesh = (isFemale) ? m.m_fish : m.m_mesh;
            bodyRenderer.sharedMaterial = m.materials;
        }

        public Transform GetBone(MyBones b)
        {
            switch (b)
            {
                case MyBones.head:
                    return anim.GetBoneTransform(HumanBodyBones.Head);
                case MyBones.chest:
                    return anim.GetBoneTransform(HumanBodyBones.Chest);
                case MyBones.eyebrows:
                    return eyebrowsBone;
                case MyBones.rightHand:
                    return anim.GetBoneTransform(HumanBodyBones.RightHand);
                case MyBones.leftHand:
                    return anim.GetBoneTransform(HumanBodyBones.LeftHand);
                case MyBones.rightUpperLeg:
                    return anim.GetBoneTransform(HumanBodyBones.RightUpperLeg);
                case MyBones.hips:
                    return anim.GetBoneTransform(HumanBodyBones.Hips);
                default:
                    return null;
            }
        }
    }
}
