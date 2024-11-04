using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class EJumpTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject thePlayer;
        
        public GameObject activityObject;       //����� ������Ʈ
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }
        
        IEnumerator PlaySequence()
        {
            //�÷��� ĳ���� ��Ȱ��ȭ(�÷��� ����)
            thePlayer.GetComponent<ThirdPersonController>().enabled = false;
            activityObject.SetActive(true);         //����� ������Ʈ Ȱ��ȭ

            yield return new WaitForSeconds(1f);

            //�÷��� ĳ���� Ȱ��ȭ(�ٽ� �÷���)
            thePlayer.GetComponent<ThirdPersonController>().enabled = true;

            //����� ������Ʈ ų
            Destroy(activityObject);

            //Ʈ���� �浹ü ��Ȱ��ȭ = ų
            Destroy(gameObject);
        }
    }
}
