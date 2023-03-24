using System;
using UnityEngine;

namespace Controllers.EnemyController
{
    public class EnemyPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private EnemyAnimationController enemyAnimationController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.CompareTag("Player"))
            {
                Debug.Log("burada");
                enemyAnimationController.Fight();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                enemyAnimationController.Walking();
            }
        }
    }
}