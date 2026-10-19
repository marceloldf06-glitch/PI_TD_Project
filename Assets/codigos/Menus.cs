using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class Menus
{
    public GameObject upgradeUI;
    public Button upgradeBTN;
    public TextMeshProUGUI upgradeTXT;
    public TextMeshProUGUI statuspanel;
    public TextMeshProUGUI nome;
    public Button vender;
    public Image imagem;

    public Menus(GameObject _upgradeUI, Button _upgradeBTN, GameObject _CompraUI, TextMeshProUGUI _upgradeTXT, TextMeshProUGUI _compraTXT,TextMeshProUGUI _statuspanel, TextMeshProUGUI _nome, Button _vender, Sprite _imagen)
    {
        upgradeUI = _upgradeUI;
        upgradeBTN = _upgradeBTN;
        upgradeTXT = _upgradeTXT;
        statuspanel = _statuspanel;
        nome = _nome;
        vender = _vender;
        imagem = _imagen;

    }
}
