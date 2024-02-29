using UnityEngine;

public class MagnetBullet : BulletBase
{
    public float gravitationalForce = 5f;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("AttractableObject"))
        {
            Vector3 direction = transform.position - other.transform.position;
            other.GetComponent<Rigidbody>().AddForce(direction.normalized * gravitationalForce);
        }
    }
}
