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
            ScoreSignalable.Instance.onDecreaseMoneyCount += OnDecreaseMoneyCount;
            ScoreSignalable.Instance.onDecreaseDiamondCount += OnDecreaseDiamondCount;
            ScoreSignalable.Instance.onEvaluationMoney += OnEvaluationMoney;
        }

        private void UnsubscribeEvents()
        {
            PlayerSignals.Instance.onMoneyScoreCalculation -= OnMoneyScoreCalculation;
            BasketSignalable.Instance.onDiamondScoreCalculation -= OnDiamondScoreCalculation;
            ScoreSignalable.Instance.onDecreaseMoneyCount -= OnDecreaseMoneyCount;
            ScoreSignalable.Instance.onDecreaseDiamondCount -= OnDecreaseDiamondCount;
            ScoreSignalable.Instance.onEvaluationMoney -= OnEvaluationMoney;
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

        private bool OnDecreaseDiamondCount()
        {
            return scoreController.DecreaseDiamondCount();
        }

        private bool OnEvaluationMoney(int buy)
        {
            return scoreController.EvaluationMoney(buy);
        }
    }
}