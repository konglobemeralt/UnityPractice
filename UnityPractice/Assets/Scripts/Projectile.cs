using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    float damage = 1;
    float speed = 10;
    public LayerMask collisionMask;

    public void SetSpeed(float newSpeed) {
        speed = newSpeed;
    }

	void Update () {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}

    void CheckCollisions(float moveDistance) {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide)) {
            OnHitObject(hit);
        }
    }


    void OnHitObject(RaycastHit hit) {
        IDamageable damagableObject = hit.collider.GetComponent<IDamageable>();
        if (damagableObject != null) {
            damagableObject.TakeHit(damage, hit);
        }
        GameObject.Destroy(gameObject);
    }
}
