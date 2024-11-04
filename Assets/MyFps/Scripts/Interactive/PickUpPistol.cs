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

        public GameObject enemyTrigger;
        public GameObject ammoBox;
        public GameObject ammoUI;
        #endregion

        protected override void DoAction()
        {
            arrow.SetActive(false);
            ammoBox.SetActive(true);
            enemyTrigger.SetActive(true);

            //¹«±â È¹µæ
            PlayerStats.Instance.SetHasGun(true);
            ammoUI.SetActive(true);
            realPistol.SetActive(true);

            Destroy(gameObject);
        }
    }
}
