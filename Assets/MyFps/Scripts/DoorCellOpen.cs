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

        //action
        private Animator animator;
        private Collider collider;
        public AudioSource audioSource;
        #endregion

        private void Start()
        {
            animator = GetComponent<Animator>();
            collider = GetComponent<BoxCollider>();
        }

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }

        //���콺�� �������� �׼� UI�� �����ش�
        private void OnMouseOver()
        {
            //�Ÿ��� 2 �����϶�
            if(theDistance <=2f)
            {
                HideActionUI();

                //���� ������
                animator.SetBool("IsOpen", true);
                collider.enabled = true;   
                audioSource.Play();
            }
            else
            {
                HideActionUI();
            }
        }

        //���콺�� ����� �׼� UI�� �����
        private void OnMouseExit()
        {
            actionUI.SetActive(false);
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
        }
    }
}