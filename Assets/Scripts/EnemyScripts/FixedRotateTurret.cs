using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotateTurret : MonoBehaviour
{
    public float rotationSpeedDeg = 90f;
    private GameObject player;
    private float topRotationSpeedDeg = 90f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rotateTurretAtFixedRate();
    }


    void rotateTurretAtFixedRate()
    {
        float turretCurrentRotationZ = transform.eulerAngles.z;
        float newAngle = Mathf.MoveTowardsAngle(turretCurrentRotationZ, turretCurrentRotationZ + rotationSpeedDeg, topRotationSpeedDeg * Time.deltaTime);
        transform.rotation = Quaternion.Euler( 0, 0, newAngle );
    }
}
