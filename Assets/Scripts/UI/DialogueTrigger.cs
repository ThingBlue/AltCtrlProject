using AltCtrl.GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AltCtrl.UI
{
    public class DialogueTrigger : MonoBehaviour
    {
        #region Inspector members

        public List<Monologue> dialogue;

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
            DialogueManager.instance.triggerDialogue(dialogue);
        }
    }
}
