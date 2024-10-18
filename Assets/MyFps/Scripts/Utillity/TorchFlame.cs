using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class TorchFlame : MonoBehaviour
    {
        #region Variables
        public Transform torchLight;    //토치라이트 객체
        private Animation flameAnim;

        //1초 타이머
        //[SerializeField] private float flameTimer = 1f;
        //private float countdown = 0f;

        private int lightMode;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            //초기화
            flameAnim = torchLight.GetComponent<Animation>();
            lightMode = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if(lightMode == 0)
            {
                StartCoroutine(FlameAnimation());
            }
            
            /*//1초마다 1번씩 랜덤한 라이트 애니메이션 플레이
            if(countdown < 0f)
            {
                //랜덤 애니메이션 플레이
                LightAnimation();

                //초기화
                countdown = flameTimer;
            }
            countdown -= Time.deltaTime;*/
        }

        IEnumerator FlameAnimation()
        {
            lightMode = Random.Range(1, 4);

            switch (lightMode)
            {
                case 1:
                    flameAnim.Play("TorchLightAnim1");
                    break;
                case 2:
                    flameAnim.Play("TorchLightAnim2");
                    break;
                case 3:
                    flameAnim.Play("TorchLightAnim3");
                    break;
            }

            yield return new WaitForSeconds(1.0f);
            lightMode = 0;
        }

        void LightAnimation()
        {
                      
        }
    }
}