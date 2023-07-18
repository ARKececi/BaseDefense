using System.Collections.Generic;
using Controllers.TurretAreaController;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers.GateController
{
    public class GateController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public int Price;

        #endregion

        #region Serialized Variables

        [SerializeField] private List<GameObject> piece;
        [SerializeField] private UIBuyGateController uıBuyGateController;

        #endregion
        #endregion
        private void Start() 
        { 
            uıBuyGateController.OnPrice(Price);
        }

        public void PlayerTrigger()
        {
            if ((bool)ScoreSignalable.Instance.onDecreaseDiamondCount?.Invoke())
            {
                Price--;
                uıBuyGateController.OnPrice(Price);
                if (Price <= 0)
                {
                    SaveSignals.Instance.onSaveGate?.Invoke(gameObject);
                    gameObject.SetActive(false);
                }
            }
        }
        
    }
}