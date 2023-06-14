using TMPro;
using UnityEngine;

namespace Controllers.TurretAreaController
{
    public class UIBuyController : MonoBehaviour
    {
        #region self Variables

        #region Serialized Variables

        [SerializeField] private TextMeshProUGUI price;

        #endregion

        #endregion

        public void OnPrice(int Price)
        {
            price.text = Price.ToString();
        }
    }
}