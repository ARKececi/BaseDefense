using System;
using Enums;
using Signalable;
using UnityEngine;

namespace Controllers.EnemyController
{
    public class EnemyBodyPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private EnemyController enemyController;
        [SerializeField] private EnemyAnimationController enemyAnimationController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<BulletController>(out BulletController bullet))
            {
                enemyController.HealtDamage(bullet.SetDamage());
                PoolSignalable.Instance.onListAdd?.Invoke(other.gameObject, PoolType.BulletNormal);
            }

            if (other.CompareTag("Plane"))
            {
                enemyController.GetMoneyObj();
                enemyController.ResetPlayer();
            }
        }
    }
}