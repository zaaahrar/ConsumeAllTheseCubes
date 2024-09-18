using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ImprovementView : MonoBehaviour
{
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _purchaseButton;

    public event Action OnButtonClicked;

    private void OnEnable() => _purchaseButton.onClick.AddListener(ClickButton);

    private void OnDisable() => _purchaseButton.onClick.RemoveListener(ClickButton);

    private void ClickButton() => OnButtonClicked?.Invoke();

    public void UpdateUI(int level, int maxLevel, int price)
    {
        _level.text = $"{level}/{maxLevel}";
        _price.text = price.ToString();

        if(level == maxLevel)
            _purchaseButton.interactable = false;
    }
}
