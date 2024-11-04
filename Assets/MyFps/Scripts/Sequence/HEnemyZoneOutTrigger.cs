using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class HEnemyZoneOutTrigger : MonoBehaviour
    {
        #region Variables
        public Transform gunMan;
        public GameObject enemyZoneIn;      //In트리거
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            //건맨 GoBack
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
            //In트리거 활성화
            if (other.tag == "Player")
            {
                this.gameObject.SetActive(false);
                enemyZoneIn.SetActive(true);
            }
        }
    }
}