using UnityEngine;
using System;

public class StateMachineData
{
    private Vector2 _moveDirection;
    private float _speed;

    public Vector2 MoveDirection
    {
        get { return _moveDirection; }
        private set {  }
    }

    public Vector2 Velocity => MoveDirection * Speed;

    public float Speed
    {
        get => _speed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));
            _speed = value;
        }
    }

    //для управления через клиента на сервере, иначе это был бы простой инпут с другими обработками
    public void SetNewMoveDirection(Vector2 direction) => _moveDirection = direction.normalized;    

    
    #region PUBLIC
	
    #endregion

    #region PRIVATE
	
    #endregion
}
