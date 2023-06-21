using TMPro;
using UnityEngine;

namespace Controllers.TurretController
{
    public class UIBuyPickerController : MonoBehaviour
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