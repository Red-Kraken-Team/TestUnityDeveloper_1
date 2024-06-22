using UnityEngine;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    public StateMachineData Data { get; private set; }

    private readonly Character _character;

    private CharacterController CharacterController => _character.CharacterController;
     
    protected MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    protected bool IsDirectionZero() => Data.MoveDirection == Vector2.zero;

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
        Vector3 velocity = new Vector3(Data.Velocity.x, 0, Data.Velocity.y);
        CharacterController.Move(velocity * Time.deltaTime);

        if(IsDirectionZero())
            return;

        _character.transform.forward = velocity.normalized;
    }

}
