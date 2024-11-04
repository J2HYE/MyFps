using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PickUpAmmo : PickUpItem
    {
        #region Varaibles
        [SerializeField] private int giveAmount = 7;

        #endregion

        protected override bool OnPickUp()
        {
            //ÅºÈ¯ 7°³ Áö±Þ
            PlayerStats.Instance.AddAmmo(giveAmount);
            return true;
        }
    }
}
