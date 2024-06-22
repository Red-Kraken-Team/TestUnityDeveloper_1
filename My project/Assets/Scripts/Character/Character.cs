using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig _characterConfig;

    public CharacterController CharacterController { get; private set; }

    public CharacterConfig CharacterConfig => _characterConfig;

    public CharacterStateMachine StateMachine { get; private set; }

    #region PUBLIC
    public void Initialize()
    {
        CharacterController = GetComponent<CharacterController>();
        StateMachine = new CharacterStateMachine(this);

    }


    #endregion

    #region PRIVATE
    //need using botstrap

    private void Update()
    {
        StateMachine.Update();
    }
    #endregion
}
