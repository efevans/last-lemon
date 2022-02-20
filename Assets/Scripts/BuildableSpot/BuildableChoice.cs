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
    private TowerSpecification _towerSpecification;
    private Action<TowerSpecification> _onClick;

    [Inject]
    public void Construct(GameObject gameObject, TowerSpecification tower, Action<TowerSpecification> onClick)
    {
        _parent = gameObject;
        _towerSpecification = tower;
        _onClick = onClick;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(_parent.transform);
        _image.sprite = _towerSpecification.Tower.Icon;
        _textObject.text = $"{_towerSpecification.Price}G";
    }

    private void OnMouseDown()
    {
        _onClick(_towerSpecification);
    }

    public class Factory : PlaceholderFactory<GameObject, TowerSpecification, Action<TowerSpecification>, BuildableChoice> { }
}
