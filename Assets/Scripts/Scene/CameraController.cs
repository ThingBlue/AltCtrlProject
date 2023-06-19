using AltCtrl.GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AltCtrl.Scene
{
    public class CameraController : MonoBehaviour
    {
        #region Inspector members

        public float slerpTime;

        #endregion

        public Vector3 targetRotation = Vector3.zero;

        private void LateUpdate()
        {
            //targetRotation = transform.rotation.eulerAngles;
            targetRotation.y = SceneManager.instance.activeScene.yRotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation), slerpTime);
        }
    }
}
