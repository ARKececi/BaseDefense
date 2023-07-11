using Enums;
using UnityEngine.Rendering;

namespace Keys
{
    public struct SaveDataParams
    {
        #region Score Save
        
        public int MoneyScore;
        public int DiamondScore;

        #endregion

        #region Weapon Save

        public string WeaponName;

        #endregion

        #region Weapon Upgrade

        public SerializedDictionary<WeaponType, int> WeaponUpgrade;

        #endregion
    }
}