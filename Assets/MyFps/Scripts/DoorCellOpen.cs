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

        //마우스를 가져가면 액션 UI를 보여준다
        private void OnMouseOver()
        {
            //거리가 2 이하일때
            if(theDistance <=2f)
            {
                HideActionUI();

                //문이 열린다
                animator.SetBool("IsOpen", true);
                collider.enabled = true;   
                audioSource.Play();
            }
            else
            {
                HideActionUI();
            }
        }

        //마우스가 벗어나면 액션 UI를 감춘다
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