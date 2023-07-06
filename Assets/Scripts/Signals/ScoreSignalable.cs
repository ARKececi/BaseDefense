using System;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class ScoreSignalable : MonoSingleton<ScoreSignalable>
    {
       public Func<bool> onDecreaseMoneyCount = delegate { return false; };
       public Func<bool> onDecreaseDiamondCount = delegate { return false; };
       public Func<int,bool> onEvaluationMoney = delegate { return false; };
    }
}