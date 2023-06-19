using System;
using System.Collections.Generic;
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
            }
        }

        public void MoneyListRemove(GameObject money)
        {
            MoneyList.Remove(money);
            MoneyList.TrimExcess();
            if (MoneyList.Count == 0)
            {
                hostagePickerAnimationController.Idle();
            }
        }

        public void TargetHome()
        {
            
        }

        private void TargetMoney()
        {
            if (MoneyList.Count > 0) { _target = MoneyList[0].transform; }
            else _target = transform;
        }

        public void Home(GameObject home)
        {
            _home = home;
        }
    }
}