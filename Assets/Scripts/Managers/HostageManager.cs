using System;
using Controllers.HostageController;
using Data.UnityObject;
using Data.ValueObject;
using Signals;
using UnityEngine;

namespace Managers
{
    public class HostageManager : MonoBehaviour
    {
        #region Self Variables

        public PlayerData playerData;

        #region Serialized Variables

        [SerializeField] private HostageController _hostageController;
        [SerializeField] private HostageAIController _hostageAIController;
        

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            HostageSignalable.Instance.onMining += OnMiningTarget;
        }

        private void UnsubscribeEvents()
        {
            HostageSignalable.Instance.onMining -= OnMiningTarget;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void Awake()
        {
            playerData = GetPlayerData();
            
            _hostageAIController.GetAgentSpeed(playerData.MoveSpeed);
        }

        private PlayerData GetPlayerData()
        {
            return Resources.Load<CD_Player>("Data/CD_Player").PlayerData;
        }

        public void OnMiningTarget()
        {
            _hostageAIController.MiningTarget();
        }
    }
}