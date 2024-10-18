using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class EnemyTest : MonoBehaviour
    {
        #region Variables
        //체력
        [SerializeField] private float maxHealth = 20;
        private float currentHealth;

        private bool isDeath = false;
        #endregion

        void Start ()
        {
            //초기화
            currentHealth = maxHealth;
            isDeath = false;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"currenHealth: {currentHealth}");

            //데미지 효과

            if(currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        void Die()
        {
            isDeath = true;

            //죽음처리
            Destroy(gameObject, 3f);
        }
    }
}
