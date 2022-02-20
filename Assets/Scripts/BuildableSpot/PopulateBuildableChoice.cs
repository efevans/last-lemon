using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PopulateBuildableChoice : MonoBehaviour, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    private TowersManager _towersManager;
    private BuildableChoice.Factory _buildableChoiceFactory;

    private readonly List<BuildableChoice> Choices = new List<BuildableChoice>();

    private bool _justSelected;
    private bool _mouseIsOver;
    private Action<TowerSpecification> _onSelectTower;

    [Inject]
    public void Construct(TowersManager towersManager, BuildableChoice.Factory factory)
    {
        _towersManager = towersManager;
        _buildableChoiceFactory = factory;
    }

    public void Setup(Action<TowerSpecification> onSelectTower)
    {
        _onSelectTower = onSelectTower;
        _justSelected = true;
        gameObject.SetActive(true);
        ExpandSelection();
    }

    private void Update()
    {
        if (_justSelected)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
            _justSelected = false;
        }
    }

    private void ExpandSelection()
    {
        ClearChoices();
        foreach (var tower in _towersManager.GetBuildableTowers())
        {
            var choice = _buildableChoiceFactory.Create(gameObject, tower, _onSelectTower);
            Choices.Add(choice);
        }
    }

    public void OnDeselect(BaseEventData _)
    {
        if (!_mouseIsOver)
        {
            Debug.Log("deselected");
            ClearChoices();
            gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData _)
    {
        _mouseIsOver = true;
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void OnPointerExit(PointerEventData _)
    {
        _mouseIsOver = false;
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    private void ClearChoices()
    {
        foreach (var choice in Choices)
        {
            Destroy(choice.gameObject);
        }

        Choices.Clear();
    }
}
