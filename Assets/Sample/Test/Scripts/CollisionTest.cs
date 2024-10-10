using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MySample
{
    public class CollisionTest : MonoBehaviour
    {       
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"OnCollisionEnter: {collision.gameObject.name}");
            //øﬁ¬ ¿∏∑Œ »˚¿ª ¡ÿ¥Ÿ
            MoveObject moveObject = collision.gameObject.GetComponent<MoveObject>();
            if (moveObject != null)
            {
                moveObject.MoveLeftByForce();
            }
        }
        private void OnCollisionStay(Collision collision)
        {
            Debug.Log($"OnCollisionEnter: {collision.gameObject.name}");
        }
        private void OnCollisionExit(Collision collision)
        {
            Debug.Log($"OnCollisionEnter: {collision.gameObject.name}");
            //øﬁ¬ ¿∏∑Œ »˚¿ª ¡ÿ¥Ÿ
            MoveObject moveObject = collision.gameObject.GetComponent<MoveObject>();
            if (moveObject != null)
            {
                moveObject.MoveLeftByForce();
            }
        }
    }
}