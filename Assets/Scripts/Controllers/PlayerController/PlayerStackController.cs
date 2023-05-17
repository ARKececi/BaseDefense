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

        public List<GameObject> _collectedMoneyList;
        public List<GameObject> _poolMoneyList;

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
            if (_collectedMoneyList.Count < 14)
            {
                _collectedMoneyList.Add(other);
                other.transform.tag = "Collected";
                other.transform.SetParent(moneyBag.transform);
                other.transform.DOLocalMove(new Vector3(0,_countY += .3f,_countZ), 1);
                other.transform.DOLocalRotate(Vector3.zero, 1);
                if (_countY > 1.8f) { _countY = 0; _countZ -= +0.3f; }
            }
        }

        public void RemoveMoney()
        {
            _countY = 0;
            _countZ = 0;
            PlayerSignals.Instance.onScoreCalculation?.Invoke(_collectedMoneyList.Count);
            foreach (var VARIABLE in _collectedMoneyList)
            {
                Vector3 randRotate = new Vector3(Random.Range(0, 360) ,Random.Range(0, 360) ,Random.Range(0, 360));
                Vector3 randVector = new Vector3(Random.Range(-2f, 2f), Random.Range(1f, 2f), Random.Range(-2f, 2f));
                VARIABLE.transform.DORotate(randRotate, .5f);
                VARIABLE.transform.DOLocalMove(randVector, .5f).OnComplete(()=>
                {
                    VARIABLE.transform.DOLocalMove(new Vector3(0, 0, .3f), .5f).
                        OnComplete(()=>
                        {
                            PoolSignalable.Instance.onListAdd?.Invoke(VARIABLE,PoolType.Money);
                            _collectedMoneyList.Remove(VARIABLE);
                        });
                });
            }
        }

        public bool OnContain(GameObject money)
        {
            return _collectedMoneyList.Contains(money);
        }

        public void ResetList()
        {
            int count = _collectedMoneyList.Count;
            for (int i = 0; i < count; i++)
            {
                _collectedMoneyList[0].transform.SetParent(transform.parent);
                _collectedMoneyList.Remove(_collectedMoneyList[0]);
            }
        }

        public int ListCount()
        {
            return _collectedMoneyList.Count;
        }
    }
}