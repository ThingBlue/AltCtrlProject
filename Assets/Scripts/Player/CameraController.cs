using AltCtrl.GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AltCtrl.Player
{
    public class CameraController : MonoBehaviour
    {
        #region Inspector members

        public Vector3 targetRotation;
        public float slerpTime;

        #endregion

        private Vector3 velocity;

        private void Update()
        {
            if (InputManager.instance.getKeyDown("left"))
            {
                targetRotation.y -= 90;
            }
            if (InputManager.instance.getKeyDown("right"))
            {
                targetRotation.y += 90;
            }
        }

        private void LateUpdate()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation), slerpTime);
        }
    }
}
