using UnityEngine;
using TMPro;

namespace MyFps
{
    public class DoorCellOpen : MonoBehaviour
    {
        #region Variables
        private float theDistance;

        //action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Open The Door";
        public GameObject extraCross;

        //action
        private Animator animator;
        private Collider m_collider;
        public AudioSource audioSource;
        #endregion

        private void Start()
        {
            animator = GetComponent<Animator>();
            m_collider = GetComponent<BoxCollider>();
        }

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }

        //���콺�� �������� �׼� UI�� �����ش�
        private void OnMouseOver()
        {
            //�Ÿ��� 2 �����϶�
            if (theDistance <= 2f)
            {
                ShowActionUI();

                if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();

                    //���� ������ �׼�
                    animator.SetBool("IsOpen", true);
                    GetComponent<Collider>().enabled = false;
                    audioSource.Play();
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