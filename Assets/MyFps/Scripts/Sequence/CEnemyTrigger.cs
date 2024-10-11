using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled = false;

            yield return null;
        }
    }
}
