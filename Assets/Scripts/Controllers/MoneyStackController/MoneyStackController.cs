using System;
using System.Collections.Generic;
using Signals;
using UnityEngine;

namespace Controllers.MoneyStackController
{
    public class MoneyStackController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> MoneyList;
        public List<MoneyController> MoneyControllerList;

        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject money;
        [SerializeField] private GameObject moneyBag;

        #endregion

        private int _count;
        private bool _contain;

        #endregion

        private void Awake()
        {
            _count = 0;
            for (int i = 0; i < 50; i++)
            {
                MoneyInstantiate();
            }
        }

        private void MoneyInstantiate()
        {
            var moneyObj = Instantiate(money, moneyBag.transform, true);
            MoneyControllerList.Add(moneyObj.GetComponent<MoneyController>());
            MoneyList.Add(moneyObj);
            moneyObj.SetActive(false);
        }

        public GameObject SetMoneyObj()
        {
            _contain = true;
            do
            {
                if (_contain) {_count++; }
                if (_count == MoneyList.Count) { _count = 0; }
                _contain = (bool)EnemySignals.Instance.onContains?.Invoke(MoneyList[_count]);
            } while (_contain);
            GameObject moneyObj = MoneyList[_count];
            return moneyObj;
        }

        public MoneyController SetMoneyController(GameObject money)
        {
            return MoneyControllerList[MoneyList.IndexOf(money)];
        }
    }
}