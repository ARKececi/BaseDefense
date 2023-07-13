using System.Collections.Generic;
using Enums;
using Extentions;
using Keys;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class SaveSignals : MonoSingleton<SaveSignals>
    {
        public UnityAction<int> onSaveMoneyScore = delegate { };
        public UnityAction<int> onSaveDiamondScore = delegate { };
        public UnityAction<string> onSaveWeaponName = delegate { };
        public UnityAction<List<WeaponType>> onSaveBuyingWeapon = delegate { };
    }
}