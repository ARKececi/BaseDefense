using System.Collections.Generic;
using Enums;
using Extentions;
using Keys;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace Signals
{
    public class SaveSignals : MonoSingleton<SaveSignals>
    {
        public UnityAction<int> onSaveMoneyScore = delegate { };
        public UnityAction<int> onSaveDiamondScore = delegate { };
        public UnityAction<string> onSaveWeaponName = delegate { };
        public UnityAction<List<WeaponType>> onSaveBuyingWeapon = delegate { };
        public UnityAction<WeaponType, int> onSaveWeaponUpgrade = delegate { };
        public UnityAction onSavePickerMan = delegate { };
        public UnityAction onSaveTransporterMan = delegate { };
        public UnityAction<GameObject,GameObject> onSaveTurretArea = delegate { };
        public UnityAction<GameObject, GameObject> onSaveOperatorMan = delegate { };
    }
}