using Controllers.SaveController;
using Keys;
using Signals;
using UnityEngine;

namespace Managers
{
    public class SaveManager : MonoBehaviour
    {
        #region Serl Variables

        #region Serialized Variables

        [SerializeField] private SaveController saveController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            SaveSignals.Instance.onSaveMoneyScore += OnSaveMoneyScore;
            SaveSignals.Instance.onSaveDiamondScore += OnSaveDiamondScore;
        }

        private void UnsubscribeEvents()
        {
            SaveSignals.Instance.onSaveMoneyScore -= OnSaveMoneyScore;
            SaveSignals.Instance.onSaveDiamondScore -= OnSaveDiamondScore;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion
        
        private void OnSaveMoneyScore(int moneyCount)
        {
            saveController.SaveMoneyScore(moneyCount);
        }

        private void OnSaveDiamondScore(int diamondCount)
        {
            saveController.SaveDiamondScore(diamondCount);
        }

        private void OnSaveWeapon(string weaponName)
        {
            saveController.SaveWeapon(weaponName);
        }
    }
}