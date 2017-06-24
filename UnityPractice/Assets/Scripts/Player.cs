using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GunController))]
[RequireComponent (typeof(PlayerControler))]
public class Player : MonoBehaviour {

    public float moveSpeed = 5;
    Camera viewCamera;
    PlayerControler controller;
    GunController gunController;

	void Start () {
        viewCamera = Camera.main;
        gunController = GetComponent<GunController>();
        controller = GetComponent<PlayerControler>();	
	}
	
	void Update () {
        // Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        // Look input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance)) {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point, Color.red);

            controller.LookAt(point);
        }

        // Weapon input
        if (Input.GetMouseButton(0)) {
            gunController.Shoot();
        }
	}
}
