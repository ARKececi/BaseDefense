using System.Collections.Generic;
using Controllers.SaveController;
using Enums;
using Keys;
using Signals;
using UnityEngine;

namespace Managers
{
    public class SaveManager : MonoBehaviour
    {
        #region Serl Variables

        #region Public Variables

        public List<WeaponType> Weapons;

        #endregion

        #region Serialized Variables

        [SerializeField] private SaveController saveController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            SaveSignals.Instance.onSaveMoneyScore += OnSaveMoneyScore;
            SaveSignals.Instance.onSaveDiamondScore += OnSaveDiamondScore;
            SaveSignals.Instance.onSaveWeaponName += OnSaveWeapon;
            SaveSignals.Instance.onSaveBuyingWeapon += OnSaveBuyingWeapon;
        }

        private void UnsubscribeEvents()
        {
            SaveSignals.Instance.onSaveMoneyScore -= OnSaveMoneyScore;
            SaveSignals.Instance.onSaveDiamondScore -= OnSaveDiamondScore;
            SaveSignals.Instance.onSaveWeaponName -= OnSaveWeapon;
            SaveSignals.Instance.onSaveBuyingWeapon -= OnSaveBuyingWeapon;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion
        
        private void OnSaveMoneyScore(int moneyCount)
        {
            saveController.SaveMoneyScore(moneyCount);
        }

        private void OnSaveDiamondScore(int diamondCount)
        {
            saveController.SaveDiamondScore(diamondCount);
        }

        private void OnSaveWeapon(string weaponName)
        {
            saveController.SaveWeapon(weaponName);
        }

        private void OnSaveBuyingWeapon(List<WeaponType> weapon)
        {
            saveController.SaveBuyingWeapon(weapon);
        }
    }
}