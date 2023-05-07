using System.Collections.Generic;
using DG.Tweening;
using Signals;
using Unity.VisualScripting;
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

        private float _countY;
        private float _countZ;

        #endregion

        #endregion

        public void AddMoney(GameObject other)
        {
            MoneyController moneyController = PlayerSignals.Instance.onSetMoneyController?.Invoke(other);
            moneyController.UseKinematic(true);
            moneyController.ColliderTrigger(true);
            _collectedMoneyList.Add(other);
            other.transform.tag = "Collected";
            other.transform.SetParent(moneyBag.transform);
            other.transform.DOLocalMove(new Vector3(0,_countY += .3f,_countZ), 1);
            other.transform.DOLocalRotate(Vector3.zero, 1);
            if (_countY > 1.8f) { _countY = 0; _countZ -= +0.3f; }
        }

        public void RemoveMoney()
        {
            foreach (var VARIABLE in _collectedMoneyList)
            {
                _countY = 0;
                _countZ = 0;
                Vector3 randRotate = new Vector3(Random.Range(0, 360) ,Random.Range(0, 360) ,Random.Range(0, 360));
                Vector3 randVector = new Vector3(Random.Range(-2f, 2f), Random.Range(1f, 2f), Random.Range(-2f, 2f));
                VARIABLE.transform.DORotate(randRotate, .5f);
                VARIABLE.transform.DOLocalMove(randVector, .5f).OnComplete(()=>
                {
                    VARIABLE.transform.DOLocalMove(new Vector3(0, 0, .3f), .5f).
                        OnComplete(()=>
                        {
                            VARIABLE.SetActive(false);
                            VARIABLE.transform.SetParent(poolMoney.transform);
                            _collectedMoneyList.Remove(VARIABLE);
                        });
                });
            }
        }
    }
}