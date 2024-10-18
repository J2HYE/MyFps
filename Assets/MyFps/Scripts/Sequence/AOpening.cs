using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

namespace MyFps
{
    public class AOpening : MonoBehaviour
    {
        #region Variables
        public GameObject thePlayer;
        public SceneFader fader;

        //sequence UI
        public TextMeshProUGUI textBox; 
        [SerializeField] private string sequence01 = "...Where am I?";
        [SerializeField] private string sequence02 = "I need get out of here";

        //음성 사운드
        public AudioSource line01;
        public AudioSource line02;  
        #endregion

        void Start ()
        {
            StartCoroutine(PlaySequence());
        }

        //오프닝 시퀀스
        IEnumerator PlaySequence()
        {
            //플레이 캐릭터 비활성화
            thePlayer.GetComponent<ThirdPersonController>().enabled = false;
            //thePlayer.SetActive(false);

            //페이드인 연출(1초 대기 후 페이드인 효과)
            fader.FromFade(4f);     //5초 동안 효과

            //화면 하단에 시나리오 텍스트 출력
            textBox.gameObject.SetActive(true);
            textBox.text = sequence01;
            line01.Play();

            yield return new WaitForSeconds(3f);
            textBox.text = sequence02;
            line02.Play();

            //3초 후에 시나리오 텍스트 없어짐
            yield return new WaitForSeconds(3f);
            textBox.text = "";
            textBox.gameObject.SetActive(false);


            //플레이 캐릭터 활성화 
            thePlayer.GetComponent<ThirdPersonController>().enabled = true;
        }
    }
}
