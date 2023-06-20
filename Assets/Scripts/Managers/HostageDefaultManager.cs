using System;
using Controllers.HostageController;
using Controllers.HostageDefaultController;
using Data.UnityObject;
using Data.ValueObject;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class HostageDefaultManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public PlayerData playerData;

        #endregion

        #region Serialized Variables

        [SerializeField] private HostageDefaultAIController hostageDefaultAIController;
        [SerializeField] private HostageDefaultController hostageDefaultController;
        [SerializeField] private HostageDefaultAnimationController hostageDefaultAnimationController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            HostageDefaultSignalable.Instance.Reset += Reset;
        }

        private void UnsubscribeEvents()
        {
            HostageDefaultSignalable.Instance.Reset -= Reset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion
        private void Start()
        {
            playerData = GetPlayerData();
            
            hostageDefaultAIController.GetAgentSpeed(playerData.MoveSpeed);
        }
        
        private PlayerData GetPlayerData()
        {
            return Resources.Load<CD_Player>("Data/CD_Player").PlayerData;
        }

        public void Reset(GameObject hostage)
        {
            if (hostage == transform.gameObject)
            {
                hostageDefaultAIController.Reset();
                hostageDefaultController.Reset();
            }
        }
    }
}