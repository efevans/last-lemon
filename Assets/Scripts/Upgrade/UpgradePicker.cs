using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradePicker : MonoBehaviour
{
    [SerializeField]
    private UpgradeChoice _left;
    [SerializeField]
    private UpgradeChoice _middle;
    [SerializeField]
    private UpgradeChoice _right;

    private UpgradesManager _upgradesManager;

    [Inject]
    public void Construct(UpgradesManager upgradesManager)
    {
        _upgradesManager = upgradesManager;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupChoices();
    }

    private void SetupChoices()
    {
        List<Upgrade> upgrades = _upgradesManager.GetThreeRandomUpgrades();

        _left.Setup(upgrades[0], OnSelectUpgrade);
        _middle.Setup(upgrades[1], OnSelectUpgrade);
        _right.Setup(upgrades[2], OnSelectUpgrade);
    }

    private void OnSelectUpgrade(Upgrade upgrade)
    {
        _upgradesManager.AcquireUpgrade(upgrade);
        gameObject.SetActive(false);
    }
}
