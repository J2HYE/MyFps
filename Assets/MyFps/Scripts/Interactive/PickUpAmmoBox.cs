using UnityEngine;

namespace MyFps
{
    //AmmoBox ������ ȹ��
    public class PickUpAmmoBox : Interactive
    {
        #region Variables
        //Ammobox ������ ȹ��� �����ϴ� ammo ����
        [SerializeField] private int giveAmmo = 7;
        #endregion

        protected override void DoAction()
        {
            //������ ����
            Debug.Log($"źȯ {giveAmmo}�� ����");
            PlayerStats.Instance.AddAmmo(giveAmmo);

            //ų
            Destroy(gameObject);
        }
    }
}
