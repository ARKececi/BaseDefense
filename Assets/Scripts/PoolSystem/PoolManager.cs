using Controllers;
using Controllers.PoolController;
using Enums;
using Signalable;
using Signals;
using UnityEngine;

namespace Managers
{
    public class PoolManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PoolController poolController; 
        
        #endregion

        #endregion
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PoolSignalable.Instance.onListAdd += OnListAdd;
            PoolSignalable.Instance.onListRemove += OnListRemove;
        }

        private void UnsubscribeEvents()
        {
            PoolSignalable.Instance.onListAdd -= OnListAdd;
            PoolSignalable.Instance.onListRemove -= OnListRemove;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        public void OnListAdd(GameObject poolObj, PoolType poolType)
        {
            poolController.Listadd(poolObj,poolType);
        }

        public GameObject OnListRemove(PoolType poolType)
        {
            return poolController.ListRemove(poolType);
        }
    }
}