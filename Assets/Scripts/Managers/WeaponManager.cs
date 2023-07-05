using System;
using System.Collections.Generic;
using Controllers.WeaponController;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using UnityEngine;
using UnityEngine.Rendering;

namespace Managers
{
    public class WeaponManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private WeaponController weaponController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PlayerSignals.Instance.onWeaponActive += weaponController.WeaponSetActive;
            WeaponSignals.Instance.onBulletExit += weaponController.BulletPoolExit;
            WeaponSignals.Instance.onBulletEntry += weaponController.BulletPoolEntry;
            WeaponSignals.Instance.onBarrel += weaponController.Barrel;
            WeaponSignals.Instance.onSetWeaponFunction += OnSetWeaponFunction;
        }

        private void UnsubscribeEvents()
        {
            PlayerSignals.Instance.onWeaponActive -= weaponController.WeaponSetActive;
            WeaponSignals.Instance.onBulletExit -= weaponController.BulletPoolExit;
            WeaponSignals.Instance.onBulletEntry -= weaponController.BulletPoolEntry;
            WeaponSignals.Instance.onBarrel -= weaponController.Barrel;
            WeaponSignals.Instance.onSetWeaponFunction -= OnSetWeaponFunction;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void OnSetWeaponFunction(string weapon)
        {
            weaponController.SetWeaponFunction(weapon);
        }
    }
}