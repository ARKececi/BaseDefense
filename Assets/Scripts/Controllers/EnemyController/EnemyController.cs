using System;
using System.Collections.Generic;
using Data.UnityObject;
using Data.ValueObject;
using DG.Tweening;
using Enums;
using Signalable;
using Signals;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace Controllers.EnemyController
{
    public class EnemyController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> Money;

        public SerializedDictionary<EnemyEnum, EnemyData> Enemy;

        #endregion

        #region Serialized Variables

        [SerializeField] private EnemyAIController enemyAIController;
        [SerializeField] private EnemyAnimationController enemyAnimationController;
        [SerializeField] private EnemyAtackController enemyAtackController;
        
        [SerializeField] private GameObject moneyBag;
        [SerializeField] private GameObject enemyPhysics;
        [SerializeField] private EnemyEnum enemyEnum;
        
        #endregion

        #region Private Variables

        private int _healt;
        private bool _bulletTouch;

        #endregion

        #endregion

        private void Awake()
        {
            Enemy = GetEnemyData();
            _healt = Enemy[enemyEnum].Healt;
            enemyAtackController.GetDamage(Enemy[enemyEnum].Damage);
            enemyAIController.OnSpeed(Enemy[enemyEnum].NormalSpeed,Enemy[enemyEnum].FastSpeed);
        }
        
        private SerializedDictionary<EnemyEnum, EnemyData> GetEnemyData()
        {
            return Resources.Load<CD_Enemy>("Data/CD_Enemy").EnemyDatas;
        }

        public void HealtDamage(int damage)
        {
            _healt -= damage;
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
                    PoolSignalable.Instance.onListAdd?.Invoke(transform.gameObject,PoolType.EnemyEasy);
                    EnemySignals.Instance.onStackRemove?.Invoke();
                });
                _healt = Enemy[enemyEnum].NormalSpeed;
            }
        }

        public void GetMoneyObj()
        {
            for (int i = 0; i < 3; i++)
            {
                var money = PoolSignalable.Instance.onListRemove?.Invoke(PoolType.MoneyDolar);
                if (money != null)
                {
                    Money.Add(money);
                    money.SetActive(false);
                    money.transform.SetParent(moneyBag.transform);
                    money.transform.localPosition = Vector3.zero;
                }
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