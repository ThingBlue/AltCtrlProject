using AltCtrl.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AltCtrl.Game
{
    public enum GameState
    {
        NONE = 0,
        SCENE,
        CASE_SELECT,
        PAUSE
    }

    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public GameState gameState = GameState.SCENE;

        private void Awake()
        {
            // Singleton
            if (instance == null) instance = this;
            else Destroy(this);
        }

        private void Start()
        {
            // Subscribe to events
            EventManager.instance.caseStartedEvent.AddListener(onCaseStart);
        }

        private void Update()
        {
            if (InputManager.instance.getKeyDown("caseSelect"))
            {
                // Open case select menu
                if (gameState == GameState.SCENE)
                {
                    gameState = GameState.CASE_SELECT;
                    EventManager.instance.caseSelectMenuOpenedEvent.Invoke();
                }
                // Close case select menu
                else if (gameState == GameState.CASE_SELECT)
                {
                    gameState = GameState.SCENE;
                    EventManager.instance.caseSelectMenuClosedEvent.Invoke();
                }
            }
        }

        private void onCaseStart(string caseName)
        {

        }
    }
}
