using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyFps
{
    public class BreakableObject : MonoBehaviour, IDamageable
    {
        #region Varialbes
        public GameObject fakeObject;       //온전한 오브젝트
        public GameObject breakObject;      //깨진 오브젝트
        public GameObject effectObject;     //깨지는 움직임 효과 오브젝트

        public GameObject hiddenItem;       //숨겨진 아이템

        private bool isBreak = false;       
        [SerializeField] private bool unBreakalbe = false;  //true: 깨지지 않는다
        #endregion

        //총 맞으면
        public void TakeDamage(float damage)
        {
            //깨짐 여부 체크
            if (unBreakalbe)
                return;
            
            //원샷원킬
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
            
            //숨겨진 아이템 있으면 아이템 보여주기
            if(hiddenItem != null)
            {
                hiddenItem.SetActive(true);
            }
        }
    }
}
