using System;
using Unity.Netcode;
using UnityEngine;

public class NetworkInput : NetworkBehaviour
{
    protected NetworkVariable<Vector2> MoveDirection = new NetworkVariable<Vector2>(Vector2.zero, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);


    public Action<Vector2> OnChangeMoveDirection;
    public Action OnGrablingUse;
        

    #region PUBLIC
    public void Initialize(Action<Vector2> onChangeMoveDirection, Action onGrablingUse)
    {
        OnChangeMoveDirection += onChangeMoveDirection;
        OnGrablingUse += onGrablingUse;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        MoveDirection.OnValueChanged += ChangeMoveDirection;
    }
    #endregion

    #region PRIVATE

    //использовать надо каую-то систему ввода, это тоже плохо так оставлять
    private void Update()
    {
        if (IsOwner == false || IsClient == false)
            return;

        MoveDirection.Value = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space))
            OnGrablingUseServerRpc();
    }

    [ServerRpc]
    private void OnGrablingUseServerRpc()
    {
        OnGrablingUse?.Invoke();
    }

    private void ChangeMoveDirection(Vector2 oldDirection, Vector2 newDirection)
    {
        if (IsClient)
            return;
        OnChangeMoveDirection?.Invoke(newDirection);
    }
    #endregion
}
