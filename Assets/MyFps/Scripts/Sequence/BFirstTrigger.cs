using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace MyFps
{
    public class BFirstTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject thePlayer;
        public GameObject theArrow;

        //sequence UI
        public TextMeshProUGUI textBox;
        [SerializeField] private string sequence = "Looks kike a weapon on that table";

        public AudioSource line03;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            //�÷��� ĳ���� ��Ȱ��ȭ
            thePlayer.GetComponent<ThirdPersonController>().enabled = false;

            //��� ���
            textBox.gameObject.SetActive(true);
            textBox.text = sequence;
            line03.Play();

            //1�� ������ 
            yield return new WaitForSeconds(1f);

            //ȭ��ǥ Ȱ��ȭ
            theArrow.SetActive(true);

            //1�� ������
            yield return new WaitForSeconds(1f);

            //�ʱ�ȭ
            textBox.text = "";
            textBox.gameObject.SetActive(false);
            //�÷��� ĳ���� Ȱ��ȭ(�ٽ� �÷���)
            thePlayer.GetComponent<ThirdPersonController>().enabled = true;

            //Ʈ���� �浹ü ��Ȱ��ȭ
            Destroy(gameObject);
            //transform.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
