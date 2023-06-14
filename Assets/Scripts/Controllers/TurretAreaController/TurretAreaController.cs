using System;
using System.Collections.Generic;
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

        }
    }
}