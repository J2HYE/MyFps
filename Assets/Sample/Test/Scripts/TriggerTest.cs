using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class TriggerTest : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"OnTriggerEnter: {other.name}");
            //���������� ���� �ش�, �÷��� ���������� �ٲ۴�.
            MoveObject moveObject = other.GetComponent<MoveObject>();
            if(moveObject != null)
            {
                moveObject.MoveRightByForce();
                moveObject.ChangeRedColor();
            }
        }
        private void OnTriggerStay(Collider other)
        {
            Debug.Log($"OnTriggerStay: {other.name}");
        }
        private void OnTriggerExit(Collider other)
        {
            Debug.Log($"OnTriggerExit: {other.name}");
            //���������� ���� �ش�, �÷��� �������� ������ �ٲ۴�
            MoveObject moveObject = other.GetComponent<MoveObject>();
            if (moveObject != null)
            {
                moveObject.MoveRightByForce();
                moveObject.ResetColor();
            }
        }
    }
}
