using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OverlayInstructions : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    private Coroutine FadeCoroutine;

    private string _gameOverText = "GAME OVER"
        + Environment.NewLine
        + Environment.NewLine
        + "Space to Restart";

    public void Hide()
    {
        if (FadeCoroutine != null)
        {
            StopCoroutine(FadeCoroutine);
        }

        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0);
    }

    public void FadeIn()
    {
        _text.text = _gameOverText;
        FadeCoroutine = StartCoroutine(FadeTextToFullAlpha(1f));
    }

    private IEnumerator FadeTextToFullAlpha(float t)
    {
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0);
        while (_text.color.a < 1.0f)
        {
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _text.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
}
