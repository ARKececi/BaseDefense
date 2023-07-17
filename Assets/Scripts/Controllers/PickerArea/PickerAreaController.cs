using System;
using System.Collections.Generic;
using Controllers.TurretController;
using Enums;
using Signalable;
using Signals;
using UnityEngine;

namespace Controllers.PickerArea
{
    public class PickerAreaController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> MoneyList;
        public int Price;

        #endregion

        #region Serialized Variables
        
        [SerializeField] private UIBuyPickerController uıBuyPickerController;
        [SerializeField] private GameObject buyPhysics;

        #endregion

        #region Private Variables

        #endregion

        #endregion

        private void Start()
        {
            uıBuyPickerController.OnPrice(Price);
            SaveOpen();
        }
        
        public bool GetPickerManSave()
        {
            if (!ES3.FileExists()) return false;
            return ES3.KeyExists("PickerMan") ? ES3.Load<bool>("PickerMan") : false;
        }
        
        private void SaveOpen()
        {
            if (GetPickerManSave())
            {
                buyPhysics.SetActive(false);
                PickerManSpawn();
            }
        }

        public void MoneyListAdd(GameObject money)
        {
            if (buyPhysics.activeSelf)
            {
                MoneyList.Add(money);
                MoneyList.TrimExcess();
            }
        }
        
        public void MoneyListRemove(GameObject money)
        {
            if (buyPhysics.activeSelf)
            {
                MoneyList.Remove(money);
                MoneyList.TrimExcess();
            }
        }

        public void PlayerTrigger()
        {
            if ((bool)ScoreSignalable.Instance.onDecreaseMoneyCount?.Invoke())
            {
                uıBuyPickerController.OnPrice(Price--);
                if (Price <= 0)
                {
                    SaveSignals.Instance.onSavePickerMan?.Invoke();
                    buyPhysics.SetActive(false);
                    PickerManSpawn();
                    foreach (var money in MoneyList)
                    {
                        HostagePickerSignalable.Instance.onMoneyListAdd?.Invoke(money);   
                    }
                }
            }
        }

        private void PickerManSpawn()
        {
            var picker = PoolSignalable.Instance.onListRemove?.Invoke(PoolType.HostagePicker);
            picker.transform.position = transform.position;
        }
    }
}