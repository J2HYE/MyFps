using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyFps
{
    public class PickUpItem : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float verticalBobFrequency = 1f;   //이동속도
        //[SerializeField] private float bobingAmount = 1f;           //이동거리
        [SerializeField] private float rotateSpeed = 360f;          //회전 속도


        private Vector3 startPosition;
        #endregion

        private void Start()
        {
            //처음 위치
            startPosition = transform.position;
        }

        private void Update()
        {
            //위 아래 흔들림
            float bobingAnimationPhase = Mathf.Sin(Time.time * verticalBobFrequency);
            transform.position = startPosition + Vector3.up * bobingAnimationPhase;

            //회전
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
        }

        private void OnTriggerEnter(Collider other)
        {           
            //플레이어 체크
            if(other.tag == "Player")
            {
                //아이템 획득
                OnPickUp();


                //킬
                Destroy(gameObject);
            }                 
        }

        //아이템 획득 성공, 실패 반환
        protected virtual bool OnPickUp()
        {
            return true;
        }
    }
}