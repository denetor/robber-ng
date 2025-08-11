using UnityEngine;
using UnityEngine.Events;

public class BreathSystem : MonoBehaviour
{
    [SerializeField, Tooltip("Owner of this system")] private Rigidbody2D rb;
    [SerializeField, Tooltip("Max breath points")] private float maxBreath = 100f;
    [SerializeField, Tooltip("Current breath points")] private float breath;

    // evento emesso quando i valori cambiano <actor, amount, currentBreath, maxBreath>
    // this event is used to update the UI or trigger other effects when value changes
    // it can be used to display status bars, play sound effects, etc.
    [SerializeField, Tooltip("Event emitted when amount changes")]
    UnityEvent<Rigidbody2D, float, float, float> breathChangedEvent;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxBreath = 100f;
        breath = maxBreath;
    }


    // Update is called once per frame
    void Update()
    {
        if (breath <= 0)
        {
            // TODO Handle breath depletion, e.g., trigger a warning or disable actions
            Debug.LogWarning("Breath depleted!");
        }
    }


    /**
    * Change the breath amount of the actor
    * @param breath amount of damage to apply
    */
    public void Change(float amount)
    {
        breath += amount;
        if (breath > maxBreath)
        {
            breath = maxBreath;
        }
        breathChangedEvent.Invoke(rb, amount, breath, maxBreath);
        Debug.Log($"Breath changed: {amount}, Current: {breath}, Max: {maxBreath}");
    }
}
