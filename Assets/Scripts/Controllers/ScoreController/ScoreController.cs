using TMPro;
using UnityEngine;

namespace Controllers.ScoreController
{
    public class ScoreController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public int Multiplier;

        #endregion

        #region Serialized Variables

        [SerializeField] private TextMeshProUGUI moneyScore;
        [SerializeField] private TextMeshProUGUI diamondScore;

        #endregion

        #region Private Variables

        private int _moneyScore;
        private int _diamondScore;

        #endregion

        #endregion

        public void MoneyScoreCalculation(int moneyCount)
        {
            int score = Multiplier * moneyCount;
            _moneyScore += score;
            moneyScore.text = _moneyScore.ToString();
        }

        public void DiamondScoreCalculation(int diamondCount)
        {
            int score = diamondCount;
            _diamondScore += score;
            diamondScore.text = _diamondScore.ToString();
        }

        public bool DecreaseMoneyCount()
        {
            if (_moneyScore > 0)
            {
                _moneyScore--;
                int count = _moneyScore;
                moneyScore.text = count.ToString();
                return true;
            }
            else
            {
                _moneyScore = 0;
                return false;
            }
        }
        
        public bool DecreaseDiamondCount()
        {
            if (_diamondScore > 0)
            {
                _diamondScore--;
                int count = _diamondScore;
                diamondScore.text = count.ToString();
                return true;
            }
            else
            {
                _diamondScore = 0;
                return false;
            }
        }
    }
}