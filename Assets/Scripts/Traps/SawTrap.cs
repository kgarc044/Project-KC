using UnityEngine;
using System.Collections;

public class SawTrap: MonoBehaviour
{
    [Tooltip("Rotation in degrees per second. Negative values give clockwise rotation.")]
    [SerializeField] protected float rotationRate = 100.0f;

    new Rigidbody2D rigidbody;

    protected void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody.angularVelocity = rotationRate;
    }

}
