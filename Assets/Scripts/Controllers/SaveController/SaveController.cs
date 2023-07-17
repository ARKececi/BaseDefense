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
        public Dictionary<int, List<GameObject>> TurretArea;
        public Dictionary<int, List<GameObject>> OperatorMans;

        #endregion

        #region Private Variables

        private int _countTurret;
        private int _countOperator;

        #endregion

        #endregion

        private void Awake()
        {
            Upgrade = GetBuyWeaponWeaponUpgradeSave();
            TurretArea = GetBuyTurretAreaSave();
            OperatorMans = GetBuyOperatorSave();
            for (int i = 0; i < TurretArea.Count; i++) { _countTurret++; }
            for (int i = 0; i < OperatorMans.Count; i++) {_countOperator++; }
            if (TurretArea != null)
            {
                foreach (var VARIABLE in TurretArea.Keys)
                {
                    TurretArea[VARIABLE][0].SetActive(true);
                    TurretArea[VARIABLE][1].SetActive(false);
                }
            }

            if (OperatorMans != null)
            {
                foreach (var VARIABLE in OperatorMans.Keys)
                {
                    OperatorMans[VARIABLE][0].SetActive(true);
                    OperatorMans[VARIABLE][1].SetActive(false);
                }
            }
        }
        
        public Dictionary<WeaponType,int> GetBuyWeaponWeaponUpgradeSave()
        {
            if (!ES3.FileExists()) return null;
            return ES3.Load<Dictionary<WeaponType,int>>("Upgrade",new Dictionary<WeaponType, int>());
        }
        
        public Dictionary<int,List<GameObject>> GetBuyTurretAreaSave()
        {
            if (!ES3.FileExists()) return null;
            return ES3.Load<Dictionary<int,List<GameObject>>>("TurretArea",new Dictionary<int, List<GameObject>>());
        }
        
        public Dictionary<int,List<GameObject>> GetBuyOperatorSave()
        {
            if (!ES3.FileExists()) return null;
            return ES3.Load<Dictionary<int,List<GameObject>>>("OperatorMan",new Dictionary<int, List<GameObject>>());
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

        public void SavePickerMan()
        {
            ES3.Save("PickerMan", true);
        }

        public void SaveTransporterMan()
        {
            ES3.Save("TransporterMan", true);
        }

        public void SaveTaretArea(GameObject turret, GameObject buy)
        {
            List<GameObject> turretArea = new List<GameObject>();
            turretArea.Add(turret);
            turretArea.Add(buy);
            TurretArea.Add(_countTurret,turretArea);
            _countTurret++;
            if (turret != null || buy != null) ES3.Save<Dictionary<int,List<GameObject>>>("TurretArea",TurretArea);
        }

        public void SaveOperatorMan(GameObject operatorMan, GameObject buy)
        {
            List<GameObject> opratorMans = new List<GameObject>();
            opratorMans.Add(operatorMan);
            opratorMans.Add(buy);
            OperatorMans.Add(_countOperator,opratorMans);
            _countOperator++;
            if (operatorMan != null || buy != null) ES3.Save<Dictionary<int,List<GameObject>>>("OperatorMan",OperatorMans);
        }
    }
}