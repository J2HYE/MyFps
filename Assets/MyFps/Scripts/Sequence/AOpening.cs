using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyFps
{
    public class AOpening : MonoBehaviour
    {
        #region Variables
        public GameObject thePlayer;
        public SceneFader fader;

        //sequence UI
        public TextMeshProUGUI textBox; 
        [SerializeField] private string sequence = "I need get out of here";
        #endregion

        void Start ()
        {
            StartCoroutine(PlaySequence());
        }

        //������ ������
        IEnumerator PlaySequence()
        {
            //�÷��� ĳ���� ��Ȱ��ȭ
            thePlayer.SetActive(false);

            //���̵��� ����(1�� ��� �� ���̵��� ȿ��)
            fader.FromFade(1f);     //2�� ���� ȿ��

            //ȭ�� �ϴܿ� �ó����� �ؽ�Ʈ ���
            textBox.gameObject.SetActive(true);
            textBox.text = sequence;

            //3�� �Ŀ� �ó����� �ؽ�Ʈ ������
            yield return new WaitForSeconds(3f);
            textBox.gameObject.SetActive(false);


            //�÷��� ĳ���� Ȱ��ȭ 
            thePlayer.SetActive(true);
        }
    }
}
