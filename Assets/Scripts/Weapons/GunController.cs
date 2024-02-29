using UnityEngine;

public class GunController : MonoBehaviour
{
    public WeaponData currentWeaponData;

    public Transform gunMuzzle;
    private float nextFireTime = 0f;

    void Start()
    {
        SimpleFPSController.InteractWeaponEvent += EquipWeapon;
        EquipWeapon(currentWeaponData);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
            Shoot(); // Fire the equipped weapon
    }

    void EquipWeapon(WeaponData newWeapon)
    {
        if (newWeapon != null)
        {
            currentWeaponData = newWeapon;
            this.GetComponent<MeshFilter>().mesh = currentWeaponData.weaponMesh;
            this.GetComponent<MeshRenderer>().material = currentWeaponData.weaponMaterial;
        }
    }

    void Shoot()
    {
        // Check if enough time has passed since the last shot
        if (Time.time >= nextFireTime)
        {
            var bullet = ObjectPoolManager.Instance.GetObjectFromPool(currentWeaponData.id, gunMuzzle.position, gunMuzzle.rotation); // Get bullet from pool.
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * currentWeaponData.bulletSpeed;
            nextFireTime = Time.time + 1f / currentWeaponData.fireRate;                                                              // Update the next allowed firing time based on fire rate.
        }
    }
}

