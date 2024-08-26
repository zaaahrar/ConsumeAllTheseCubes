using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct SpawnCubeConfig
{
    public List<Vector3> Position;
    public List<string> Color;
}
