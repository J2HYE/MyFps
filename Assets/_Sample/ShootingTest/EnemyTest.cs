using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class EnemyTest : MonoBehaviour
    {
        #region Variables
        //ü��
        [SerializeField] private float maxHealth = 20;
        private float currentHealth;

        private bool isDeath = false;
        #endregion

        void Start ()
        {
            //�ʱ�ȭ
            currentHealth = maxHealth;
            isDeath = false;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"currenHealth: {currentHealth}");

            //������ ȿ��

            if(currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        void Die()
        {
            isDeath = true;

            //����ó��
            Destroy(gameObject, 3f);
        }
    }
}
