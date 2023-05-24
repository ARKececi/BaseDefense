using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class MiningDistrictManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private List<GameObject> coals;

        #endregion

        private List<GameObject> coalList;

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {

        }

        private void UnsubscribeEvents()
        {

        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        public List<GameObject> OnCoalsList()
        {
            return coals;
        }
    }
}