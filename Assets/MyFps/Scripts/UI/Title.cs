using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class Title : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";

        private bool isAnyKey = false;
        public GameObject anykeyUI;
        #endregion

        private void Start()
        {
            //���̵� �� ȿ��
            fader.FromFade();
            //�ʱ�ȭ
            isAnyKey = false;

            StartCoroutine(TitleProcess());
        }

        private void Update()
        {
            if (Input.anyKey && isAnyKey)
            {
                GotoMenu();
            }            
        }

        //3�� �ڿ� anykey Show, 10�� �ڿ� �ڵ� �ѱ� 
        IEnumerator TitleProcess()
        {
            yield return new WaitForSeconds(3f);
            isAnyKey=true;
            anykeyUI.SetActive(true);

            yield return new WaitForSeconds(10f);
            GotoMenu();
        }

        private void GotoMenu()
        {
            StopAllCoroutines();

            fader.FadeTo(loadToScene);
        }
    }
}