using AltCtrl.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AltCtrl.Game
{
    public class CaseManager : MonoBehaviour
    {
        #region Inspector members

        public RectTransform caseSelectPanelTransform;
        public float caseSelectMenuSmoothTime;

        #endregion

        public string activeCase = "";

        public float targetY;
        private float velocity;

        private void Start()
        {
            // Subscribe to events
            EventManager.instance.caseSelectMenuOpenedEvent.AddListener(onCaseSelectMenuOpened);
            EventManager.instance.caseSelectMenuClosedEvent.AddListener(onCaseSelectMenuClosed);
        }

        private void FixedUpdate()
        {
            Vector3 targetPosition = caseSelectPanelTransform.localPosition;
            targetPosition.y = Mathf.SmoothDamp(targetPosition.y, targetY, ref velocity, caseSelectMenuSmoothTime);
            caseSelectPanelTransform.localPosition = targetPosition;
        }

        private void onCaseSelectMenuOpened()
        {
            targetY = 0;
        }

        private void onCaseSelectMenuClosed()
        {
            targetY = Screen.height;
        }
    }
}
