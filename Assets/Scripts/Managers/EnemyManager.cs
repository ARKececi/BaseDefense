using Controllers.EnemyController;
using Signals;
using UnityEngine;

namespace Managers
{
    public class EnemyManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private EnemyAIController enemyAIController;
        [SerializeField] private EnemyController enemyController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PlayerSignals.Instance.onTargetWall += enemyAIController.OnTargetWall;
            WeaponSignals.Instance.onDamageAssigment += enemyController.DamageInfo;
        }

        private void UnsubscribeEvents()
        {
            PlayerSignals.Instance.onTargetWall -= enemyAIController.OnTargetWall;
            WeaponSignals.Instance.onDamageAssigment -= enemyController.DamageInfo;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion
    }
}