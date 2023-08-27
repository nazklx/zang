using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject GreenLaser1;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimer <= 0) {
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * new Vector3(0, 0.8f, 0);
            Instantiate(GreenLaser1, transform.position + offset, transform.rotation);
        }
    }
}
