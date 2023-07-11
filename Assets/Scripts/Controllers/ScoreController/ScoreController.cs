using System;
using Keys;
using Signals;
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

        private void Awake()
        {
            _moneyScore = GetMoneyScoreSave();
            moneyScore.text = _moneyScore.ToString();
            _diamondScore = GetDiamondScoreSave();
            diamondScore.text = _diamondScore.ToString();
        }

        public int GetMoneyScoreSave()
        {
            if (!ES3.FileExists()) return 0;
            return ES3.KeyExists("MoneyScore") ? ES3.Load<int>("MoneyScore") : 0;
        }

        public int GetDiamondScoreSave()
        {
            if (!ES3.FileExists()) return 0;
            return ES3.KeyExists("DiamondScore") ? ES3.Load<int>("DiamondScore") : 0;
        }

        public void MoneyScoreCalculation(int moneyCount)
        {
            int score = Multiplier * moneyCount;
            _moneyScore += score;
            moneyScore.text = _moneyScore.ToString();
            SaveSignals.Instance.onSaveMoneyScore?.Invoke(_moneyScore);

        }

        public void DiamondScoreCalculation(int diamondCount)
        {
            int score = diamondCount;
            _diamondScore += score;
            diamondScore.text = _diamondScore.ToString();
            SaveSignals.Instance.onSaveDiamondScore?.Invoke(_diamondScore);
        }

        public bool DecreaseMoneyCount()
        {
            if (_moneyScore > 0)
            {
                _moneyScore--;
                int count = _moneyScore;
                moneyScore.text = count.ToString();
                SaveSignals.Instance.onSaveMoneyScore?.Invoke(_moneyScore);
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
                SaveSignals.Instance.onSaveDiamondScore?.Invoke(_diamondScore);
                return true;
            }
            else
            {
                _diamondScore = 0;
                return false;
            }
        }

        public bool EvaluationMoney(int buy)
        {
            if (_moneyScore >= buy)
            {
                _moneyScore -= buy;
                moneyScore.text = _moneyScore.ToString();
                SaveSignals.Instance.onSaveMoneyScore?.Invoke(_moneyScore);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}