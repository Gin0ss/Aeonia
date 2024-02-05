using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drunken_Rum_Studios
{
    public class Player_Manager : MonoBehaviour
    {
        #region Variables

        public bool isMoving, isInteracting, isSprinting, isWalking;

        Rigidbody rB;
        Player_Movement pMove;
        Input_Manager iM;
        Player_Animator pA;

        #endregion

        private void Start()
        {
            rB = GetComponent<Rigidbody>();
            pMove = GetComponent<Player_Movement>();
            iM = GetComponent<Input_Manager>();
            pA = GetComponent<Player_Animator>();

        }

        public void UpdateInputChecks()
        {
            isMoving = iM.InputChecks[0];
            isSprinting = iM.InputChecks[1];
            isWalking = iM.InputChecks[2];
            isInteracting = iM.InputChecks[3];

        }

        public void ManageMovement(float delta)
        {
            Vector3 inputDir = iM.GetMoveDirection(delta);
            if (isSprinting) { pMove.SpeedMod = 1.5f; }
            if (isWalking) { pMove.SpeedMod = 0.5f; }
            else { pMove.SpeedMod = 1; }
            float speed = iM.MoveDistance * pMove.SpeedMod;

            rB.MovePosition(pMove.MoveInDirection(rB.position, inputDir, speed, delta));
            pA.UpdateAnimValue("Speed", speed);

        }

    }
}