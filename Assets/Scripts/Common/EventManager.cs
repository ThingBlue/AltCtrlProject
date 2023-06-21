using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * STEPS FOR USING UNITY EVENTS:
 *     1. ADD NEW EVENT
 *         public UnityEvent eventName;
 *     2. INITIALIZE EVENT
 *         if (eventName == null) eventName = new UnityEvent();
 *     3. ADD LISTENER TO EVENT
 *         EventManager.instance.eventName.AddListener(eventCallbackName);
 *     4. INVOKE EVENT CALLBACKS
 *         EventManager.instance.eventName.Invoke();
 */

namespace AltCtrl.Common
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager instance;

        #region Game events

        public UnityEvent pausedEvent;
        public UnityEvent unpausedEvent;

        public UnityEvent caseSelectMenuOpenedEvent;
        public UnityEvent caseSelectMenuClosedEvent;

        public UnityEvent<string> caseStartedEvent;

        public UnityEvent sceneSwitchedEvent;
        public UnityEvent objectSelectedEvent;
        public UnityEvent objectInteractedEvent;

        #endregion

        #region Dialogue events

        public UnityEvent dialogueTriggered;
        public UnityEvent dialogueOptionSelected;

        #endregion

        private void Awake()
        {
            // Singleton
            if (instance == null) instance = this;
            else Destroy(this);
        }

        private void Start()
        {
            // Initialize events
            if (pausedEvent == null) pausedEvent = new UnityEvent();
            if (unpausedEvent == null) unpausedEvent = new UnityEvent();

            if (caseSelectMenuOpenedEvent == null) caseSelectMenuOpenedEvent = new UnityEvent();
            if (caseSelectMenuClosedEvent == null) caseSelectMenuClosedEvent = new UnityEvent();

            if (caseStartedEvent == null) caseStartedEvent = new UnityEvent<string>();

            if (sceneSwitchedEvent == null) sceneSwitchedEvent = new UnityEvent();
            if (objectSelectedEvent == null) objectSelectedEvent = new UnityEvent();
            if (objectInteractedEvent == null) objectInteractedEvent = new UnityEvent();

            if (dialogueTriggered == null) dialogueTriggered = new UnityEvent();
            if (dialogueOptionSelected == null) dialogueOptionSelected = new UnityEvent();
        }
    }
}
