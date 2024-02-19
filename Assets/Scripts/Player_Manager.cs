using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drunken_Rum_Studios
{
    public class Player_Manager : MonoBehaviour
    {
        #region Variables

        public bool isMoving, isInteracting, isSprinting, isWalking;

        public float speedTransitionSmooth = 0.5f;
        const float _walkSpeed = 0.2f, _jogSpeed = 0.55f, _runSpeed = 1;

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

        }

        public void ManageMovement(float delta)
        {
            Vector3 moveDir = iM.GetMoveDirection(delta);
            float moveSpeed = iM.moveInputMagnitude;

            float speedTarget = _jogSpeed;
            if (isSprinting)
            {
                speedTarget = _runSpeed;

            }
            else if (isWalking)
            {
                speedTarget = _walkSpeed;

            }
            moveSpeed *= speedTarget;

            Vector3 movePosition = pMove.MoveInDirection(rB.position, ref moveDir, ref moveSpeed, delta);

            rB.MovePosition(movePosition);
            transform.forward = moveDir;
            pA.UpdateAnimValue("_speed", moveSpeed);

        }

    }
}