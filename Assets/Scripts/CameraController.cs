using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public Transform player;
    private Vector3 offset = new Vector3(0f, 0f, -5f);
    private float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        Vector3 targetPosition = player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
