using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class StackController : MonoBehaviour
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

        private float _count;

        #endregion

        #endregion

        public void AddMoney(GameObject other)
        {
            _collectedMoneyList.Add(other);
            other.transform.tag = "Collected";
            other.transform.SetParent(moneyBag.transform);
            other.transform.DOLocalMove(new Vector3(0,_count += .3f,0), 1);
            other.transform.DOLocalRotate(Vector3.zero, 1);
        }

        public void RemoveMoney()
        {
            for (int i = 0; i < _collectedMoneyList.Count; i++)
            {
                _collectedMoneyList[0].transform.SetParent(poolMoney.transform);
                _poolMoneyList.Add(_collectedMoneyList[0]);
                _collectedMoneyList.Remove(_collectedMoneyList[0]);
            }
        }
    }
}