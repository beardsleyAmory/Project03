using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] Text _inventoryNumber = null;
    [SerializeField] Shoot _inventory = null;
    [SerializeField] Image _inventoryImg = null;
    [SerializeField] Sprite _empty = null;

    private void Start()
    {
        _inventoryNumber.text = "x " + _inventory.StartInven;
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
    }
}
