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
            //마우스 커서 상태 설정
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StartCoroutine(SequencePlay());
        }

        IEnumerator SequencePlay()
        {
            //플레이어 비활성화
            thePlayer.GetComponent<ThirdPersonController>().enabled = false;

            //배경음 시작
            AudioManager.Instance.PlayBgm("PlayBgm");
            //시퀀스 텍스트 초기화
            textBox.text = "";

            yield return new WaitForSeconds(1f);
            fader.FromFade();

            //1초 후 페이드인 효과 시작
            yield return new WaitForSeconds(1f);
            thePlayer.GetComponent<ThirdPersonController>().enabled = true;
        }
    }
}