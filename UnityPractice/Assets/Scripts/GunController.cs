using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public Gun startingGun;
    public Transform weaponHold;
    private Gun equippedGun;

    void Start() {
        if (startingGun != null) {
            EquipGun(startingGun);
                }
    }

    public void EquipGun(Gun gunToEquip) {
        if (equippedGun != null) {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
        equippedGun.transform.parent = weaponHold;

    }
} 
