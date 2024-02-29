using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public float disableTimer = 5f; // Set the timer duration in seconds

    private float timer;
    protected Rigidbody rb;

    protected void Awake()  => rb = GetComponent<Rigidbody>();
    private void OnEnable() => timer = disableTimer;

    protected void Update()
    {
        // Update the timer
        timer -= Time.deltaTime;

        // Check if the timer has run out
        if (timer <= 0f)
        {
            // Deactivate the GameObject when the timer runs out and stop velocity.
            gameObject.SetActive(false);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
