using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "FPS/Weapon")]
public class WeaponData : ScriptableObject
{
    public int id = 0;
    public float fireRate = 1.0f;
    public float bulletSpeed = 10f;
    public Mesh weaponMesh;
    public Material weaponMaterial;
    public GameObject bulletPrefab;
}