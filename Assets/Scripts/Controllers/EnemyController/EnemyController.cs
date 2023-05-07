using System;
using System.Collections.Generic;
using Signals;
using UnityEngine;

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
        [SerializeField] private GameObject MoneyBag;

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
                GetMoneyObj();
            }
            else
            {
                MoneyThrow();
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
        }

        private void GetMoneyObj()
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject money = EnemySignals.Instance.onSetMoneyObj?.Invoke();
                MoneyController moneyController = PlayerSignals.Instance.onSetMoneyController?.Invoke(money);
                moneyController.UseKinematic(false);
                moneyController.ColliderTrigger(false);
                Money.Add(money);
                money.transform.SetParent(MoneyBag.transform);
                money.transform.localPosition = Vector3.zero;
                money.SetActive(false);
            }
        }

        private void MoneyThrow()
        {
            for (int i = 0; i < Money.Count; i++)
            {
                Money[0].transform.SetParent(transform.parent);
                Money[0].SetActive(true);
                Money.Remove(Money[0]);
            }
        }
    }
}