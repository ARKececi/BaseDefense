using System;
using System.Collections.Generic;
using Controllers.TurretController;
using Enums;
using Signalable;
using Signals;
using UnityEngine;

namespace Controllers.TransporterManAreaController
{
    public class TransporterManAreaController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public float Timer;
        public int Price;
        public List<GameObject> TurretList;

        #endregion

        #region Serialized Variables

        [SerializeField] private UIBuyTransportManController uıBuyTransportManController;
        [SerializeField] private GameObject buyPhysics;

        #endregion

        #region Private Variables

        private float _timer;

        #endregion

        #endregion

        private void Awake()
        {
            uıBuyTransportManController.OnPrice(Price);
        }

        public void BuyTimer()
        {
            if (_timer < 0)
            {
                _timer = Timer;
                PlayerTrigger();
            }
            _timer -= UnityEngine.Time.deltaTime;
            
        }

        public void AddTurretList(GameObject turret)
        {
            if (Price > 0)
            {
                TurretList.Add(turret);
            }
        }
        
        private void PlayerTrigger()
        {
            if ((bool)ScoreSignalable.Instance.onDecreaseMoneyCount?.Invoke())
            {
                uıBuyTransportManController.OnPrice(Price--);
                if (Price <= 0)
                {
                    buyPhysics.SetActive(false);
                    TransporterManSpawn();
                    foreach (var turret in TurretList)
                    {
                        TransporterManSignalable.Instance.onTurretList?.Invoke(turret);
                    }
                }
            }
        }

        public void TransporterManSpawn()
        {
            GameObject TransporterMan = PoolSignalable.Instance.onListRemove?.Invoke(PoolType.HostageCarrier);
            TransporterMan.transform.position = transform.position;
        }
    }
}