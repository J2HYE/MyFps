using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    //�κ� ����
    public enum RobotState
    {
        R_Idle,
        R_Walk,
        R_Attack,
        R_Death
    }


    //�κ� Enemy ���� Ŭ����
    public class RobotController : MonoBehaviour, IDamageable
    {
        #region Variables
        public GameObject thePlayer;
        private Animator animator;

        //�κ� ���� ����
        private RobotState currentState;
        //�κ� ���� ����
        private RobotState beforeState;        

        //ü��
        [SerializeField] private float maxHealth = 20;
        private float currentHealth;

        private bool isDeath = false;

        //�̵�
        [SerializeField] private float moveSpeed = 5f;

        //����
        [SerializeField] private float attackRange = 1.5f;  //���� ���� �Ÿ�
        [SerializeField] private float attackDamage = 5f;   //���� ������
        [SerializeField] private float attackTimer = 2f;    //���� �ӵ�
        private float countdown = 0f;

        //�����
        public AudioSource bgm01;
        public AudioSource bgm02;
        #endregion

        private void Start()
        {        
            //����
            animator = GetComponent<Animator>();

            //�ʱ�ȭ
            currentHealth = maxHealth;
            isDeath = false;
            countdown = attackTimer;

            SetState(RobotState.R_Idle);
        }

        private void Update()
        {
            if (isDeath) return;

            //Ÿ�� ����
            Vector3 dir = thePlayer.transform.position - this.transform.position;
            float distance = Vector3.Distance(thePlayer.transform.position, transform.position);
            if (distance <= attackRange)
            {
                SetState(RobotState.R_Attack);
            }

            //�κ� ���� ����
            switch (currentState)
            {
                case RobotState.R_Idle:
                    break;
                case RobotState.R_Walk:
                    transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
                    transform.LookAt(thePlayer.transform);                                       
                    break;
                case RobotState.R_Attack:
                    if(distance > attackRange)
                    {
                        SetState(RobotState.R_Walk);                        
                    }
                    break;
                /*case RobotState.R_Death:
                    break;*/
            }
        }

        //2�ʸ��� ����
        /*private void AttackOnTimer()
        {
            if(countdown <0f)
            {
                //����
                Attack();

                //Ÿ�̸� �ʱ�ȭ
                countdown = attackTimer;
            }
            countdown -= Time.deltaTime;    
        }*/
        //�̷��� �ϸ� ���� ����̶� �ȸ��� �� ����
        //Animation���� �� �žƼ� �����ϱ�

        private void Attack()
        {
            PlayerController player = thePlayer.GetComponent<PlayerController>();
            if (player != null)
            {
                Debug.Log("Robot attack");
                player.TakeDamage(attackDamage);
            }
        }

        //�κ��� ���� ����
        public void SetState(RobotState newState)
        {
            //���� ���� üũ
            if(currentState == newState) 
                return;

            //���� ���� ����
            beforeState = currentState;

            //���� ����
            currentState = newState;

            //���� ���濡 ���� ���� ����
            animator.SetInteger("RobotState", (int)newState);   
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"Robot Health:{currentHealth}");

            if(currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        void Die()
        {
            isDeath = true;

            SetState(RobotState.R_Death);

            //����� ����
            bgm02.Stop();
            bgm01.Play();

            //�浹ü ����
            transform.GetComponent<BoxCollider>().enabled = false;
        }

        
    }
}
