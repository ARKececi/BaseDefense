using System;
using Signals;
using UnityEngine;

namespace Controllers.EnemyController
{
    public class EnemyController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private EnemyAIController enemyAIController;
        [SerializeField] private CapsuleCollider capsuleCollider;
        [SerializeField] private GameObject character;
        [SerializeField] private EnemyAnimationController enemyAnimationController;

        #endregion

        #region Private Variables

        private int _healt;
        private bool _bulletTouch;
        private int _bulletDamage;

        #endregion

        #endregion

        private void Awake()
        {
            _healt = 100;
        }

        public void Active(bool Bool)
        {
            enemyAIController.enabled = Bool;
            capsuleCollider.enabled = Bool;
            enemyAnimationController.enabled = Bool;
            character.SetActive(Bool);
            if (Bool)
            {
                enemyAnimationController.Walking();
            }
        }

        public void DamageInfo(int damage)
        {
            _bulletDamage = damage;
        }

        public void HealtDamage()
        {
            _healt -= _bulletDamage;
            if (_healt < 0)
            {
                EnemySignals.Instance.onDeadEnemy?.Invoke(transform.gameObject);
                EnemySignals.Instance.onEnemyRemove?.Invoke(transform.gameObject);
                enemyAIController.TargetWall();
                enemyAnimationController.Idle();
                _healt = 100;
            }
            Debug.Log(_healt);
        }
    }
}