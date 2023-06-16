using System;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerMovementController playerMovementController;
        [SerializeField] private PlayerAnimatorController playerAnimatorController;
        [SerializeField] private PlayerStackController playerStackController;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private GameObject arm;
        
        #endregion

        #region Private Variables

        private PlayerData _playerData;

        #endregion

        #endregion
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onInputDragged += playerMovementController.InputController;
            InputSignals.Instance.onInputDragged += playerAnimatorController.InputController;
            InputSignals.Instance.onInputReleased += playerMovementController.DeactiveMovement;
            InputSignals.Instance.onInputTaken += playerMovementController.EnableMovement;
            EnemySignals.Instance.onEnemyTarget += OnPlayer;
            PlayerSignals.Instance.onSafeHouse += playerStackController.RemoveMoney;
            WeaponSignals.Instance.onArm += OnArm;
            WeaponSignals.Instance.onWeaponAnimation += playerAnimatorController.PistolIdleBool;
            WeaponSignals.Instance.onEnemyTrigger += OnEnemyTrigger;
            EnemySignals.Instance.onEnemyRemove += playerMovementController.RemoveEnemy;
            EnemySignals.Instance.onEnemyList += playerMovementController.EnemyList;
            EnemySignals.Instance.onContains += playerStackController.OnContain;
            PlayerSignals.Instance.onListCount += OnListCount;
            PlayerSignals.Instance.onLastHostage += OnLastHostage;
            AmmoBoxSignals.Instance.onAddAmmo += OnAddAmmo;
            TurretSignals.Instance.onRemoveAmmo += OnRemoveAmmo;
            EnemySignals.Instance.onReturnSafeHouse += OnReturnSafeHouse;
            TurretSignals.Instance.onTurretHold += OnTurretHold;
        }

        private void UnsubscribeEvents()
        {
            InputSignals.Instance.onInputDragged -= playerMovementController.InputController;
            InputSignals.Instance.onInputDragged -= playerAnimatorController.InputController;
            InputSignals.Instance.onInputReleased -= playerMovementController.DeactiveMovement;
            InputSignals.Instance.onInputTaken -= playerMovementController.EnableMovement;
            EnemySignals.Instance.onEnemyTarget -= OnPlayer;
            PlayerSignals.Instance.onSafeHouse -= playerStackController.RemoveMoney;
            WeaponSignals.Instance.onArm -= OnArm;
            WeaponSignals.Instance.onWeaponAnimation -= playerAnimatorController.PistolIdleBool;
            WeaponSignals.Instance.onEnemyTrigger -= OnEnemyTrigger;
            EnemySignals.Instance.onEnemyRemove -= playerMovementController.RemoveEnemy;
            EnemySignals.Instance.onEnemyList -= playerMovementController.EnemyList;
            EnemySignals.Instance.onContains -= playerStackController.OnContain;
            PlayerSignals.Instance.onListCount -= OnListCount;
            PlayerSignals.Instance.onLastHostage -= OnLastHostage;
            AmmoBoxSignals.Instance.onAddAmmo -= OnAddAmmo;
            TurretSignals.Instance.onRemoveAmmo -= OnRemoveAmmo;
            EnemySignals.Instance.onReturnSafeHouse -= OnReturnSafeHouse;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void Awake()
        {
            _playerData = GetPlayerData();
            
            playerMovementController.GetMoveSpeed(_playerData.MoveSpeed);
            playerController.GetHealt(_playerData.Healt);
        }
        
        private PlayerData GetPlayerData()
        {
            return Resources.Load<CD_Player>("Data/CD_Player").PlayerData;
        }
        
        private Transform OnPlayer()
        {
            return transform;
        }

        private GameObject OnArm()
        {
            return arm;
        }

        private bool OnEnemyTrigger()
        {
            return playerMovementController.EnemyTrigger;
        }

        private int OnListCount()
        {
            return playerStackController.ListCount();
        }

        private GameObject OnLastHostage(GameObject Hostage)
        {
            return playerController.LastHostage(Hostage);
        }

        private void OnAddAmmo(GameObject ammo)
        {
            playerStackController.AddAmmo(ammo);
        }

        private GameObject OnRemoveAmmo()
        {
            return playerStackController.RemoveAmmo();
        }

        private bool OnReturnSafeHouse()
        {
            return playerController.ReturnSafeHose();
        }

        private void OnTurretHold(bool hold, GameObject turret)
        {
            playerController.TurretHold(hold, turret);
        }
    }
}