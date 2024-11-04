using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyFps
{
    public class FullExitEye : Interactive
    {
        #region Varialbes
        public GameObject emptyPicture;
        public GameObject fullPicture;

        public Animator exitWallAnimator;

        public GameObject exitTrigger;

        public TextMeshProUGUI textBox;
        [SerializeField] private string puzzleStr = "You need more Eye Pictures";
        #endregion

        protected override void DoAction()
        {
            //���� ������ ��� �������
            if (PlayerStats.Instance.HasPuzzleItem(Puzzlekey.LEFTEYE_KEY)
                && PlayerStats.Instance.HasPuzzleItem(Puzzlekey.RIGHTEYE_KEY))
            {
                //�ⱸ ����
                StartCoroutine(OpenExitWall());
            }
            else
            {
                //�޽��� ���
                StartCoroutine(LockedExitWall());
            }
        }

        IEnumerator OpenExitWall()
        {
            //�ϼ��� �׸� ���̱�
            emptyPicture.SetActive(false);
            fullPicture.SetActive(true);

            //�ⱸ ������
            exitWallAnimator.SetBool("IsOpen", true);
            yield return new WaitForSeconds(0.5f);

            //exitƮ���� Ȱ��ȭ
            exitTrigger.SetActive(true);
        }

        IEnumerator LockedExitWall()
        {
            textBox.gameObject.SetActive(true);
            textBox.text = puzzleStr;

            yield return new WaitForSeconds(2f);

            textBox.text = "";
            textBox.gameObject.SetActive(false);
        }
    }
}
