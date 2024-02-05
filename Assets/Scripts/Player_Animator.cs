using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drunken_Rum_Studios
{
    public class Player_Animator : MonoBehaviour
    {
        #region Variables

        Animator anim;

        #endregion
        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void UpdateAnimValue(string valName, float value)
        {
            anim.SetFloat(valName, value);

        }

    }
}
