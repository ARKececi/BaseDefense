using System;
using UnityEngine;

namespace Controllers.EnemyController
{
    public class EnemyFieldPhysicsController : MonoBehaviour
    {
        #region Serialized Variables

        #region Serialized Variables

        [SerializeField] private EnemyAIController enemyAIController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                enemyAIController.OnTaretPlayer();
            }
        }
    }
}