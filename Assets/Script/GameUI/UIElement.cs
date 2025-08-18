using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tundayne.UI
{

    public class UIElement : MonoBehaviour
    {
        UIUpdater updater;

        void Start()
        {
            updater = UIUpdater.singleton;

            if (updater != null)
            {
                updater.elements.Add(this);
            }

            Init();
        }

        public virtual void Init()
        {

        }

        public virtual void Tick(float delta)
        {

        }
    }
}
