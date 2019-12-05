using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] Text _inventoryNumber = null;
    [SerializeField] Shoot _inventory = null;
    [SerializeField] Receptacle _receptacle = null;
    [SerializeField] Image _inventoryImg = null;
    [SerializeField] Sprite _empty = null;
    [SerializeField] Text _moneyNumber = null;

    [SerializeField] int _startMoney;

    private float _currAlpha = 1;

    private void Start()
    {
        _inventoryNumber.text = "x " + _inventory.StartInven;
        _moneyNumber.text = "" + _startMoney;
    }

    private void Update()
    {
        if (_inventory.StartInven == 0)
        {
            _inventoryImg.sprite = _empty;
            _inventoryNumber.enabled = false;
        }
        else
        {
            _inventoryNumber.text = "x " + _inventory.StartInven;
        }

        _moneyNumber.text = "" + (_startMoney + _receptacle.MoneyAdd);
    }
}
