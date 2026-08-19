using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Menus
{
    public GameObject upgradeUI;
    public Button upgradeBTN;
    public GameObject CompraUI;

    public Menus(GameObject _upgradeUI, Button _upgradeBTN, GameObject _CompraUI)
    {
        upgradeUI = _upgradeUI;
        upgradeBTN = _upgradeBTN;
        CompraUI = _CompraUI;
    }
}
