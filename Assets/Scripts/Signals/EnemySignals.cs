using System;
using System.Collections.Generic;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class EnemySignals : MonoSingleton<EnemySignals>
    {
        public Func<Transform> onEnemyTarget = delegate { return null; };
        public Func<List<GameObject>> onWall = delegate { return null; };
        public UnityAction<GameObject> onDeadEnemy = delegate { };
        public UnityAction<GameObject> onEnemyRemove = delegate { };
        public Func<List<GameObject>> onEnemyList = delegate { return null; };
        public Func<GameObject> onSetMoneyObj = delegate { return null; };
    }
}