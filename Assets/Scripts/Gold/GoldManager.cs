using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class GoldManager : MonoBehaviour
{
    private SignalBus _signalBus;
    private Settings _mySettings;

    public int Gold { get; private set; }

    [SerializeField]
    private TextMeshProUGUI _textObject;

    [Inject]
    public void Construct(SignalBus signalBus, Settings settings)
    {
        _mySettings = settings;
        _signalBus = signalBus;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetToStartingGold();
        _signalBus.Subscribe<ISignalGoldManager>(OnGoldManagerSignaled);
    }

    public void ResetToStartingGold()
    {
        Gold = _mySettings.StartingGold;
        UpdateGoldDisplay(Gold);
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<ISignalGoldManager>(OnGoldManagerSignaled);
    }

    private void OnGoldManagerSignaled(ISignalGoldManager signal)
    {
        Gold++;
        UpdateGoldDisplay(Gold);
    }

    public void SpendGold(int count)
    {
        Gold -= count;
        UpdateGoldDisplay(Gold);
    }

    private void UpdateGoldDisplay(int gold)
    {
        _textObject.text = $"{gold}G";
    }

    [Serializable]
    public class Settings
    {
        public int StartingGold;
    }
}
