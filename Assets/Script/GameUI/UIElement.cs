using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tundayne.UI
{

    public class UIElement : MonoBehaviour
    {
        UIUpdater updater;

        void Awake()
        {
            updater = UIUpdater.singleton;

            if (updater != null)
            {
                updater.elements.Add(this);
            }
        }

        public virtual void Init()
        {

        }

        public virtual void Tick(float delta)
        {

        }
    }
}
