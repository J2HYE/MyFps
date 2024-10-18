using UnityEngine;

namespace MyFps
{
    //AmmoBox 아이템 획득
    public class PickUpAmmoBox : Interactive
    {
        #region Variables
        //Ammobox 아이템 획득시 지급하는 ammo 갯수
        [SerializeField] private int giveAmmo = 7;
        #endregion

        protected override void DoAction()
        {
            //아이템 지급
            Debug.Log($"탄환 {giveAmmo}개 지급");
            PlayerStats.Instance.AddAmmo(giveAmmo);

            //킬
            Destroy(gameObject);
        }
    }
}
