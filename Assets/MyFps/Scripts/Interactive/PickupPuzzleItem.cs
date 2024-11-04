using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyFps
{
    public class PickupPuzzleItem : Interactive
    {
        #region Variables
        [SerializeField] private Puzzlekey puzzlekey;

        //∆€¡ÒUI
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
        protected IEnumerator GainPuzzleItem()
        {
            //∆€¡Ò æ∆¿Ã≈€ »πµÊ
            PlayerStats.Instance.AcquirePuzzleItem(puzzlekey);

            if (puzzleUI != null)
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
