using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor;      //��
        public AudioSource doorBang;    //�� ���� ����

        public AudioSource jumpScare;   //�� ���� ����
        public GameObject theRobot;     //��

        //�����
        public AudioSource bgm01;
        public AudioSource bgm02;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            //������
            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled = false;

            //�� ����
            doorBang.Play();
            bgm01.Stop();

            //Enemy Ȱ��ȭ
            theRobot.SetActive(true);

            yield return new WaitForSeconds(1f);

            //Enemy ���� ����
            jumpScare.Play();
            bgm02.Play();

            //Enemy Ÿ���� ���� �ȱ�
            RobotController robot = theRobot.GetComponent<RobotController>();
            if(robot !=null)
            {
                robot.SetState(RobotState.R_Walk);
            }


            //Ʈ���� ų
            Destroy(this.gameObject);
        }
    }
}
