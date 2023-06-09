using System.Collections.Generic;
using DG.Tweening;
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
            DiamondList.Add(Diamond);
            Diamond.transform.SetParent(dot.transform);
            Diamond.transform.DOLocalMove(new Vector3(_plusX,_plusY,_plusZ), 1);
            if (_plusX < .8f)
            {
                _plusX += .2f;
            }
            else
            {
                if (_plusZ > -.8f)
                {
                    _plusX = 0;
                    _plusZ -= .2f;
                }
                else
                {
                    _plusX = 0;
                    _plusZ = 0;
                    _plusY += 1;
                }
            }
        }
    }
}