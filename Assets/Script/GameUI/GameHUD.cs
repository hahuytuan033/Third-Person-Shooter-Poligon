using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tundayne;

namespace Tundayne.UI
{
    public class GameHUD : UIElement
    {
        public BoolVariable isAiming;
        public BoolVariable isLeftPivot;

        public Transform normalPosition_right;
        public Transform normalPosition_left;
        public Transform aimPosition;
        public float moveSpeed = 4;
        public Transform hud;

        public override void Tick(float delta)
        {
            base.Tick(delta);

            Vector3 tp = (isLeftPivot) ? normalPosition_left.localPosition : normalPosition_right.localPosition;
            Quaternion tr = (isLeftPivot) ? normalPosition_left.localRotation : normalPosition_right.localRotation;

            if (isAiming.value)
            {
                tp = aimPosition.localPosition;
                tr = aimPosition.localRotation;
            }

            float t = delta * moveSpeed;

            Vector3 targetPosition = Vector3.Lerp(hud.localPosition, tp, t);
            Quaternion targetRotation = Quaternion.Slerp(hud.localRotation, tr, t);
            hud.localPosition = targetPosition;
            hud.localRotation = targetRotation;
        }
    }
}

