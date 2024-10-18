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

        //���� ����
        public AudioSource line01;
        public AudioSource line02;  
        #endregion

        void Start ()
        {
            StartCoroutine(PlaySequence());
        }

        //������ ������
        IEnumerator PlaySequence()
        {
            //�÷��� ĳ���� ��Ȱ��ȭ
            thePlayer.GetComponent<ThirdPersonController>().enabled = false;
            //thePlayer.SetActive(false);

            //���̵��� ����(1�� ��� �� ���̵��� ȿ��)
            fader.FromFade(4f);     //5�� ���� ȿ��

            //ȭ�� �ϴܿ� �ó����� �ؽ�Ʈ ���
            textBox.gameObject.SetActive(true);
            textBox.text = sequence01;
            line01.Play();

            yield return new WaitForSeconds(3f);
            textBox.text = sequence02;
            line02.Play();

            //3�� �Ŀ� �ó����� �ؽ�Ʈ ������
            yield return new WaitForSeconds(3f);
            textBox.text = "";
            textBox.gameObject.SetActive(false);


            //�÷��� ĳ���� Ȱ��ȭ 
            thePlayer.GetComponent<ThirdPersonController>().enabled = true;
        }
    }
}
