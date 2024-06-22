using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WalkingConfig
{
    #region PUBLIC
	[field: SerializeField, Range(0, 10)] public float Speed { get; private set; }
    #endregion

    #region PRIVATE
	
    #endregion
}
