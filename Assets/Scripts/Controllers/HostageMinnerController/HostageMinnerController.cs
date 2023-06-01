using System;
using DG.Tweening;
using Enums;
using Signalable;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers.HostageController
{
    public class HostageMinnerController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public int Timer;

        #endregion

        #region Serialized Variables
        
        [FormerlySerializedAs("hostageAnimationController")] [SerializeField] private HostageMinnerAnimationController hostageMinnerAnimationController;
        [FormerlySerializedAs("hostageAIController")] [SerializeField] private HostageMinnerAIController hostageMinnerAIController;

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

        private void DiamondSpawn()
        {
            _diamond = PoolSignalable.Instance.onListRemove(PoolType.MoneyDiamond);
            _diamond.transform.position = _coal.transform.position;
        }

        public void Dig(GameObject Coal)
        {
            _coal = Coal;
            DiamondSpawn();
            hostageMinnerAnimationController.Dig();
            hostageMinnerAnimationController.Idle();
            pickAxe.SetActive(true);
            DOVirtual.DelayedCall(Timer, () => DiamondMove()).OnComplete(DiamondGoes);
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

        public void BasketTrigger(GameObject Basket)
        {
            if (_diamond != null)
            {
                hostageMinnerAnimationController.Idle();
                hostageMinnerAnimationController.HandW();
            }

        }

        public void PickAxeActive(bool Active)
        {
            pickAxe.SetActive(Active);
        }

    }
}