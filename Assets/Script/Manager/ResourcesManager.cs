using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Tundayne
{
    [CreateAssetMenu(menuName = "Tundayne/Single Instances/Resources Manager", fileName = "ResourcesManager")]
    public class ResourcesManager : ScriptableObject
    {
        public RuntimeReferences runtime;
        public Weapon[] all_weapons;
        Dictionary<string, int> w_dict = new Dictionary<string, int>();
        public MeshContainer[] meshContainers;
        Dictionary<string, int> m_dict = new Dictionary<string, int>();


        public void Init()
        {
            InitWeapons();
        }

        public void InitWeapons()
        {
            for (int i = 0; i < all_weapons.Length; i++)
            {
                if (w_dict.ContainsKey(all_weapons[i].id))
                {

                }
                else
                {
                    w_dict.Add(all_weapons[i].id, i);
                }
            }
        }

        public Weapon GetWeapon(string id)
        {
            Weapon retVal = null;
            int index = -1;
            if (w_dict.TryGetValue(id, out index))
            {
                retVal = all_weapons[index];
            }

            return retVal;
        }

        public void MeshContainers()
        {
            for (int i = 0; i < meshContainers.Length; i++)
            {
                if (m_dict.ContainsKey(meshContainers[i].id))
                {

                }
                else
                {
                    m_dict.Add(meshContainers[i].id, i);
                }
            }
        }

        public MeshContainer GetMesh(string id)
        {
            MeshContainer retVal = null;
            int index = -1;
            if (m_dict.TryGetValue(id, out index))
            {
                retVal = meshContainers[index];
            }
            return retVal;
        }
    }
}
