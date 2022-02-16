using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUpgradeBtn : MonoBehaviour
{
    public GameObject UpgradeSelection;

    private void OnMouseDown()
    {
        UpgradeSelection.SetActive(true);
    }
}
