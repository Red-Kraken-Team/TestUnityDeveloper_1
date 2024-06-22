using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridConfig", menuName = "Configs/GridConfig")]
public class GridConfig : ScriptableObject
{
    [field: SerializeField, Min(1)] public int XLimits { get; private set; }
    [field: SerializeField, Min(1)] public int YLimits { get; private set; }

    [field: SerializeField, Min(1)] public float Step { get; private set; }

    #region PUBLIC
	
    #endregion

    #region PRIVATE
	
    #endregion
}
