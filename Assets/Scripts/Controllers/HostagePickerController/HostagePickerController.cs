using System.Collections.Generic;
using DG.Tweening;
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
            if (MoneyList.Count < 14)
            {
                MoneyList.Add(money);
                money.transform.tag = "Collected";
                money.transform.SetParent(moneyBag.transform);
                hostagePickerAIController.MoneyListRemove(money);
                money.transform.DOLocalMove(new Vector3(0,_countY += .3f,_countZ), 1);
                money.transform.DOLocalRotate(Vector3.zero, 1);
                if (_countY > 1.8f) { _countY = 0; _countZ -= +0.3f; }
            }
            else
            {
                
            }
        }

        public void MoneyListRemove()
        {
            
        }
    }
}