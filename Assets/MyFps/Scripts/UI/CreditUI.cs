using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class CreditUI : MonoBehaviour
    {
        #region Varialbes
        public GameObject mainMenu;

        #endregion

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                HideCredits();
            }
        }

        private void HideCredits()
        {
            mainMenu.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
