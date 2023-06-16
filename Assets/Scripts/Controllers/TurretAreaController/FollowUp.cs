using System;
using UnityEngine;

namespace Controllers.TurretAreaController
{
    public class FollowUp : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameObject camera;

        #endregion

        #endregion

        private void FixedUpdate()
        {
            transform.LookAt(camera.transform);
        }
    }
}