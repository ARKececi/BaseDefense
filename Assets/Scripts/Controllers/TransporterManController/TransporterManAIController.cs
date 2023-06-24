using System.Collections.Generic;
using Controllers.HostagePickerController;
using UnityEngine;
using UnityEngine.AI;

namespace Controllers.TransporterManController
{
    public class TransporterManAIController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public List<GameObject> CollectedAmmoList;

        #endregion

        #region Serialized Variables
        
        [SerializeField] private HostagePickerAnimationController hostagePickerAnimationController;
        [SerializeField] private NavMeshAgent agent;

        #endregion

        #region Private Variables

        private Transform _target;
        private GameObject _home;

        #endregion

        #endregion
    }
}