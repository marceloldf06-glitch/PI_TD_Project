using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class Menus
{
    public GameObject upgradeUI;
    public Button upgradeBTN;
    public GameObject CompraUI;
    public TextMeshProUGUI upgradeTXT;

    public Menus(GameObject _upgradeUI, Button _upgradeBTN, GameObject _CompraUI, TextMeshProUGUI _upgradeTXT)
    {
        upgradeUI = _upgradeUI;
        upgradeBTN = _upgradeBTN;
        CompraUI = _CompraUI;
        upgradeTXT = _upgradeTXT; 
    }
}
