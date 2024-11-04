using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    //���ͷ�Ƽ�� �׼��� �����ϴ� Ŭ����
    public abstract class Interactive : MonoBehaviour
    {
        protected abstract void DoAction();

        #region Variables
        private float theDistance;

        //action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Action Text";
        public GameObject extraCross;

        //true�̸� Interactive ����� ����
        protected bool unInteractive = false;
        #endregion

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }

        //���콺�� �������� �׼� UI�� �����ش�
        private void OnMouseOver()
        {
            //�Ÿ��� 2 �����϶�
            if (theDistance <= 2f &&!unInteractive)
            {
                ShowActionUI();

                if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();

                    //���� ������ �׼�
                    DoAction();
                }
            }
            else
            {
                HideActionUI();
            }
        }

        //���콺�� ����� �׼� UI�� �����
        private void OnMouseExit()
        {
            HideActionUI();
        }

        void ShowActionUI()
        {
            actionUI.SetActive(true);
            actionText.text = action;
            extraCross.SetActive(true);
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
            extraCross.SetActive(false);
        }

    }
}
