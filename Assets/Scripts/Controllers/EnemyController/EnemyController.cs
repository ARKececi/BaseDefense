using System;
using System.Collections.Generic;
using DG.Tweening;
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

        public void HealtDamage()
        {
            _healt -= _bulletDamage;
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
                    EnemySignals.Instance.onDeadEnemy?.Invoke(transform.gameObject);
                    enemyAnimationController.Walking();
                    enemyAIController.TargetWall();
                    transform.tag = "Enemy";
                });
                _healt = 100;
            }
        }

        private void GetMoneyObj()
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject money = EnemySignals.Instance.onSetMoneyObj?.Invoke();
                MoneyController moneyController = PlayerSignals.Instance.onSetMoneyController?.Invoke(money);
                moneyController.UseKinematic(false);
                moneyController.ColliderTrigger(false);
                moneyController.tag = "Money";
                Money.Add(money);
                money.transform.SetParent(moneyBag.transform);
                money.transform.localPosition = Vector3.zero;
                money.SetActive(false);
            }
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