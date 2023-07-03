using TMPro;
using UnityEngine;

namespace Controllers.GateController
{
    public class UIBuyGateController : MonoBehaviour
    {
        #region self Variables

        #region Serialized Variables

        [SerializeField] private TextMeshPro price;

        #endregion

        #endregion

        public void OnPrice(int Price)
        {
            price.text = Price.ToString();
        }
    }
}