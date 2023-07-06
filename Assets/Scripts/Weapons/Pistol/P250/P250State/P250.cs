using Extentions;
using Signals;
using UnityEngine;

namespace Weapons.Pistol.P250.P250State
{
    public class P250 : WeaponBaseState
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject barrel;
        [SerializeField] private GameObject weapon;

        #endregion

        #region Private Variables
        
        private float _timer;

        #endregion

        #endregion
        
        private void Start()
        {
            barrelBase = barrel;
            fireRate = WeaponData["P250"].FlicTime;
            damage = WeaponData["P250"].Damage;
            _timer = fireRate;
        }

        public void Upgrade()
        {
            damage += 10;
        }

        private void Update()
        {
            if ((bool)WeaponSignals.Instance.onEnemyTrigger?.Invoke() && weapon.activeSelf)
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
            _timer -= Time.fixedDeltaTime;
        }
    }
}