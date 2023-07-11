using Keys;
using UnityEngine;

namespace Controllers.SaveController
{
    public class SaveController : MonoBehaviour
    {
        
        public void SaveMoneyScore(int moneyCount)
        {
            ES3.Save("MoneyScore", moneyCount);
        }

        public void SaveDiamondScore(int diamonCount)
        {
            ES3.Save("DiamondScore", diamonCount);
        }
        
        public void SaveWeapon(string weaponName)
        {
            if (weaponName != null) ES3.Save("WeaponName", weaponName);
        }
    }
}