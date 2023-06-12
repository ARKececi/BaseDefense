using System;
using DG.Tweening;
using Enums;
using Signalable;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers.HostageController
{
    public class HostageMinnerController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public float Timer;

        #endregion

        #region Serialized Variables
        
        [SerializeField] private HostageMinnerAnimationController hostageMinnerAnimationController;
        [SerializeField] private HostageMinnerAIController hostageMinnerAIController;

        [SerializeField] private GameObject diamondBag;
        [SerializeField] private GameObject pickAxe;

        #endregion

        #region Private Variables
        
        private GameObject _diamond;
        private GameObject _coal;

        #endregion

        #endregion

        private void Awake()
        {
        }

        public void DigTimer(float timer)
        {
            Timer = timer;
        }

        private void DiamondSpawn()
        {
            _diamond = PoolSignalable.Instance.onListRemove(PoolType.MoneyDiamond);
            _diamond.transform.position = _coal.transform.position;
        }

        public void Dig(GameObject Coal)
        {
            if (_diamond == null)
            {
                _coal = Coal;
                DiamondSpawn();
                hostageMinnerAIController.ObstacleMinnig();
                hostageMinnerAnimationController.Dig();
                hostageMinnerAnimationController.Idle();
                pickAxe.SetActive(true);
                DOVirtual.DelayedCall(Timer, () => DiamondMove()).OnComplete(()=>
                {
                    hostageMinnerAIController.ObstacleMinnig();
                    DiamondGoes();
                });
            }
        }

        private void DiamondGoes()
        {
            hostageMinnerAnimationController.Walking();
            hostageMinnerAIController.BasketTarget();
        }
        
        private void DiamondMove()
        {
            hostageMinnerAnimationController.Hold();
            _diamond.transform.SetParent(diamondBag.transform);
            _diamond.transform.DOLocalMove(Vector3.zero, 1);
        }

        public void BasketTrigger()
        {
            if (_diamond != null)
            {
                hostageMinnerAnimationController.HandW();
                BasketSignalable.Instance.onDiamondAdd?.Invoke(_diamond);
                hostageMinnerAIController.MiningTarget();
                _diamond = null;
            }

        }

        public void PickAxeActive(bool Active)
        {
            pickAxe.SetActive(Active);
        }

    }
}