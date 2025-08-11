using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField, Tooltip("Owner of this system")] private Rigidbody2D rb;
    [SerializeField, Tooltip("Max health points")] private float maxHp = 100f;
    [SerializeField, Tooltip("Health points")] private float hp;
    // evento emesso quando gli hp cambiano <actor, damage, currentHp, maxHp>
    // this event is used to update the UI or trigger other effects when health changes
    // it can be used to display health bars, play sound effects, etc.
    [SerializeField, Tooltip("Event emitted when health changes")]
    UnityEvent<Rigidbody2D, float, float, float> hpChangedEvent;
    // evento da emesso quando l'attore muore <actor>
    // this event is used to notify other systems that the actor has died
    // it can be used to trigger death animations, remove the actor from the scene, etc
    [SerializeField, Tooltip("Event emitted when the actor dies")]
    UnityEvent<Rigidbody2D> deathEvent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxHp = 100f;
        hp = maxHp;
    }


    // Update is called once per frame
    void Update()
    {
        // Check if the actor is dead
        if (hp <= 0)
        {
            // Emit death event
            deathEvent.Invoke(rb);
            // Optionally, destroy the actor or disable it
            Destroy(gameObject);
        }
    }


    /**
    * Change the health points of the actor
    * @param damage amount of damage to apply
    */
    void ChangeHp(float damage)
    {
        hp -= damage;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        hpChangedEvent.Invoke(rb, damage, hp, maxHp);
    }
}
