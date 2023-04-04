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

        private void MoneyZeroMove()
        {
            for (int i = _poolMoneyList.Count - 1; i >= 0; i--)
            {
                _poolMoneyList[i].transform.DOLocalMove(new Vector3(0,0,0.3f), 0.5f);
            }
        }

        public void RemoveMoney()
        {
            for (int i = _collectedMoneyList.Count - 1; i >= 0; i--)
            {
                float randZ = Random.Range(-2f, 2f); float ranX = Random.Range(-2f, 2f); float ranY = Random.Range(1f, 2f); var ranQ = Random.Range(0,360);
                //_collectedMoneyList[i].transform.SetParent(poolMoney.transform);
                _collectedMoneyList[i].transform.DORotate(new Vector3(ranQ, ranQ, ranQ), 1);
                _collectedMoneyList[i].transform.DOLocalJump(new Vector3(ranX, ranY, randZ), 1, 1, 1);
                _poolMoneyList.Add(_collectedMoneyList[i]);
                _collectedMoneyList.Remove(_collectedMoneyList[i]);
            }

            DOVirtual.DelayedCall(1, () => MoneyZeroMove());
        }
    }
}