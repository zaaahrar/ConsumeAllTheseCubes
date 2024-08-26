using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeChecker : MonoBehaviour
{
    [SerializeField] private List<Cube> _collectedCubesList;
    [SerializeField] private List<string> _cubesColorList;
    [SerializeField] private CubeCounter _cubeCounter;

    private void Start() => SaveCubeData(null);

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Cube cube))
        {
            _collectedCubesList.Add(cube);
            _cubesColorList.Add(cube.GetColor());
            _cubeCounter.AddCube();
            cube.CollectCube();
            SaveCubeData(_cubesColorList);
            cube.gameObject.SetActive(false);
        }
    }

    private void SaveCubeData(List<string> cubesColorList)
    {
        CubeListDTO cubeDTO = new CubeListDTO();
        cubeDTO.Colors = cubesColorList;
        string json = JsonUtility.ToJson(cubeDTO);
        PlayerPrefs.SetString("CubeData", json);
    }
}
