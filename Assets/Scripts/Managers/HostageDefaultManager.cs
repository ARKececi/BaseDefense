using Controllers.HostageController;
using Data.UnityObject;
using Data.ValueObject;
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

        #endregion

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
    }
}