using System;
using Cinemachine;
using Signals;
using UnityEngine;

namespace Managers
{
    public class CameraManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private CinemachineStateDrivenCamera vmStateCamera;

        [SerializeField] private Animator animator;

        #endregion

        #region Private Variables

        private Enums.CameraState _cameraState;

        private Transform _player;

        #endregion

        #endregion
        
        private void OnPlayEnter()
        {
            switch (_cameraState)
            {
                case Enums.CameraState.Main:
                    _cameraState = Enums.CameraState.Main; 
                    animator.SetTrigger(_cameraState.ToString());
                    break;
            }
            
        }
        
        private void OnSetCamera()
        {
            _player = EnemySignals.Instance.onEnemyTarget?.Invoke();
            vmStateCamera.Follow = _player;
        }

        private void Start()
        {
            OnSetCamera();
        }
    }
}