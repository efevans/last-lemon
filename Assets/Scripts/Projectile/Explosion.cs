using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Explosion : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

    [Inject]
    public void Construct(Vector2 position)
    {
        transform.position = position;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("explosion created");
        ParticleSystem.Play();
        StartCoroutine(DieIn(1));
    }

    private IEnumerator DieIn(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        Destroy(gameObject);
    }

    public class Factory : PlaceholderFactory<Vector2, Explosion> { }
}
