using System;
using System.Collections.Generic;
using Enums;
using Signals;
using UnityEngine;
using UnityEngine.Rendering;

namespace Controllers.WeaponShopUIController
{
    public class WeaponShopUIController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public SerializedDictionary<WeaponType, ButtonLists > UseAndUpgrade;
        public List<WeaponType> Buying;

        #endregion

        #endregion
        
        public void AK47Buy()
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
        
        public void AK47Upgrade()
        {
            
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