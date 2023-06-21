using AltCtrl.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace AltCtrl.UI
{
    [CreateAssetMenu]
    public class SettingsData : ScriptableObject
    {
        [Header("CONTROLS")]
        public List<KeyBind> keyBinds;
    }
}
