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
                            VARIABLE.SetActive(false);
                            VARIABLE.transform.SetParent(poolMoney.transform);
                            _poolMoneyList.Add(VARIABLE);
                            _collectedMoneyList.Remove(VARIABLE);
                        });
                });
            }
        }
    }
}