using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PickupKey : Interactive
    {
        #region Variables
        #endregion

        protected override void DoAction()
        {
            //key Item ¿˙¿Â
            PlayerStats.Instance.AcquirePuzzleItem(Puzzlekey.ROOM01_KEY);

            //≈≥
            Destroy(gameObject);
        }
    }
}
