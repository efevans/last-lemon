using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradeChoice : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    private Upgrade _upgrade;
    private Action<Upgrade> _onClick;

    public void Setup(Upgrade upgrade, Action<Upgrade> onClick)
    {
        _upgrade = upgrade;
        _onClick = onClick;
        _image.sprite = _upgrade.Icon;
    }

    private void OnMouseDown()
    {
        _onClick(_upgrade);
    }
}
