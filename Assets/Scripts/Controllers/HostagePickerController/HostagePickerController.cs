using System.Collections.Generic;
using DG.Tweening;
using Enums;
using Signalable;
using Signals;
using UnityEngine;

namespace Controllers.HostagePickerController
{
    public class HostagePickerController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> MoneyList;

        #endregion

        #region Serialized Variables

        [SerializeField] private HostagePickerAIController hostagePickerAIController;
        [SerializeField] private GameObject moneyBag;

        #endregion

        #region Private Variables

        private float _countY;
        private float _countZ;

        #endregion

        #endregion

        public void MoneyListAdd(GameObject money)
        {
            if (MoneyList.Count <= 14)
            {
                MoneyList.Add(money);
                MoneyList.TrimExcess();
                money.transform.tag = "Collected";
                money.transform.SetParent(moneyBag.transform);
                hostagePickerAIController.MoneyListRemove(money);
                money.transform.DOLocalMove(new Vector3(0,_countY += .3f,_countZ), 1);
                money.transform.DOLocalRotate(Vector3.zero, 1);
                if (_countY > 1.8f) { _countY = 0; _countZ -= +0.3f; }
                if (MoneyList.Count >= 14) hostagePickerAIController.TargetHome();
            }
        }

        public void MoneyListRemove()
        {
            _countY = 0;
            _countZ = 0;
            PlayerSignals.Instance.onMoneyScoreCalculation?.Invoke(MoneyList.Count);
            foreach (var VARIABLE in MoneyList)
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
                            MoneyList.Remove(VARIABLE);
                            MoneyList.TrimExcess();
                        });
                });
            }
        }
    }
}