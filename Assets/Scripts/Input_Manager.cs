using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Drunken_Rum_Studios
{
    public class Input_Manager : MonoBehaviour
    {
        #region Variables

        public bool[] InputChecks { get; set; } = new bool[3];

        public float sensitivityX = 1, sensitivityY = 1, moveDeadzone = 0.1f;

        public float moveInputMagnitude { get; set; }

        Vector2 moveDir;

        PlayerInput playerInput;

        #endregion

        void OnMovement(InputValue value)
        {
            moveDir = value.Get<Vector2>();
            moveInputMagnitude = moveDir.magnitude;

            InputChecks[0] = moveInputMagnitude >= moveDeadzone;

        }

        void OnSprint(InputValue value)
        {
            InputChecks[1] = value.isPressed;

        }

        void OnWalk(InputValue value)
        {
            InputChecks[2] = value.isPressed;

        }

        public Vector3 GetMoveDirection(float delta)
        {
            Vector3 direction = new Vector3(moveDir.x * sensitivityX, 0, moveDir.y * sensitivityY);
            direction.Normalize();
            return direction;

        }

    }
}
