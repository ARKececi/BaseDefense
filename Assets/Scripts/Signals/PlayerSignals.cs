using System;
using Controllers;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class PlayerSignals : MonoSingleton<PlayerSignals>
    {
        public UnityAction onTargetWall = delegate { };
        public UnityAction onSafeHouse = delegate { };
        public UnityAction<bool> onWeaponActive = delegate { };

        public UnityAction<int> onScoreCalculation = delegate {  };
        public UnityAction onMoneyReset = delegate { };
        public Func<int> onListCount = delegate { return 0;};
        
        public Func<GameObject,GameObject> onLastHostage = delegate { return null;};
    }
}