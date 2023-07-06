using System;
using System.Collections.Generic;
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

        private void Start()
        {
            _ak47UpgradeCount++;
            _p250UpgradeCount++;

            TextDatas[WeaponType.Pistol].Update.text = P250UpgradeMoney.ToString();
            TextDatas[WeaponType.Rifle].Buy.text = AK_47BuyMoney.ToString();
            TextDatas[WeaponType.Rifle].Update.text = AK_47UpgradeMoney.ToString();
        }

        public void AK47Buy()
        {
            if ((bool)ScoreSignalable.Instance.onEvaluationMoney?.Invoke(AK_47BuyMoney))
            {
                WeaponSignals.Instance.onSetWeaponFunction?.Invoke("AK_47");
                UseAndUpgrade[WeaponType.Rifle].Buttons[2].SetActive(true);
                UseAndUpgrade[WeaponType.Rifle].Buttons[0].SetActive(false);
                Buying.Add(WeaponType.Rifle);
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
            if ((bool)ScoreSignalable.Instance.onEvaluationMoney?.Invoke((AK_47UpgradeMoney * _ak47UpgradeCount)) && _ak47UpgradeCount < 5)
            {
                AK_47Signalable.Instance.onUpgrade?.Invoke();
                _ak47UpgradeCount++;
                TextDatas[WeaponType.Rifle].Update.text = (AK_47UpgradeMoney *_ak47UpgradeCount).ToString();
            }
        }
        
        public void AK47Use()
        {
            WeaponSignals.Instance.onSetWeaponFunction?.Invoke("AK_47");
            UseAndUpgrade[WeaponType.Rifle].Buttons[2].SetActive(true);
            UseAndUpgrade[WeaponType.Rifle].Buttons[1].SetActive(false);
            Buying.Add(WeaponType.Rifle);
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
            if ((bool)ScoreSignalable.Instance.onEvaluationMoney?.Invoke((P250UpgradeMoney * _ak47UpgradeCount)) && _p250UpgradeCount < 5)
            {
                P250Signalable.Instance.onUpgrade?.Invoke();
                _p250UpgradeCount++;
                TextDatas[WeaponType.Pistol].Update.text = (P250UpgradeMoney * _p250UpgradeCount).ToString();
                
            }
        }
        
        public void PistolUse()
        {
            WeaponSignals.Instance.onSetWeaponFunction?.Invoke("P250");
            UseAndUpgrade[WeaponType.Pistol].Buttons[2].SetActive(true);
            UseAndUpgrade[WeaponType.Pistol].Buttons[1].SetActive(false);
            Buying.Add(WeaponType.Pistol);
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