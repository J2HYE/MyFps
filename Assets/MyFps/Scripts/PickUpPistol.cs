using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class PickUpPistol : Interactive
    {
        #region Varialbes
        //Action
        public GameObject realPistol;
        public GameObject arrow;
        #endregion

        protected override void DoAction()
        {
            realPistol.SetActive(true);
            arrow.SetActive(false);
            Destroy(gameObject);
        }
    }
}
