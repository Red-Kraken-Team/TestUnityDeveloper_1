using UnityEngine;

public class Grabling : MonoBehaviour
{
    [SerializeField] private CharacterConfig _characterConfig;

    [SerializeField] private Transform _grabPoint;

    private Transform _pickedItem;

    private bool IsTaken => _pickedItem != null;

    private Vector3 LocalPositionForPickedItem => Vector3.zero;
    private Vector3 LocalRotationForPickedItem => Vector3.zero;

    #region PUBLIC
    public void TakeOrDrop()
    {
        if (IsTaken)
            Drop();
        else
            if (TryTargetToRaycastHit(out Transform target))
                Take(target);
    }
    #endregion

    #region PRIVATE
    private void Take(Transform target)
    {
        _pickedItem = target;
        _pickedItem.SetParent(_grabPoint);

        DisablePhysics();

        _pickedItem.localPosition = LocalPositionForPickedItem;
        _pickedItem.localEulerAngles = LocalRotationForPickedItem;
    }

    private void Drop()
    {
        if (IsTaken == false)
            return;

        EnablePhysics();

        _pickedItem.SetParent(null);
        _pickedItem = null;
    }

    private bool TryTargetToRaycastHit(out Transform target)
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _characterConfig.GrablingConfig.GrablingDistance, _characterConfig.GrablingConfig.TakebaleLayer))
        {
            target = hit.collider.transform;
            return true;
        }

        target = null;
        return false;
    }

    private void DisablePhysics()
    {
        if (_pickedItem.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.isKinematic = true;
    }

    private void EnablePhysics()
    {
        if (_pickedItem.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.isKinematic = false;
    }
    #endregion
}
