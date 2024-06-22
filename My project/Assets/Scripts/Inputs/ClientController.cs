using UnityEngine;

[RequireComponent(typeof(Character))]
[RequireComponent(typeof(Grabling))]
[RequireComponent(typeof(NetworkInput))]
public class ClientController : MonoBehaviour
{
    #region PUBLIC

    #endregion

    #region PRIVATE
    private void Awake()
    {
        GetComponent<Character>().Initialize();
        GetComponent<NetworkInput>().Initialize(GetComponent<Character>().StateMachine.StateMachineData.SetNewMoveDirection, GetComponent<Grabling>().TakeOrDrop);
        
    }
    #endregion
}
