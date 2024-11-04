using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class FlyingObject : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float velocity = 1f;   //
        #endregion

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.relativeVelocity.magnitude > velocity)
            {
                AudioManager.Instance.Play("CupFall");
            }
        }
    }
}
