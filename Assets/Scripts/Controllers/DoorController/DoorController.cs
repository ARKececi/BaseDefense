using DG.Tweening;
using UnityEngine;

namespace Controllers.DoorController
{
    public class DoorController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameObject pivot;

        #endregion

        #endregion

        public void OpenDoor()
        {
            transform.DOKill();
            pivot.transform.DOLocalRotate(new Vector3(0, 0, 90), 1);
        }

        public void CloseDoor()
        {
            transform.DOKill();
            pivot.transform.DOLocalRotate(new Vector3(0, 0, 0), 1);
        }
    }
}