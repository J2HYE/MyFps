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
            //źȯ 7�� ����
            PlayerStats.Instance.AddAmmo(giveAmount);
            return true;
        }
    }
}
