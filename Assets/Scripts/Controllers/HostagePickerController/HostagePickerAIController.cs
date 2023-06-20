using System;
using System.Collections.Generic;
using Signals;
using UnityEngine;
using UnityEngine.AI;

namespace Controllers.HostagePickerController
{
    public class HostagePickerAIController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> MoneyList;

        #endregion

        #region Serialized Variables
        
        [SerializeField] private HostagePickerAnimationController hostagePickerAnimationController;
        [SerializeField] private NavMeshAgent agent;

        #endregion

        #region Private Variables

        private Transform _target;
        private GameObject _home;

        #endregion

        #endregion

        private void Start()
        {
            _home = HostagePickerSignalable.Instance.onHome?.Invoke();
            TargetMy();
        }

        private void Update()
        {
            agent.destination = _target.position;
        }

        public void MoneyListAdd(GameObject money)
        {
            MoneyList.Add(money);
            MoneyList.TrimExcess();
            if (MoneyList.Count == 1)
            {
                hostagePickerAnimationController.Walking();
                TargetMoney();
            }
        }

        public void MoneyListRemove(GameObject money)
        {
            if (MoneyList.Contains(money))
            {
                MoneyList.Remove(money);
                MoneyList.TrimExcess();
                if (MoneyList.Count == 0)
                {
                    hostagePickerAnimationController.Idle();
                    TargetMy();
                }
            }
        }

        public void TargetHome()
        {
            _target = _home.transform;
        }

        private void TargetMoney()
        {
            _target = MoneyList[0].transform;
        }

        public void TargetMy()
        {
            _target = transform;
        }
        
    }
}