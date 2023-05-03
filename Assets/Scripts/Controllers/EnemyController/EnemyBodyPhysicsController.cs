using System;
using UnityEngine;

namespace Controllers.EnemyController
{
    public class EnemyBodyPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private EnemyController enemyController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                enemyController.HealtDamage();
            }
        }
    }
}