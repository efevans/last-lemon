using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradePicker : MonoBehaviour
{
    private SignalBus _signalBus;

    [SerializeField]
    private UpgradeChoice _left;
    [SerializeField]
    private UpgradeChoice _middle;
    [SerializeField]
    private UpgradeChoice _right;

    private UpgradesManager _upgradesManager;

    private int _upgradeProgress = 0;

    [Inject]
    public void Construct(SignalBus signalBus, UpgradesManager upgradesManager)
    {
        _signalBus = signalBus;
        _upgradesManager = upgradesManager;
        _signalBus.Subscribe<ISignalUpgradeProgress>(OnUpgradeProgressSignaled);
    }

    private void OnUpgradeProgressSignaled(ISignalUpgradeProgress _)
    {
        _upgradeProgress += 1;

        if (_upgradeProgress >= 7)
        {
            _upgradeProgress = 0;
            gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
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
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
