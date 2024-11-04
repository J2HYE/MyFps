using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class GEnemyZoneInTrigger : MonoBehaviour
    {
        #region Variables
        public Transform gunMan;

        public GameObject enemyZoneOut;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            //�Ǹ� �߰ݽ���
            if (other.tag == "Player")
            {
                if(gunMan != null)
                {
                    gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);

                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            //�Ǹ� �߰ݳ�
            if (other.tag == "Player")
            {
                this.gameObject.SetActive(false);
                enemyZoneOut.SetActive(true);
            }
        }
    }
}