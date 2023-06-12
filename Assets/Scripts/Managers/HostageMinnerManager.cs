using System;
using Controllers.HostageController;
using Data.UnityObject;
using Data.ValueObject;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class HostageMinnerManager : MonoBehaviour
    {
        #region Self Variables

        public MinerData minerData;

        #region Serialized Variables
        
        [SerializeField] private HostageMinnerAIController hostageMinnerAIController;
        [SerializeField] private HostageMinnerController hostageMinnerController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {

        }

        private void UnsubscribeEvents()
        {

        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void Awake()
        {
            minerData = GetMinerData();
            
            hostageMinnerAIController.GetAgentSpeed(minerData.Speed);
            hostageMinnerController.DigTimer(minerData.DigTimer);
        }

        private MinerData GetMinerData()
        {
            return Resources.Load<CD_Miner>("Data/CD_Miner").MinerData;
        }
    }
}