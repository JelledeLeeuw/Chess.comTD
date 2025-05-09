using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    private DataManager _dataManager;

    private void Start()
    {

        
        _dataManager = DataManager.GetInstance();
        _dataManager.Money = 150;
    }

    private void Update()
    {
        _moneyText.text = _dataManager.Money.ToString();
    }
}
