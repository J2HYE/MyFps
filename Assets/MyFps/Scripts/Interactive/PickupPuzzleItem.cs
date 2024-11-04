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

        //����UI
        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI puzzleText;

        public GameObject puzzleItemGP;
                
        public Sprite itemSprite;   //ȹ���� ������ ������
        [SerializeField] private string puzzleStr = "Puzzle Text";  //������ ȹ�� �ȳ� �ؽ�Ʈ
        #endregion

        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());
        }
        protected IEnumerator GainPuzzleItem()
        {
            //���� ������ ȹ��
            PlayerStats.Instance.AcquirePuzzleItem(puzzlekey);

            if (puzzleUI != null)
            {
                //������ Ʈ���� ��Ȱ��ȭ
                this.GetComponent<BoxCollider>().enabled = false;
                puzzleItemGP.SetActive(false);

                //UI����
                puzzleUI.SetActive(true);
                itemImage.sprite = itemSprite;
                puzzleText.text = puzzleStr;

                yield return new WaitForSeconds(2f);
                puzzleUI.SetActive(false);
            }
            //ų
            Destroy(gameObject);
        }
    }
}
