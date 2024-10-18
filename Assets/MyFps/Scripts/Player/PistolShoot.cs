using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PistolShoot : MonoBehaviour
    {
        #region Variables
        private Animator animator;
        //
        public ParticleSystem muzzle;
        public AudioSource pistolShot;
                
        //public Transform camera;
        public Transform firePoint;

        //공격 데미지
        [SerializeField] private float attackDamage = 5f;

        //연사 딜레이
        [SerializeField] private float fireDelay = 0.5f;
        private bool isFire = false;

        //임팩트
        public GameObject hitImpactPrefab;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            //참조
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            //슛
            if(Input.GetButtonDown("Fire") && !isFire)
            {
                if (PlayerStats.Instance.UseAmmo(1) == true)
                {
                    StartCoroutine(Shoot());
                }
            }
        }

        IEnumerator Shoot()
        {
            isFire = true;

            //내 앞 100에 적이 있을 때 데미지를 준다
            float maxDistance = 100f;
            RaycastHit hit;
            if(Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                //hit 이펙트 
                GameObject eff = Instantiate(hitImpactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(eff, 2f);

                //적에게 데미지를 준다
                IDamageable damageable = hit.transform.GetComponent<IDamageable>();                
                if(damageable != null)
                {
                    damageable.TakeDamage(attackDamage);
                }                
            }

            //슛 효과
            animator.SetTrigger("Fire");

            pistolShot.Play();

            muzzle.gameObject.SetActive(true);
            muzzle.Play();

            yield return new WaitForSeconds(fireDelay);
            muzzle.Stop();
            muzzle.gameObject.SetActive(false);  

            isFire = false;
        }

        //Gizmo그리기: 카메라 위치에서 앞에 충돌체까지 레이저 쏘는 선 그리기
        private void OnDrawGizmosSelected()
        {
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance);

            Gizmos.color = Color.red;
            if (isHit)
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * maxDistance);
            }
        }

        
    }
}