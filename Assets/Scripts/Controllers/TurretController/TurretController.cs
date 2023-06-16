using System;
using System.Collections.Generic;
using Controllers.TurretAreaController;
using DG.Tweening;
using Enums;
using Signalable;
using Signals;
using UnityEngine;

namespace Controllers.TurretController
{
    public class TurretController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> Enemys;
        public float Timer;
        public int Price;
        public List<GameObject> Piece;
        public List<GameObject> Ammo;

        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject turretOperator;
        [SerializeField] private GameObject turret;
        [SerializeField] private GameObject barrel;
        [SerializeField] private GameObject dot;
        [SerializeField] private UIBuyOperatorController uıBuyOperatorController;

        #endregion

        #region Private Variables

        private float _timer;
        private float _plusX;
        private float _plusY;
        private float _plusZ;
        private int _ammoCount;

        #endregion

        #endregion

        private void Start()
        {
            uıBuyOperatorController.OnPrice(Price);
            _plusX = -1;
            _plusY = 1;
            _plusZ = 0;
        }

        public void AddEnemy(GameObject enemy)
        {
            Enemys.Add(enemy);
        }

        public void RemoveEnemy(GameObject enemy)
        {
            if (Enemys.Contains(enemy))
            {
                Enemys.Remove(enemy);
            }
        }

        public void AddAmmo(GameObject ammo)
        {
            if (ammo != null)
            {
                Ammo.Add(ammo);
                ammo.transform.SetParent(dot.transform);
                ammo.transform.eulerAngles = Vector3.zero;
                ammo.transform.DOLocalMove(new Vector3(_plusX, _plusY, _plusZ), .5f);
                if (_plusX < 1)
                {
                    _plusX += 2;
                }
                else
                {
                    _plusX = -1;
                    if (_plusY > -1)
                    {
                        _plusY -= 2;
                    }
                    else
                    {
                        _plusX = -1;
                        _plusY = 1;
                        _plusZ -= .5f;
                    }
                }
            }
        }

        private void Update()
        {
            Target();
            Fire();
        }

        public void PlayerTrigger()
        {
            if ((bool)ScoreSignalable.Instance.onMoneyScoreCalculation?.Invoke())
            {
                uıBuyOperatorController.OnPrice(Price--);
                if (Price <= 0)
                {
                    Piece[1].SetActive(true);
                    Piece[0].gameObject.SetActive(false);
                }
            }
        }

        private void Fire()
        {
            if (turretOperator.activeSelf)
            {
                if (Ammo.Count > 0)
                {
                    if (Enemys.Count > 0)
                    {
                        if (_timer < 0)
                        {
                            var bullet = PoolSignalable.Instance.onListRemove?.Invoke(PoolType.BulletTurret);
                            BulletController bulletController = bullet.GetComponent<BulletController>();
                            Rigidbody bulletRigidbody = bulletController.SetRigidbody();
                            bulletController.ZeroVelocty();
                            bulletController.transform.gameObject.SetActive(true);
                            bulletController.transform.position = barrel.transform.position;
                            bulletRigidbody.AddForce(barrel.transform.forward * 20,ForceMode.VelocityChange);
                            _ammoCount++;
                            if (_ammoCount > 3)
                            {
                                Ammo[Ammo.Count - 1].transform.DOKill();
                                PoolSignalable.Instance.onListAdd?.Invoke(Ammo[Ammo.Count -1],PoolType.AmmoPackage);
                                Ammo.Remove(Ammo[Ammo.Count - 1]);
                                _ammoCount = 0;
                                if (_plusX > -1)
                                {
                                    _plusX -= 2;
                                }
                                else
                                {
                                    _plusX = 1;
                                    if (_plusY < 1)
                                    {
                                        _plusY += 2;
                                    }
                                    else
                                    {
                                        _plusX = 1;
                                        _plusY = -1;
                                        _plusZ += .5f;
                                    }
                                }
                                
                            }
                            _timer = Timer;
                        }
                        _timer -= UnityEngine.Time.deltaTime;
                    }
                }
            }
        }
        
        private void Target()
        {
            if (turretOperator.activeSelf)
            {
                if (Enemys.Count > 0)
                {
                    turret.transform.LookAt(Enemys[0].transform);
                }
            }
        }
    }
}