using System.Collections.Generic;
using Extentions;
using Signals;
using UnityEngine;

namespace States.WeaponStates
{
    public class Revolver : WeaponBaseState
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject barrel;

        #endregion

        #region Private Variables
        
        private float _timer;

        #endregion

        #endregion

        private void Start()
        {
            barrelBase = barrel;
            fireRate = WeaponData["Revolver"].FlicTime;
            damage = WeaponData["Revolver"].Damage;
            _timer = fireRate;
        }

        private void Update()
        {
            if ((bool)WeaponSignals.Instance.onEnemyTrigger?.Invoke())
            {
                Timer();
            }
        }

        private void Timer()
        {
            while(_timer < 0)
            {
                Fire();
                _timer = fireRate;
            }
            _timer -= Time.deltaTime;
        }
    }
}