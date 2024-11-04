using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class HEnemyZoneOutTrigger : MonoBehaviour
    {
        #region Variables
        public Transform gunMan;
        public GameObject enemyZoneIn;      //InƮ����
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            //�Ǹ� GoBack
            if (other.tag == "Player")
            {
                if(gunMan != null)
                {
                    gunMan.GetComponent<Enemy>().GoStartPosition();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            //InƮ���� Ȱ��ȭ
            if (other.tag == "Player")
            {
                this.gameObject.SetActive(false);
                enemyZoneIn.SetActive(true);
            }
        }
    }
}