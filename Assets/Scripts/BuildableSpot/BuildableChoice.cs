using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuildableChoice : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private TextMeshProUGUI _textObject;

    private GameObject _parent;
    private Tower _tower;
    private Action<Tower> _onClick;

    [Inject]
    public void Construct(GameObject gameObject, Tower tower, Action<Tower> onClick)
    {
        _parent = gameObject;
        _tower = tower;
        _onClick = onClick;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(_parent.transform);
        _image.sprite = _tower.Icon;
        _textObject.text = $"{_tower.Price.ToString()}G";
    }

    private void OnMouseDown()
    {
        _onClick(_tower);
    }

    public class Factory : PlaceholderFactory<GameObject, Tower, Action<Tower>, BuildableChoice> { }
}
