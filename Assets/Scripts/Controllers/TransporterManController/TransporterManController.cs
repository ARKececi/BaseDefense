using System.Collections.Generic;
using DG.Tweening;
using Signals;
using UnityEngine;

namespace Controllers.TransporterManController
{
    public class TransporterManController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> CollectedAmmoList;
        public float Timer;

        #endregion
        
        #region Serialized Variables

        [SerializeField] private GameObject moneyBag;

        #endregion

        #region Private Variables
        
        private float _countY;
        private float _countZ;
        private float _timer;
        private bool _ammobox;
        private bool _turretStack;

        #endregion

        #endregion
        
        private void FixedUpdate()
        {
            if (_ammobox)
            {
                PullAmmo();
            }
            if (_turretStack)
            {
                PushAmmo();
            }
        }
        
        public void TrueAmmoBox() { _ammobox = true; }
        public void FalseAmmoBox() { _ammobox = false; }
        public void TrueTurretStack(){_turretStack = true;}
        public void FalseTurretStack(){_turretStack = false;}
        
        public void AddAmmo(GameObject ammo)
        {
            if (CollectedAmmoList.Count < 4)
            {
                CollectedAmmoList.Add(ammo);
                ammo.transform.SetParent(moneyBag.transform);
                ammo.transform.DOLocalMove(new Vector3(0,_countY,_countZ), 1);
                ammo.transform.DOLocalRotate(Vector3.zero, 1);
                _countY += .6f;
                if (_countY > 2.4f) { _countY = 0; _countZ -= +0.3f; }
            }
        }

        public void PullAmmo()
        {
            if (_timer < 0)
            {
                if (CollectedAmmoList.Count < 4)
                {
                    GameObject ammo = AmmoBoxSignals.Instance.onPushAmmo?.Invoke();
                    AddAmmo(ammo);
                    _timer = Timer;
                }
            }
            _timer -= UnityEngine.Time.deltaTime;
        }

        public void PushAmmo()
        {
            if (_timer < 0)
            {
                if (CollectedAmmoList.Count > 0)
                {
                    DellAmmo();
                    _timer = Timer;
                }
            }
            _timer -= UnityEngine.Time.deltaTime;
        }

        public void DellAmmo()
        {
            var ammo = CollectedAmmoList[CollectedAmmoList.Count - 1];
            CollectedAmmoList.Remove(ammo);
            TurretSignals.Instance.onPullAmmo?.Invoke(ammo);
            if (_countY <= 0f) { _countY = 2.4f; _countZ -= -0.3f; }
            if (CollectedAmmoList.Count == 0) { _countY = 0; _countZ = 0; }
        }
    }
}