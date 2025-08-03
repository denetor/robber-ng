using System;
using UnityEngine;
using UnityEngine.Events;

public class GoldKeyCollectController : MonoBehaviour, ICollectable
{
    public static UnityEvent GoldKeyCollectEvent;
    [SerializeField] private ParticleSystem collectEffectPrefab;

    void Start() {
        if (GoldKeyCollectEvent == null) {
            GoldKeyCollectEvent = new UnityEvent();
        }
    }

    public void Collect() {
        // publish event
        GoldKeyCollectEvent.Invoke();

        // particle effect
        ParticleSystem collectParticle;
        collectParticle = Instantiate(collectEffectPrefab, transform.position, Quaternion.identity);
        collectParticle.Play();

        // destroy this item
        Destroy(gameObject);
    }
}
