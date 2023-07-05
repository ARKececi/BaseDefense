using Controllers.UIManager;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private UIPanelController panelController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            UISignals.Instance.onClosePanel += OnClosePanel;
        }

        private void UnsubscribeEvents()
        {
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
            UISignals.Instance.onClosePanel -= OnClosePanel;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion

        private void OnOpenPanel(UIPanel panel)
        {
            panelController.OpenPanel(panel);
        }

        private void OnClosePanel(UIPanel panel)
        {
            panelController.ClosePanel(panel);
        }
    }
}