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
                    buyPhysics.SetActive(false);
                    var picker = PoolSignalable.Instance.onListRemove?.Invoke(PoolType.HostagePicker);
                    picker.transform.position = transform.position;
                    foreach (var money in MoneyList)
                    {
                        HostagePickerSignalable.Instance.onMoneyListAdd?.Invoke(money);   
                    }
                }
            }
        }
    }
}