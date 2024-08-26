using UnityEngine;
using TMPro;
using DG.Tweening;

public class PopUpTextMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _indentedY;

    private void Start()
    {
        int rotateY = 180;
        transform.LookAt(Camera.main.transform.position);
        transform.Rotate(0, rotateY, 0);

        Transform transformObject = transform;
        Vector3 endPosition = transformObject.position;
        endPosition.y += _indentedY;

        transformObject.DOMove(endPosition, _lifeTime);
        Destroy(gameObject, _lifeTime);
    }

    public void UpdateText(int moneyReceived) => _moneyText.text = moneyReceived.ToString();
}
