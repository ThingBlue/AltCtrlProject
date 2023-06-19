using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AltCtrl.Scene
{
    [Serializable]
    public class SceneArea
    {
        public string name;
        public List<SceneObject> sceneObjects;
        public string leftScene;
        public string rightScene;
        public float yRotation;
    }
}
