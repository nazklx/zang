using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int totalHealth = 1;

    void OnTriggerEnter2D() {
        Debug.Log("Collision detected");
        totalHealth--;
    }

    void Update() {
        if (totalHealth <= 0 ) {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }
}
