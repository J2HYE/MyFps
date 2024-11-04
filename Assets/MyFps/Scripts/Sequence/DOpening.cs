using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

namespace MyFps
{
    public class DOpening : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        public GameObject thePlayer;
        public TextMeshProUGUI textBox;
        #endregion

        private void Start()
        {
            //���콺 Ŀ�� ���� ����
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StartCoroutine(SequencePlay());
        }

        IEnumerator SequencePlay()
        {
            //�÷��̾� ��Ȱ��ȭ
            thePlayer.GetComponent<ThirdPersonController>().enabled = false;

            //����� ����
            AudioManager.Instance.PlayBgm("PlayBgm");
            //������ �ؽ�Ʈ �ʱ�ȭ
            textBox.text = "";

            yield return new WaitForSeconds(1f);
            fader.FromFade();

            //1�� �� ���̵��� ȿ�� ����
            yield return new WaitForSeconds(1f);
            thePlayer.GetComponent<ThirdPersonController>().enabled = true;
        }
    }
}