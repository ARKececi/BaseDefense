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

        public PlayerData playerData;

        #region Serialized Variables
        
        [FormerlySerializedAs("_hostageAIController")] [SerializeField] private HostageMinnerAIController hostageMinnerAIController;

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
            playerData = GetPlayerData();
            
            hostageMinnerAIController.GetAgentSpeed(playerData.MoveSpeed);
        }

        private PlayerData GetPlayerData()
        {
            return Resources.Load<CD_Player>("Data/CD_Player").PlayerData;
        }
    }
}