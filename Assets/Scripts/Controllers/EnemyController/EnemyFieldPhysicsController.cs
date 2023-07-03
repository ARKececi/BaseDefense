using System;
using UnityEngine;

namespace Controllers.EnemyController
{
    public class EnemyFieldPhysicsController : MonoBehaviour
    {
        #region Serialized Variables

        #region Serialized Variables

        [SerializeField] private EnemyAIController enemyAIController;
        [SerializeField] private EnemyAnimationController enemyAnimationController;
        [SerializeField] private EnemyController enemyController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (enemyAIController.ReSafeHouse() == false)
                {
                    enemyAIController.OnTaretPlayer();
                }
            }

            if (other.CompareTag("Plane"))
            {
                enemyAIController.FirstSafeHouse();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (enemyAIController.ReSafeHouse() == false && enemyController.Dead() == false)
                {
                    enemyAIController.TargetWall();
                }
            }
            
        }
    }
}