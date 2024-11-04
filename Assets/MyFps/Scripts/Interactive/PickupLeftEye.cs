using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

namespace MyFps
{
    public class PickupLeftEye : Interactive
    {
        #region Variables
        //∆€¡Ò
        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI puzzleText;

        public GameObject puzzleItemGP;

        public Sprite itemSprite;   //»πµÊ«— æ∆¿Ã≈€ æ∆¿Ãƒ‹
        [SerializeField] private string puzzleStr = "Puzzle Text";  //æ∆¿Ã≈€ »πµÊ æ»≥ª ≈ÿΩ∫∆Æ
        #endregion

        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());
        }

        IEnumerator GainPuzzleItem()
        {
            //∆€¡Ò æ∆¿Ã≈€ »πµÊ
            PlayerStats.Instance.AcquirePuzzleItem(Puzzlekey.LEFTEYE_KEY);

            if(puzzleUI != null)
            {
                //æ∆¿Ã≈€ ∆Æ∏Æ∞≈ ∫Ò»∞º∫»≠
                this.GetComponent<BoxCollider>().enabled = false;
                puzzleItemGP.SetActive(false);

                //UIø¨√‚
                puzzleUI.SetActive(true);
                itemImage.sprite = itemSprite;
                puzzleText.text = puzzleStr;

                yield return new WaitForSeconds(2f);
                puzzleUI.SetActive(false);
            }
            //≈≥
            Destroy(gameObject);
        }

    }
}