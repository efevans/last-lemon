using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Exit : MonoBehaviour
{
    private Action _onLossCallback;
    private bool _callbackMade = false;

    [Inject]
    public void Construct()
    {
        
    }

    public void SetOnLossCallback(Action callback)
    {
        _onLossCallback = callback;
    }

    public void ResetExit()
    {
        _callbackMade = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            if (!_callbackMade)
            {
                _onLossCallback.Invoke();
                _callbackMade = true;
            }
        }
    }
}
