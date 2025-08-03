using System;
using UnityEngine;
using UnityEngine.Events;

public class GemCollectController : MonoBehaviour, ICollectable
{
    public static UnityEvent GemCollectEvent;
    [SerializeField] private ParticleSystem collectEffectPrefab;
    

    void Start() {
        if (GemCollectEvent == null) {
            GemCollectEvent = new UnityEvent();
        }
    }

    public void Collect() {
        // publish event
        Debug.Log("Gem collected");
        GemCollectEvent.Invoke();

        // instantiate particle system
        ParticleSystem collectParticle;
        collectParticle = Instantiate(collectEffectPrefab, transform.position, Quaternion.identity);
        collectParticle.Play();

        // destroy this item
        Destroy(gameObject);
    }
}
