using System;
using System.Collections.Generic;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using Weapons.Pistol.P250.Signal;
using Weapons.Rifle.AK_47.Signal;

namespace Controllers.WeaponShopUIController
{
    public class WeaponShopUIController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public SerializedDictionary<WeaponType, ButtonLists > UseAndUpgrade;
        public SerializedDictionary<string, WeaponData> WeaponData = new SerializedDictionary<string, WeaponData>();
        public List<WeaponType> Buying;

        public int AK_47BuyMoney;
        public int P250BuyMoney;
        
        public int AK_47UpgradeMoney;
        public int P250UpgradeMoney;

        #endregion

        #region Private Variables

        private int _ak47UpgradeCount;
        private int _p250UpgradeCount;

        #endregion

        #region Serialized Variables

        [SerializeField] private SerializedDictionary<WeaponType, WeaponsUITextData> TextDatas;

        #endregion

        #endregion

        private void Awake()
        {
            WeaponData = GetWeaponData();
            GetSaveWeaponList();
            Buying.Add(WeaponType.Pistol);
        }

        private void Start()
        {
            UseAndUpgrade[WeaponType.Pistol].Buttons[1].SetActive(false);
            foreach (var VARIABLE in Buying)
            {
                WeaponBuyingSaveController(VARIABLE);
            }

            foreach (var VARIABLE in WeaponData.Keys)
            {
                if (VARIABLE == GetWeaponSave())
                {
                    WeaponSaveController(WeaponData[VARIABLE].WeaponType);
                }
            }
            _ak47UpgradeCount++;
            _p250UpgradeCount++;

            TextDatas[WeaponType.Pistol].Update.text = P250UpgradeMoney.ToString();
            TextDatas[WeaponType.Rifle].Buy.text = AK_47BuyMoney.ToString();
            TextDatas[WeaponType.Rifle].Update.text = AK_47UpgradeMoney.ToString();
        }
        
        private SerializedDictionary<string, WeaponData> GetWeaponData()
        {
            return Resources.Load<CD_Weapon>("Data/CD_Weapon").WeaponDatas;
        }
        
        public string GetWeaponSave()
        {
            if (!ES3.FileExists()) return null;
            return ES3.KeyExists("WeaponName") ? ES3.Load<string>("WeaponName") : null;
        }
        
        public List<WeaponType> GetBuyWeaponWeaponListSave()
        {
            if (!ES3.FileExists()) return null;
            return ES3.Load<List<WeaponType>>("WeaponBuyList",new List<WeaponType>());
            //return ES3.KeyExists("WeaponBuyList") ? ES3.Load<List<WeaponType>>("WeaponBuyList") : new List<WeaponType>();
        }

        private void BuyingSave(WeaponType weapon)
        {
            Buying.Add(weapon);
            SaveSignals.Instance.onSaveBuyingWeapon?.Invoke(Buying);
        }

        private void GetSaveWeaponList()
        {
            Buying = GetBuyWeaponWeaponListSave();
        }

        private void WeaponBuyingSaveController(WeaponType weaponType)
        {
            UseAndUpgrade[weaponType].Buttons[2].SetActive(true);
            UseAndUpgrade[weaponType].Buttons[0].SetActive(false);
        }

        private void WeaponSaveController(WeaponType weapon)
        {
            foreach (var VARIABLE in UseAndUpgrade.Keys)
            {
                if (VARIABLE != weapon && Buying.Contains(VARIABLE))
                {
                    foreach (var weaponUI in UseAndUpgrade[VARIABLE].Buttons)
                    {
                        if (UseAndUpgrade[VARIABLE].Buttons[0] != weaponUI)
                        {
                            weaponUI.SetActive(true);
                        }
                    }
                }
            }
        }

        public void AK47Buy()
        {
            if ((bool)ScoreSignalable.Instance.onEvaluationMoney?.Invoke(AK_47BuyMoney))
            {
                WeaponSignals.Instance.onSetWeaponFunction?.Invoke("AK_47");
                UseAndUpgrade[WeaponType.Rifle].Buttons[2].SetActive(true);
                UseAndUpgrade[WeaponType.Rifle].Buttons[0].SetActive(false);
                BuyingSave(WeaponType.Rifle);
                foreach (var VARIABLE in UseAndUpgrade.Keys)
                {
                    if (VARIABLE != WeaponType.Rifle && Buying.Contains(VARIABLE))
                    {
                         foreach (var weaponUI in UseAndUpgrade[VARIABLE].Buttons)
                         {
                             if (UseAndUpgrade[VARIABLE].Buttons[0] != weaponUI)
                             {
                                 weaponUI.SetActive(true);
                             }
                         }
                    }
                }
            }
        }
        
        public void AK47Upgrade()
        {
            if (_ak47UpgradeCount < 5)
            {
                if ((bool)ScoreSignalable.Instance.onEvaluationMoney?.Invoke((AK_47UpgradeMoney * _ak47UpgradeCount)))
                {
                    AK_47Signalable.Instance.onUpgrade?.Invoke();
                    _ak47UpgradeCount++;
                    TextDatas[WeaponType.Rifle].Update.text = (AK_47UpgradeMoney *_ak47UpgradeCount).ToString();
                    if (_p250UpgradeCount >= 5)
                    {
                        TextDatas[WeaponType.Pistol].Update.text = ("MAX");
                    }
                }
            }
        }
        
        public void AK47Use()
        {
            WeaponSignals.Instance.onSetWeaponFunction?.Invoke("AK_47");
            UseAndUpgrade[WeaponType.Rifle].Buttons[2].SetActive(true);
            UseAndUpgrade[WeaponType.Rifle].Buttons[1].SetActive(false);
            foreach (var VARIABLE in UseAndUpgrade.Keys)
            {
                if (VARIABLE != WeaponType.Rifle && Buying.Contains(VARIABLE))
                {
                    foreach (var weaponUI in UseAndUpgrade[VARIABLE].Buttons)
                    {
                        if (UseAndUpgrade[VARIABLE].Buttons[0] != weaponUI)
                        {
                            weaponUI.SetActive(true);
                        }
                    }
                }
            }
        }

        public void PistolUpgrade()
        {
            if (_p250UpgradeCount < 5)
            {
                if ((bool)ScoreSignalable.Instance.onEvaluationMoney?.Invoke((P250UpgradeMoney * _ak47UpgradeCount)))
                {
                    P250Signalable.Instance.onUpgrade?.Invoke();
                    _p250UpgradeCount++;
                    TextDatas[WeaponType.Pistol].Update.text = (P250UpgradeMoney * _p250UpgradeCount).ToString();
                    if (_p250UpgradeCount >= 5)
                    {
                        TextDatas[WeaponType.Pistol].Update.text = ("MAX");
                    }
                }
            }
        }
        
        public void PistolUse()
        {
            WeaponSignals.Instance.onSetWeaponFunction?.Invoke("P250");
            UseAndUpgrade[WeaponType.Pistol].Buttons[2].SetActive(true);
            UseAndUpgrade[WeaponType.Pistol].Buttons[1].SetActive(false);
            foreach (var VARIABLE in UseAndUpgrade.Keys)
            {
                if (VARIABLE != WeaponType.Pistol && Buying.Contains(VARIABLE))
                {
                    foreach (var weaponUI in UseAndUpgrade[VARIABLE].Buttons)
                    {
                        if (UseAndUpgrade[VARIABLE].Buttons[0] != weaponUI)
                        {
                            weaponUI.SetActive(true);
                        }
                    }
                }
            }
        }
    }

    [Serializable]
    public class ButtonLists
    {
        [SerializeField] public List<GameObject> Buttons = new List<GameObject>();
    }
}