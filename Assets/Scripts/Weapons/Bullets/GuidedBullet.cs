using UnityEngine;

public class GuidedBullet : BulletBase
{
    public float rotationSpeed = 5f;

    private Vector3 target;
    private Camera camera;
    private Transform rayOrigin => camera?.transform;

    private void Awake()
    {
        base.Awake();
        camera = Camera.main;
    }
    void Start() => target = transform.forward * 20; //Give it an initial target to be in front.

    void Update()
    {
        base.Update();
        UpdateTargetDirection(); //update the target direction based on camera movement
        RotateMissile();// Rotate the missile towards the target direction

        rb.velocity = transform.forward * rb.velocity.magnitude; // Move the missile forward using Rigidbody velocity
    }

    void UpdateTargetDirection()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit))
            target = (hit.point - transform.position).normalized;
    }

    void RotateMissile()
    {
        Quaternion targetRotation = Quaternion.LookRotation(target); // Calculate the rotation to face the target direction
        rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime); // Smoothly rotate towards the target direction using Rigidbody rotation
    }
}
