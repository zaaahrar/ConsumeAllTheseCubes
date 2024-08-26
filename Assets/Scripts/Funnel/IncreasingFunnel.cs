using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class IncreasingFunnel : MonoBehaviour
{
    [SerializeField] private float _numberCubes;
    [SerializeField] private float _durationIncrease;
    [SerializeField] private float _additionsScale;
    [SerializeField] private float _cameraIndentation;
    [SerializeField] private float _multiplicationNumber = 2;
    [SerializeField] private bool _isAssembled = false;
    [SerializeField] private Camera _mainCamera;

    public event Action<float> IncreasingSliderUpdateEvent;

    private float _collectCubes;

    public bool IsAssembled => _isAssembled;
    public float NumberCubes => _numberCubes;
    public float CollectCubes => _collectCubes;

    public void CollectCube()
    {
        _collectCubes++;
        CheckIncreasing();
        IncreasingSliderUpdateEvent?.Invoke(_collectCubes);
    }

    public void MakeNotAssemled() => _isAssembled = false;

    private void CheckIncreasing()
    {
        if(_collectCubes == _numberCubes)
        {
            _collectCubes = 0;
            _isAssembled = true;
            _numberCubes *= _multiplicationNumber;
            StartCoroutine(Increase());
        }
    }

    IEnumerator Increase()
    {
        float timer = 0f;
        Vector3 initialScale = transform.localScale;
        float startCameraDistanceY = _mainCamera.transform.position.y;
        float endCameraDistanceY = startCameraDistanceY * _cameraIndentation;
       // float startCameraDistanceZ = _mainCamera.transform.position.z;
        //float endCameraDistanceZ = startCameraDistanceZ * _cameraIndentation;
        Vector3 targetScale = new Vector3(transform.localScale.x * _additionsScale, transform.localScale.y, transform.localScale.z * _additionsScale);

        while (timer < _durationIncrease)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, timer / _durationIncrease);

            _mainCamera.transform.position = new Vector3(_mainCamera.transform.position.x, 
            Mathf.Lerp(startCameraDistanceY, endCameraDistanceY, timer / _durationIncrease), _mainCamera.transform.position.z);

            timer += Time.deltaTime;
            yield return null;
        }
    }
}
