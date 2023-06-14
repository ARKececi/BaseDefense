using Controllers.ScoreController;
using Signals;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private ScoreController scoreController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PlayerSignals.Instance.onMoneyScoreCalculation += OnMoneyScoreCalculation;
            BasketSignalable.Instance.onDiamondScoreCalculation += OnDiamondScoreCalculation;
        }

        private void UnsubscribeEvents()
        {
            PlayerSignals.Instance.onMoneyScoreCalculation -= OnMoneyScoreCalculation;
            BasketSignalable.Instance.onDiamondScoreCalculation -= OnDiamondScoreCalculation;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion

        private void OnMoneyScoreCalculation(int moneyCount)
        {
            scoreController.MoneyScoreCalculation(moneyCount);
        }

        private void OnDiamondScoreCalculation(int diamondCount)
        {
            scoreController.DiamondScoreCalculation(diamondCount);
        }

        private bool OnDecreaseMoneyCount()
        {
            return scoreController.DecreaseMoneyCount();
        }
    }
}