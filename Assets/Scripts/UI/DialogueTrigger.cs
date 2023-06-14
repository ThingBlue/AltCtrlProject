using AltCtrl.GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AltCtrl.UI
{
    public class DialogueTrigger : MonoBehaviour
    {
        #region Inspector members

        public List<Dialogue> dialogues;

        #endregion

        private void Update()
        {
            // DEBUG
            if (InputManager.instance.getKeyDown("startDialogue"))
            {
                TriggerDialogue();
            }
        }

        public void TriggerDialogue()
        {
            if (dialogues.Count > 0) DialogueManager.instance.triggerDialogue(dialogues[0], dialogues);
        }
    }
}
