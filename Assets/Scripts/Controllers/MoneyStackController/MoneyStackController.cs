using System;
using System.Collections.Generic;
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
            GameObject moneyObj = MoneyList[_count];
            _count++;
            if (_count == MoneyList.Count) { _count = 0;}
            return moneyObj;
        }

        public MoneyController SetMoneyController(GameObject money)
        {
            return MoneyControllerList[MoneyList.IndexOf(money)];
        }
    }
}