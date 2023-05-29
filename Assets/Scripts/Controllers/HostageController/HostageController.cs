using System;
using DG.Tweening;
using Enums;
using Signalable;
using UnityEngine;

namespace Controllers.HostageController
{
    public class HostageController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public int Timer;

        #endregion

        #region Serialized Variables
        
        [SerializeField] private HostageAnimationController hostageAnimationController;
        [SerializeField] private HostageAIController hostageAIController;

        [SerializeField] private GameObject diamondBag;
        [SerializeField] private GameObject pickAxe;

        #endregion

        #region Private Variables

        private float _timer;
        private GameObject _diamond;
        private GameObject _coal;

        #endregion

        #endregion

        private void Awake()
        {
            _timer = Timer;
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
            hostageAnimationController.Dig();
            hostageAnimationController.Idle();
            hostageAIController.TargetMe();
            pickAxe.SetActive(true);
            DOVirtual.DelayedCall(Timer, () => DiamondMove());
        }

        private void DiamondMove()
        {
            hostageAnimationController.Hold();
            _diamond.transform.SetParent(diamondBag.transform);
            _diamond.transform.DOLocalMove(Vector3.zero, 1);
        }

        public void PickAxeActive(bool Active)
        {
            pickAxe.SetActive(Active);
        }
        
        
    }
}