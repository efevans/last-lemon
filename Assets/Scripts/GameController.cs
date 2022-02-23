using Assets.Scripts.Spawner;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

public class GameController : IInitializable
{
    private readonly Grid _grid;
    private readonly Spawner _spawner;

    public GameController(Grid grid, Spawner spawner)
    {
        _grid = grid;
        _spawner = spawner;
    }

    public void Initialize()
    {
    }
}
