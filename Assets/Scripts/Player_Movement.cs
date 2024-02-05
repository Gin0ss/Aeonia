using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drunken_Rum_Studios
{
    public class Player_Movement : MonoBehaviour
    {
        #region Variables

        public float baseSpeed = 1;
        float speedMod = 1;

        #endregion

        public float SpeedMod
        {
            get { return speedMod * baseSpeed; }
            set { speedMod = value;}

        }

        public Vector3 MoveInDirection(Vector3 position, Vector3 moveDir, float speed, float delta)
        {
            position += moveDir * speed * delta;
            return position;

        }

    }
}
