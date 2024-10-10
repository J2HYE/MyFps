using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class MoveObject : MonoBehaviour
    {
        #region Variables
        private Rigidbody rb;

        //�¿�� ���� �־� �̵�
        [SerializeField] private float movePower = 5f;
        private float moveX;

        //�� ����
        private Material material;
        private Color originColor;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            //����
            rb = GetComponent<Rigidbody>();
            material = GetComponent<Material>();

            //�ʱ�ȭ
            originColor = material.color;
            MoveRightByForce();
        }

        // Update is called once per frame
        void Update()
        {
            //�Է� ó��
            //moveX = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            //rb.AddForce(Vector3.right * moveX * movePower, ForceMode.Force);
        }

        public void MoveRightByForce()
        {
            rb.AddForce(Vector3.right * movePower, ForceMode.Impulse);
        }


        public void MoveLeftByForce()
        {
            rb.AddForce(Vector3.left * movePower, ForceMode.Impulse);
        }


        public void ChangeRedColor()
        {
            material.color = Color.red;
        }

        public void ResetColor()
        {
            material.color = originColor;
        }
    }
}