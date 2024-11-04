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
        //����
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

        IEnumerator GainPuzzleItem()
        {
            //���� ������ ȹ��
            PlayerStats.Instance.AcquirePuzzleItem(Puzzlekey.LEFTEYE_KEY);

            if(puzzleUI != null)
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