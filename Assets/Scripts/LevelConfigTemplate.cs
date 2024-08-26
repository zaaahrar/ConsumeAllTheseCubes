using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LevelConfigTemplate
{
    [Header("LevelSettings")]
    public int LevelNumber;
    public int CountCubes;
    public List<Vector3> SpawnPoints;
    public List<string> Colors;
    public int Time;
    public bool IsPassed;

    [Header("PixelArtBuildingSettings")]
    public List<Vector3> SpawnPointsPixels;
    public List<Vector3> SpawnPointsEdging;
    public List<string> ColorPixels;
}
