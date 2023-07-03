using System;
using System.Collections.Generic;
using DG.Tweening;
using Enums;
using Signalable;
using Signals;
using UnityEngine;

namespace Controllers.BasketController
{
    public class BasketController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> DiamondList;
        public float Timer;

        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject dot;

        #endregion

        #region Private Variables

        private float _plusX;
        private float _plusY;
        private float _plusZ;

        private bool _trigger;
        private float _timer;
        private GameObject _player;

        #endregion

        #endregion

        private void Start()
        {
            _timer = Timer;
            _player = EnemySignals.Instance.onEnemyTarget?.Invoke().gameObject;
        }

        private void Update()
        {
            DiamondCollect();
        }

        public void PlayerTrigger(bool InOut)
        {
            _trigger = InOut;
        }

        private void DiamondCollect()
        {
            if (_trigger)
            {
                if (DiamondList.Count > 0)
                {
                    if (_timer < 0)
                    {
                        RemoveDiamond();
                        _timer = Timer;
                    }
                    _timer -= UnityEngine.Time.deltaTime;
                }
            }
        }
        
        public void DiamondAdd(GameObject Diamond)
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
        
        public void RemoveDiamond()
        {
            int Count = DiamondList.Count - 1;
            BasketSignalable.Instance.onDiamondScoreCalculation?.Invoke(1);
            DiamondList[Count].transform.SetParent(_player.transform);
            DiamondList[Count].transform.DOLocalMove(new Vector3(0,.5f,0), Timer).OnComplete(() =>
            {
                PoolSignalable.Instance.onListAdd?.Invoke(DiamondList[Count],PoolType.MoneyDiamond);
                DiamondList.Remove(DiamondList[Count]);
            });
            
            
            _plusX = 0;
            _plusZ = 0;
            _plusY = 0;
        }
    }
}