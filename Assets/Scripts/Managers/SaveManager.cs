using System.Collections.Generic;
using Controllers.SaveController;
using Enums;
using Keys;
using Signals;
using UnityEngine;
using UnityEngine.Rendering;

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
            SaveSignals.Instance.onSaveWeaponUpgrade += OnSaveWeaponUpgrade;
            SaveSignals.Instance.onSavePickerMan += OnSavePickerMan;
            SaveSignals.Instance.onSaveTransporterMan += OnSaveTransporterMan;
            SaveSignals.Instance.onSaveTurretArea += OnSaveTaretArea;
            SaveSignals.Instance.onSaveOperatorMan += OnSaveOperatorMan;
            SaveSignals.Instance.onSaveGate += OnSaveGate;
        }

        private void UnsubscribeEvents()
        {
            SaveSignals.Instance.onSaveMoneyScore -= OnSaveMoneyScore;
            SaveSignals.Instance.onSaveDiamondScore -= OnSaveDiamondScore;
            SaveSignals.Instance.onSaveWeaponName -= OnSaveWeapon;
            SaveSignals.Instance.onSaveBuyingWeapon -= OnSaveBuyingWeapon;
            SaveSignals.Instance.onSaveWeaponUpgrade -= OnSaveWeaponUpgrade;
            SaveSignals.Instance.onSavePickerMan -= OnSavePickerMan;
            SaveSignals.Instance.onSaveTransporterMan -= OnSaveTransporterMan;
            SaveSignals.Instance.onSaveTurretArea -= OnSaveTaretArea;
            SaveSignals.Instance.onSaveOperatorMan -= OnSaveOperatorMan;
            SaveSignals.Instance.onSaveGate -= OnSaveGate;
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

        private void OnSaveWeaponUpgrade(WeaponType weapon, int count)
        {
            saveController.SaveWeaponUpgrade(weapon,count);
        }

        private void OnSavePickerMan()
        {
            saveController.SavePickerMan();
        }

        private void OnSaveTransporterMan()
        {
            saveController.SaveTransporterMan();
        }

        private void OnSaveTaretArea(GameObject turret, GameObject buy)
        {
            saveController.SaveTaretArea(turret,buy);
        }

        private void OnSaveOperatorMan(GameObject operatorMan, GameObject buy)
        {
            saveController.SaveOperatorMan(operatorMan,buy);
        }

        private void OnSaveGate(GameObject gate)
        {
            saveController.SaveGate(gate);
        }
        
    }
}