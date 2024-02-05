using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Drunken_Rum_Studios
{
    public class Input_Manager : MonoBehaviour
    {
        #region Variables

        bool[] inputChecks = new bool[3];
        public bool[] InputChecks { get; set; }

        public float sensitivityX = 1, sensitivityY = 1, moveDeadzone = 0.1f;

        float moveDistance;
        public float MoveDistance
        {
            get { return moveDistance; }
            set { moveDistance = value; }

        }

        Vector2 moveDir;

        PlayerInput playerInput;

        #endregion

        void OnMovement(InputValue value)
        {
            moveDir = value.Get<Vector2>();
            moveDistance = moveDir.magnitude;
            inputChecks[0] = moveDistance >= moveDeadzone;

        }

        void OnSprint(InputValue value)
        {
            inputChecks[1] = value.Get<bool>();

        }

        void OnWalk(InputValue value)
        {
            inputChecks[2] = value.Get<bool>();

        }

        public Vector3 GetMoveDirection(float delta)
        {
            Vector3 direction = new Vector3(moveDir.x * sensitivityX, 0, moveDir.y * sensitivityY);
            direction.Normalize();
            return direction;

        }

    }
}
