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

        #endregion

        #region Private Variables

        private int _moneyScore;

        #endregion

        #endregion

        public void ScoreCalculation(int moneyCount)
        {
            int score = Multiplier * moneyCount;
            _moneyScore += score;
            moneyScore.text = _moneyScore.ToString();
        }
    }
}