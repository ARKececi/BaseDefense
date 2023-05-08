using System;
using DG.Tweening;
using Signals;
using UnityEngine;
using UnityEngine.UIElements;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameObject playerPhysics;
        [SerializeField] private StackController stackController;
        [SerializeField] private GameObject player;
        [SerializeField] private PlayerMovementController playerMovementController;

        #endregion

        #region Private Variables

        private int _healt;
        private Transform _playerSpawn;

        #endregion

        #endregion

        private void Start()
        {
            _healt = 100;
            _playerSpawn = transform;
            Debug.Log(_playerSpawn.position);
        }
        
        public void HealtDamage(int damage)
        {
            _healt -= damage;
            if (_healt <= 0)
            {
                playerPhysics.SetActive(false);
                playerMovementController.DeadPlayer();
                stackController.ThrowMoney();
                DOVirtual.DelayedCall(1, () => PlayerReset()).OnComplete(() =>
                {
                    playerPhysics.SetActive(true);
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