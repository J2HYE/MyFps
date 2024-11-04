using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PickUpRightEye : PickupPuzzleItem
    {
        #region Variables
        public GameObject fakeWall;
        public GameObject exitWall;
        #endregion

        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());

            ShowExit();
        }

        void ShowExit()
        {
            //출구 보이기
            if(PlayerStats.Instance.HasPuzzleItem(Puzzlekey.LEFTEYE_KEY)
                &&PlayerStats.Instance.HasPuzzleItem(Puzzlekey.RIGHTEYE_KEY))
            {
                fakeWall.SetActive(false);
                exitWall.SetActive(true);
            }
        }
    }
}
