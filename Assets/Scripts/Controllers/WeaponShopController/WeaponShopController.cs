using Enums;
using Signals;
using UnityEngine;

namespace Controllers.WeaponShopController
{
    public class WeaponShopController : MonoBehaviour
    {

        public void PanelOpen()
        {
            UISignals.Instance.onOpenPanel?.Invoke(UIPanel.WeaponShop);
        }

        public void PanelClose()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanel.WeaponShop);
        }
    }
}