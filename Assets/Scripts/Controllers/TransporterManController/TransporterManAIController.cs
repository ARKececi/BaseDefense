using System;
using System.Collections.Generic;
using Controllers.HostagePickerController;
using Signals;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Controllers.TransporterManController
{
    public class TransporterManAIController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables
        
        public List<GameObject> _turretList;

        #endregion

        #region Serialized Variables
        
        [SerializeField] private NavMeshAgent agent;

        #endregion

        #region Private Variables

        private GameObject _target;
        private GameObject _ammoBox;
        private int _rand;

        #endregion

        #endregion

        private void Update()
        {
            agent.destination = _target.transform.position;
        }

        private void Start()
        {
            _ammoBox = AmmoBoxSignalable.Instance.onPlace?.Invoke();
            TargetDefinition(_ammoBox);
        }

        public void TargetDefinition(GameObject target)
        {
            _target = target;
        }

        public void TargetBox()
        {
            TargetDefinition(_ammoBox);
        }

        public void TargetMy()
        {
            TargetDefinition(gameObject);
        }

        public void AddTurretList(GameObject turret)
        {
            _turretList.Add(turret);
            _turretList.TrimExcess();
        }

        public void RemoveTurretList(GameObject turret)
        {
            _turretList.Remove(turret);
            _turretList.TrimExcess();;
        }

        public void Target()
        {
            if (_turretList.Count > 0)
            {
                _target = _turretList[0];
            }
            else
            {
                TargetMy();
            }
            
        }
    }
}