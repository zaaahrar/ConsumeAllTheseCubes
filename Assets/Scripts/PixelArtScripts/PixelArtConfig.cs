using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PixelArtConfig
{
    public List<Vector3> SpawnPointsPixels;
    public List<Vector3> SpawnPointsEdging;
    public List<string> ColorPixels;
}
