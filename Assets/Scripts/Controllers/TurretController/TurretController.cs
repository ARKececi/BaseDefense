using System;
using System.Collections.Generic;
using Controllers.TurretAreaController;
using DG.Tweening;
using Enums;
using Keys;
using Signalable;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;

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
        [SerializeField] private GameObject ammoDot;
        [SerializeField] private GameObject playerDot;
        [SerializeField] private UIBuyOperatorController uıBuyOperatorController;
        [SerializeField] private GameObject operatorPiece;
        [SerializeField] private GameObject levelPiece;

        #endregion

        #region Private Variables

        private float _timer;
        private float _plusX;
        private float _plusY;
        private float _plusZ;
        private int _ammoCount;
        private Vector3 _rotateInput;
        private bool _turretHold;
        private GameObject _player;

        #endregion

        #endregion

        private void Start()
        {
            uıBuyOperatorController.OnPrice(Price);
            _plusX = -1;
            _plusY = 1;
            _plusZ = 0;
        }
        
        public void InputController( InputParams inputParams)
        {
            _rotateInput = inputParams.MoveValues;
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
                ammo.transform.SetParent(ammoDot.transform);
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
            TurretClose();
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

        public void OperatorPlayer(GameObject player)
        {
            if (turretOperator.activeSelf != true)
            {
                player.transform.SetParent(operatorPiece.transform);
                player.transform.position = playerDot.transform.position;
                TurretSignals.Instance.onTurretHold?.Invoke(true, transform.gameObject);
                _player = player;
                _turretHold = true;
            }
        }

        private void Fire()
        {
            if (turretOperator.activeSelf || _turretHold)
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

        private void TurretClose()
        {
            if (_turretHold)
            {
                if (_rotateInput.z < -.4f)
                {
                    _turretHold = false;
                    TurretSignals.Instance.onTurretHold?.Invoke(false, transform.gameObject);
                    _player.transform.SetParent(levelPiece.transform);
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
            else if (_turretHold)
            {
                turret.transform.eulerAngles = new Vector3(0, _rotateInput.x * 45, 0);
            }
        }
    }
}