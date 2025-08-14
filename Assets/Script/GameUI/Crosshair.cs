using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Tundayne.UI
{
    public class Crosshair : UIElement
    {
        public float targetSpread = 30;
        public float maxSpread = 80;
        public float spreadSpeed = 5;
        public Parts[] parts;

        float t;
        float curSpread;

        public override void Tick(float delta)
        {
            t = delta * spreadSpeed;
            curSpread = Mathf.Lerp(curSpread, targetSpread, t);
            for (int i = 0; i < parts.Length; i++)
            {
                Parts p = parts[i];
                p.trans.anchoredPosition = p.pos * curSpread;
            }
        }

        [System.Serializable]
        public class Parts
        {
            public RectTransform trans;
            public Vector2 pos;
        }
    }

}
