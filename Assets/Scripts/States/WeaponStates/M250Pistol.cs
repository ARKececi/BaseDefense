using System.Collections.Generic;
using Extentions;
using Signals;
using UnityEngine;

namespace States.WeaponStates
{
    public class M250Pistol : WeaponBaseState
    {
        #region Self Variables

        #region Public Variables
        
        public List<string> _weaponName;

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
            foreach (var weapon in WeaponData)
            {
                _weaponName.Add(weapon.Key);
            }

            barrelBase = barrel;
            fireRate = WeaponData[_weaponName[0]].FlicTime;
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
                Debug.Log("burada");
            }
            _timer -= Time.fixedDeltaTime;
        }
    }
}