using UnityEngine;
using System;

[Serializable]
public class GrablingConfig 
{
    [field: SerializeField, Min(0)] public float GrablingDistance { get; private set; }

    [field: SerializeField] public LayerMask TakebaleLayer { get; private set; }
    #region PUBLIC

    #endregion

    #region PRIVATE

    #endregion
}
