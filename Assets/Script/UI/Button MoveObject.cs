using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tundayne
{
    public class ButtonMoveObject : MonoBehaviour
    {
        public Transform playerTransform;
        public Transform movePosition;

        public void MovePlayer()
        {
            playerTransform.position = movePosition.position;
            playerTransform.rotation = movePosition.rotation;
        }
    }
}

