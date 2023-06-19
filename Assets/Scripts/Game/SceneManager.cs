using AltCtrl.Common;
using AltCtrl.Scene;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace AltCtrl.Game
{
    public class SceneManager : MonoBehaviour
    {
        public static SceneManager instance;

        #region Inspector members

        public List<SceneArea> sceneAreas;

        #endregion

        [ReadOnly]
        public SceneArea activeScene = null;
        [ReadOnly]
        public int selectedObjectIndex = -1;

        private void Awake()
        {
            // Singleton
            if (instance == null) instance = this;
            else Destroy(this);
        }

        private void Start()
        {
            // Set starting scene
            if (sceneAreas.Count > 0) activeScene = sceneAreas[0];
            else Debug.LogError("No scenes found in SceneManager");

            // Subscribe to events
        }

        private void Update()
        {
            switch (GameManager.instance.gameState)
            {
                case GameState.NONE:
                    break;
                case GameState.SCENE:
                    handleSceneInput();
                    break;
                case GameState.CASE_SELECT:
                    break;
                case GameState.PAUSE:
                    break;
                default:
                    break;
            }

        }

        private void handleSceneInput()
        {
            // Handle input
            // Scene switching
            if (InputManager.instance.getKeyDown("leftScene"))
            {
                activeScene = sceneAreas.Find((scene) => scene.name == activeScene.leftScene);
                EventManager.instance.sceneSwitchedEvent.Invoke();
            }
            if (InputManager.instance.getKeyDown("rightScene"))
            {
                activeScene = sceneAreas.Find((scene) => scene.name == activeScene.rightScene);
                EventManager.instance.sceneSwitchedEvent.Invoke();
            }

            // Object selecting
            if (InputManager.instance.getKeyDown("leftObject"))
            {
                // Invoke deselect callback
                if (selectedObjectIndex != -1) activeScene.sceneObjects[selectedObjectIndex].onDeselectEvent.Invoke();

                // First selection of the scene, select leftmost object
                if (selectedObjectIndex == -1) selectedObjectIndex = 0;
                // Leftmost object is currently selected, loop around to rightmost object
                else if (selectedObjectIndex == 0) selectedObjectIndex = activeScene.sceneObjects.Count - 1;
                // Select object to the left of current object
                else selectedObjectIndex--;

                // Invoke select callback
                activeScene.sceneObjects[selectedObjectIndex].onSelectEvent.Invoke();
                EventManager.instance.objectSelectedEvent.Invoke();
            }
            if (InputManager.instance.getKeyDown("rightObject"))
            {
                // Invoke deselect callback
                if (selectedObjectIndex != -1) activeScene.sceneObjects[selectedObjectIndex].onDeselectEvent.Invoke();

                // First selection of the scene, select rightmost object
                if (selectedObjectIndex == -1) selectedObjectIndex = activeScene.sceneObjects.Count - 1;
                // Rightmost object is currently selected, loop around to leftmost object
                else if (selectedObjectIndex == activeScene.sceneObjects.Count - 1) selectedObjectIndex = 0;
                // Select object to the right of current object
                else selectedObjectIndex++;

                // Invoke select callback
                activeScene.sceneObjects[selectedObjectIndex].onSelectEvent.Invoke();
                EventManager.instance.objectSelectedEvent.Invoke();
            }

            // Object interaction
            if (InputManager.instance.getKeyDown("interact"))
            {
                if (selectedObjectIndex != -1)
                {
                    activeScene.sceneObjects[selectedObjectIndex].onInteractEvent.Invoke();
                    EventManager.instance.objectInteractedEvent.Invoke();
                }
            }
        }

    }
}
