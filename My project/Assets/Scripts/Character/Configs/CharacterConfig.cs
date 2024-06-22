using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private WalkingConfig _walkingConfig;
    [SerializeField] private GrablingConfig _grablingConfig;

    public WalkingConfig WalkingConfig => _walkingConfig;
    public GrablingConfig GrablingConfig => _grablingConfig;

    #region PUBLIC
	
    #endregion

    #region PRIVATE
	
    #endregion
}
