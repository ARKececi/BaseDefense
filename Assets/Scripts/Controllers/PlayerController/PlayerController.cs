using System;
using DG.Tweening;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        #region Self Variables

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

        #endregion

        #endregion

        public void GetHealt(int Healt)
        {
            _healt = Healt;
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
                });
                _healt = 100;
            }
        }

        public void PlayerReset()
        {
            player.transform.position = new Vector3(0,0,-3);
            player.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}