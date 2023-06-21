using System.Collections.Generic;
using DG.Tweening;
using Enums;
using Signalable;
using Signals;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class PlayerStackController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> CollectedMoneyList;
        public List<GameObject> CollectedAmmoList;

        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject moneyBag;
        [SerializeField] private GameObject poolMoney;

        #endregion

        #region Private Variables

        private float _countY;
        private float _countZ;
        private int _moneyCount;

        #endregion

        #endregion

        public void AddMoney(GameObject other)
        {
            if (CollectedMoneyList.Count < 14)
            {
                CollectedMoneyList.Add(other);
                other.transform.tag = "Collected";
                other.transform.SetParent(moneyBag.transform);
                HostagePickerSignalable.Instance.onMoneyListRemove?.Invoke(other);
                other.transform.DOLocalMove(new Vector3(0,_countY += .3f,_countZ), 1);
                other.transform.DOLocalRotate(Vector3.zero, 1);
                if (_countY > 1.8f) { _countY = 0; _countZ -= +0.3f; }
            }
        }

        public void RemoveMoney()
        {
            _countY = 0;
            _countZ = 0;
            PlayerSignals.Instance.onMoneyScoreCalculation?.Invoke(CollectedMoneyList.Count);
            foreach (var VARIABLE in CollectedMoneyList)
            {
                Vector3 randRotate = new Vector3(Random.Range(0, 360) ,Random.Range(0, 360) ,Random.Range(0, 360));
                Vector3 randVector = new Vector3(Random.Range(-2f, 2f), Random.Range(1f, 2f), Random.Range(-2f, 2f));
                VARIABLE.transform.DORotate(randRotate, .5f);
                VARIABLE.transform.DOLocalMove(randVector, .5f).OnComplete(()=>
                {
                    VARIABLE.transform.DOLocalMove(new Vector3(0, 0, .3f), .5f).
                        OnComplete(()=>
                        {
                            VARIABLE.transform.tag = "Money";
                            PoolSignalable.Instance.onListAdd?.Invoke(VARIABLE,PoolType.MoneyDolar);
                            CollectedMoneyList.Remove(VARIABLE);
                        });
                });
            }
        }

        public void AddAmmo(GameObject ammo)
        {
            if (CollectedAmmoList.Count < 4)
            {
                CollectedAmmoList.Add(ammo);
                ammo.transform.SetParent(moneyBag.transform);
                ammo.transform.DOLocalMove(new Vector3(0,_countY,_countZ), 1);
                ammo.transform.DOLocalRotate(Vector3.zero, 1);
                _countY += .6f;
                if (_countY > 2.4f) { _countY = 0; _countZ -= +0.3f; }
            }
            else
            {
                PlayerSignals.Instance.onAmmoFull?.Invoke(true);
            }
        }

        public GameObject RemoveAmmo()
        {
            if (CollectedAmmoList.Count > 0)
            {
                var ammo = CollectedAmmoList[CollectedAmmoList.Count - 1];
                CollectedAmmoList.Remove(ammo);
                PlayerSignals.Instance.onAmmoFull?.Invoke(false);
                _countY -= .6f;
                if (_countY <= 0f) { _countY = 2.4f; _countZ -= -0.3f; }
                if (CollectedAmmoList.Count == 0) { _countY = 0; _countZ = 0; }
                return ammo;
            }
            else
            {
                return null;
            }
        }

        public bool OnContain(GameObject money)
        {
            return CollectedMoneyList.Contains(money);
        }

        public void ResetList()
        {
            int count = CollectedMoneyList.Count;
            for (int i = 0; i < count; i++)
            {
                PlayerSignals.Instance.onMoneyReset?.Invoke(CollectedMoneyList[0]);
                CollectedMoneyList[0].transform.SetParent(transform.parent);
                CollectedMoneyList.Remove(CollectedMoneyList[0]);
            }
        }

        public int ListCount()
        {
            return CollectedMoneyList.Count;
        }
    }
}