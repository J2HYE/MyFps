using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyFps
{
    public class BreakableObject : MonoBehaviour, IDamageable
    {
        #region Varialbes
        public GameObject fakeObject;       //������ ������Ʈ
        public GameObject breakObject;      //���� ������Ʈ
        public GameObject effectObject;     //������ ������ ȿ�� ������Ʈ

        public GameObject hiddenItem;       //������ ������

        private bool isBreak = false;       
        [SerializeField] private bool unBreakalbe = false;  //true: ������ �ʴ´�
        #endregion

        //�� ������
        public void TakeDamage(float damage)
        {
            //���� ���� üũ
            if (unBreakalbe)
                return;
            
            //������ų
            if(!isBreak)
            {
                StartCoroutine(BreakObject());
            }            
        }

        IEnumerator BreakObject()
        {
            isBreak = true;
            this.GetComponent<BoxCollider>().enabled = false;

            fakeObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);

            AudioManager.Instance.Play("PotterySmash");
            breakObject.SetActive(true);

            if(effectObject != null)
            {
                effectObject.SetActive(true);

                yield return new WaitForSeconds(0.1f);
                effectObject.SetActive(false);
            }         
            
            //������ ������ ������ ������ �����ֱ�
            if(hiddenItem != null)
            {
                hiddenItem.SetActive(true);
            }
        }
    }
}
