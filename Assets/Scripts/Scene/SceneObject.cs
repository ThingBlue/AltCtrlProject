using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AltCtrl.Scene
{
    public class SceneObject : MonoBehaviour
    {
        #region Inspector members

        public UnityEvent onSelectEvent;
        public UnityEvent onDeselectEvent;
        public UnityEvent onInteractEvent;

        #endregion
    }
}
