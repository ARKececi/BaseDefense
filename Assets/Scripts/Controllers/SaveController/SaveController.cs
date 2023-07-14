using System;
using System.Collections.Generic;
using Enums;
using Keys;
using UnityEngine;
using UnityEngine.Rendering;

namespace Controllers.SaveController
{
    public class SaveController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public Dictionary<WeaponType, int> Upgrade;

        #endregion

        #endregion

        private void Awake()
        {
            Upgrade = GetBuyWeaponWeaponUpgradeSave();
        }
        
        public Dictionary<WeaponType,int> GetBuyWeaponWeaponUpgradeSave()
        {
            if (!ES3.FileExists()) return null;
            return ES3.Load<Dictionary<WeaponType,int>>("Upgrade",new Dictionary<WeaponType, int>());
        }

        public void SaveMoneyScore(int moneyCount)
        {
            ES3.Save("MoneyScore", moneyCount);
        }

        public void SaveDiamondScore(int diamonCount)
        {
            ES3.Save("DiamondScore", diamonCount);
        }

        public void SaveBuyingWeapon(List<WeaponType> weapons)
        {
            if (weapons != null) ES3.Save<List<WeaponType>>("WeaponBuyList" ,weapons);
        }
        
        public void SaveWeapon(string weaponName)
        {
            if (weaponName != null) ES3.Save("WeaponName", weaponName);
        }

        public void SaveWeaponUpgrade(WeaponType weapon, int count)
        {
            if (Upgrade.ContainsKey(weapon))
            {
                count++;
                Upgrade[weapon] = count ;
            }
            else
            {
                Upgrade.Add(weapon,count);   
            }
            if (Upgrade != null) ES3.Save<Dictionary<WeaponType, int>>("Upgrade", Upgrade);
        }
    }
}