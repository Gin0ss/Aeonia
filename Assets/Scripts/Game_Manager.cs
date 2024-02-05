using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drunken_Rum_Studios
{
    public class Game_Manager : MonoBehaviour
    {
        #region Variables

        public Player_Manager pMgr;

        #endregion

        #region Singleton

        static Game_Manager instance;
        void Awake()
        {
            if (instance == null) instance = this;
            else if (instance != this) Destroy(this);

        }
        #endregion

        void FixedUpdate()
        {
            float delta = Time.deltaTime;

            GameLoop(delta);

        }

        void GameLoop(float delta)
        {
            pMgr.ManageMovement(delta);
            pMgr.UpdateInputChecks();

        }

    }
}
