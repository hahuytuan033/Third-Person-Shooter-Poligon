using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Tundayne.UI
{
    public class UIUpdater : MonoBehaviour
    {
        public List<UIElement> elements = new List<UIElement>();
        public static UIUpdater singleton;

        void Awake()
        {
            if (UIUpdater.singleton == null)
            {
                singleton = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }

        void Update()
        {
            float delta = Time.deltaTime;

            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Tick(delta);
            }   
        }
    }
}
