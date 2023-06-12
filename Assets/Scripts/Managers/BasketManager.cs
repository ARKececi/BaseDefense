using System.Collections.Generic;
using Controllers.BasketController;
using DG.Tweening;
using Enums;
using Signalable;
using Signals;
using UnityEngine;

namespace Managers
{
    public class BasketManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> DiamondList;

        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject dot;
        [SerializeField] private BasketController basketController;

        #endregion

        #region Private Variables

        private float _plusX;
        private float _plusY;
        private float _plusZ;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            BasketSignalable.Instance.onDiamondAdd += OnDiamondAdd;
        }

        private void UnsubscribeEvents()
        {
            BasketSignalable.Instance.onDiamondAdd -= OnDiamondAdd;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void OnDiamondAdd(GameObject Diamond)
        {
            basketController.DiamondAdd(Diamond);
        }
    }
}