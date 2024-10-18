using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class DoorCellExit : Interactive
    {
        #region Variables
        public SceneFader Fader;
        [SerializeField] private string loadToScene = "MainScene02";

        private Animator animator;
        private Collider m_Collider;
        public AudioSource creakyDoor;

        public AudioSource bgm01;
        #endregion

        private void Start()
        {
            //ÂüÁ¶
            animator = GetComponent<Animator>();
            m_Collider = GetComponent<Collider>();
            
        }

        protected override void DoAction()
        {
            animator.SetBool("IsOpen",true);
            m_Collider.enabled = false;

            creakyDoor.Play();

            ChangeScene();
        }

        void ChangeScene()
        {
            bgm01.Stop();

            Fader.FadeTo(loadToScene);
        }
    }
}
