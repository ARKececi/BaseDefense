using System;
using System.Collections.Generic;
using Signals;
using UnityEngine;

namespace Controllers.TurretAreaController
{
    public class TurretAreaController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public int Price;

        #endregion

        #region Serialized Variables

        [SerializeField] private List<GameObject> piece;
        [SerializeField] private UIBuyController uıBuyController;

        #endregion

        #endregion

        private void Start()
        {
            uıBuyController.OnPrice(Price);
        }

        public void PlayerTrigger()
        {
            if ((bool)ScoreSignalable.Instance.onDecreaseMoneyCount?.Invoke())
            {
                uıBuyController.OnPrice(Price--);
                if (Price <= 0)
                {
                    SaveSignals.Instance.onSaveTurretArea?.Invoke(piece[1],piece[0]);
                    piece[1].SetActive(true);
                    piece[0].gameObject.SetActive(false);
                }
            }
        }
    }
}