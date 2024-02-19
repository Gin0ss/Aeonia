using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drunken_Rum_Studios
{
    public class Player_Movement : MonoBehaviour
    {
        #region Variables

        public float baseSpeed = 1, turnDirSmooth = 0.25f, turnDirSpeed = 2;
        float speedMod = 1;

        #endregion

        public Vector3 MoveInDirection(Vector3 position, ref Vector3 moveDir, ref float speed, float delta)
        {
            Vector3 targetDirection = transform.forward;
            moveDir = ChangePlayerDirection(moveDir, delta);

            targetDirection = Vector3.Lerp(targetDirection, moveDir, turnDirSmooth * delta);
            targetDirection.y = 0;
            targetDirection.Normalize();

            speed *= speedMod;
            position += targetDirection * moveDir.magnitude * speed * baseSpeed * delta;

            return position;

        }

        public Vector3 ChangePlayerDirection(Vector3 moveDir, float delta)
        {
            Vector3 targetDir = transform.forward;
            targetDir = Vector3.Lerp(targetDir, moveDir, turnDirSmooth * (delta * 60));

            return targetDir;

        }

    }
}
