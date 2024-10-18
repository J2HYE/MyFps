using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace MyFps
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "GameOver";

        //ü��
        [SerializeField] private float maxHealth = 20;
        private float currentHealth;

        private bool isDeath = false;

        //������ ȿ��
        public GameObject damageFlash;      //������ �÷��� ȿ��
        public AudioSource hurt01;     //������ �Ҹ�1
        public AudioSource hurt02;     //������ �Ҹ�2
        public AudioSource hurt03;     //������ �Ҹ�3
        #endregion

        private void Start()
        {
            //�ʱ�ȭ
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"Player Health:{currentHealth}");

            //������ ȿ��
            StartCoroutine(DamageEffect());

            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        void Die()
        {
            fader.FadeTo(loadToScene);
            //isDeath = true;

            //SetState(RobotState.R_Death);
        }

        IEnumerator DamageEffect()
        {
            damageFlash.SetActive(true);

            int randNumber = Random.Range(1, 4);
            if (randNumber == 1)
            {
                hurt01.Play();
            }
            else if (randNumber == 2)
            {
                hurt02.Play();
            }
            else
            {
                hurt03.Play();
            }

            yield return new WaitForSeconds(1f);

            damageFlash.SetActive(false);
        }
    }
}