using UnityEngine;

public interface Iinteractable 
{
    public WeaponData GetWeaponData();
}

public class InteractableWeapon : MonoBehaviour, Iinteractable
{
    [SerializeField] private WeaponData weaponData;

    public WeaponData GetWeaponData() => weaponData;
}
