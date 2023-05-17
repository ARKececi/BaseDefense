using System;
using System.Collections.Generic;
using DG.Tweening;
using Enums;
using Signalable;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers.EnemyController
{
    public class EnemyController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> Money;

        #endregion

        #region Serialized Variables

        [SerializeField] private EnemyAIController enemyAIController;
        [SerializeField] private CapsuleCollider capsuleCollider;
        [SerializeField] private GameObject character;
        [SerializeField] private EnemyAnimationController enemyAnimationController;
        [SerializeField] private GameObject moneyBag;
        [SerializeField] private GameObject enemyPhysics;

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
            enemyPhysics.SetActive(Bool);
            if (Bool)
            {
                enemyAnimationController.Walking();
                GetMoneyObj();
            }
            else
            {
                
            }
        }

        public void DamageInfo(int damage)
        {
            _bulletDamage = damage;
        }

        public void HealtDamage(int damage)
        {
            _healt -= damage;
            Debug.Log(_healt);
            if (_healt < 0)
            {
                enemyPhysics.SetActive(false);
                transform.tag = "Dead";
                EnemySignals.Instance.onEnemyRemove?.Invoke(transform.gameObject);
                enemyAIController.OnNullTarget();
                enemyAnimationController.Dead();
                MoneyThrow();
                DOVirtual.DelayedCall(1.30f, () =>
                {
                    //EnemySignals.Instance.onDeadEnemy?.Invoke(transform.gameObject);
                    PoolSignalable.Instance.onListAdd?.Invoke(transform.gameObject,PoolType.Enemy);
                    EnemySignals.Instance.onStackRemove?.Invoke();

                });
                _healt = 100;
            }
        }

        public void GetMoneyObj()
        {
            for (int i = 0; i < 3; i++)
            {
                var money = PoolSignalable.Instance.onListRemove?.Invoke(PoolType.Money);
                Money.Add(money);
                money.SetActive(false);
                money.transform.SetParent(moneyBag.transform);
                money.transform.localPosition = Vector3.zero;
            }
        }

        public void ResetPlayer()
        {
            enemyAnimationController.Walking();
            enemyAIController.TargetWall();
            transform.tag = "Enemy";
        }

        private void MoneyThrow()
        {
            int count = Money.Count;
            for (int i = 0; i < count; i++)
            {
                Money[0].transform.SetParent(transform.parent);
                Money[0].SetActive(true);
                Money.Remove(Money[0]);
            }
        }
    }
}