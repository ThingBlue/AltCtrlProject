using AltCtrl.GameCore;
using AltCtrl.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;

namespace AltCtrl.UI
{
    public class SettingsManager : MonoBehaviour
    {
        // Singleton
        public static SettingsManager instance;

        #region Inspector members

        public SettingsData settingsData;

        #endregion

        private void Awake()
        {
            // Singleton
            if (instance == null) instance = this;
            else Destroy(this);
        }

        private void Start()
        {
            // Subscribe to event callbacks

            applyControlsSettings();
        }

        #region Apply settings

        public void applyControlsSettings()
        {
            // Clear current key binds
            InputManager.instance.clearKeyMap();

            // Add every key bind in list to input manger
            foreach (KeyBind keyBind in settingsData.keyBinds)
            {
                InputManager.instance.setKeyListInMap(keyBind.name, keyBind.keys);
            }
        }

        #endregion
    }
}
