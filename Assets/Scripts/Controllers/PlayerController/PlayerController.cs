using System;
using System.Collections.Generic;
using DG.Tweening;
using Enums;
using Signalable;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> HostageList;

        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject playerPhysics;
        [SerializeField] private PlayerStackController playerStackController;
        [SerializeField] private GameObject player;
        [SerializeField] private PlayerMovementController playerMovementController;
        [SerializeField] private PlayerAnimatorController playerAnimatorController;

        #endregion

        #region Private Variables

        private int _healt;
        private Transform _playerSpawn;
        private bool _safeHouse;

        #endregion

        #endregion

        public void GetHealt(int Healt)
        {
            _healt = Healt;
        }

        public void SafeHouse(bool safehouse)
        {
            _safeHouse = safehouse;
        }

        public bool ReturnSafeHose()
        {
            return _safeHouse;
        }

        public GameObject LastHostage(GameObject Hostage)
        {
            GameObject hostage;
            if (HostageList.Count == 0)
            {
                HostageList.Add(Hostage);
                hostage = transform.gameObject;
            }
            else
            {
                hostage = HostageList[HostageList.Count - 1];
                HostageList.Add(Hostage);
            }

            return hostage;
        }

        public void TurretHold(bool hold, GameObject turret)
        {
            playerMovementController.TurretHold(hold);
            playerAnimatorController.TurretHold(hold);
            if (hold)
            {
                transform.LookAt(turret.transform);
            }
        }
        
        private void Start()
        {
            _playerSpawn = transform;
        }
        
        public void HealtDamage(int damage)
        {
            _healt -= damage;
            if (_healt <= 0)
            {
                playerPhysics.SetActive(false);
                transform.tag = "Dead";
                playerStackController.ResetList();
                PlayerSignals.Instance.onMoneyReset?.Invoke();
                playerAnimatorController.Dead(true);
                DOVirtual.DelayedCall(1.30f, () => PlayerReset()).OnComplete(() =>
                {
                    playerPhysics.SetActive(true);
                    transform.tag = "Player";
                    playerMovementController.DeadPlayer();
                    playerAnimatorController.Dead(false);
                    HostageDefaultSignalable.Instance.Reset?.Invoke();
                    ResetHostageList();
                });
                _healt = 100;
            }
        }

        public void ChangeHostage()
        {
            int count = HostageList.Count;
            for (int i = 0; i < count; i++)
            {
                var position = HostageList[0].transform.position;
                PoolSignalable.Instance.onListAdd?.Invoke(HostageList[0],PoolType.HostageDefault);
                HostageList.Remove(HostageList[0]);
                var minner = PoolSignalable.Instance.onListRemove?.Invoke(PoolType.HostageMinner);
                minner.transform.position = position;
            }
        }

        public void ResetHostageList()
        {
            HostageList.Clear();
            HostageList.TrimExcess();
        }

        public void PlayerReset()
        {
            player.transform.position = new Vector3(0,0,-3);
            player.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}