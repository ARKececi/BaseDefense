using Extentions;
using Signals;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Weapons.Rifle.AK_47.AK_47State
{
    public class AK_47 : WeaponBaseState
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
            fireRate = WeaponData["AK_47"].FlicTime;
            damage = WeaponData["AK_47"].Damage;
            _timer = fireRate;
        }

        public void Upgrade()
        {
            damage += 15;
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