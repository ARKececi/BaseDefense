using System;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class ScoreSignalable : MonoSingleton<ScoreSignalable>
    {
       public Func<bool> onMoneyScoreCalculation = delegate { return false;};
    }
}