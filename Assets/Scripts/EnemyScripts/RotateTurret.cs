using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTurret : MonoBehaviour
{
    public float rotationSpeedDeg = 1f;
    private GameObject player;
    private float degOffset = -90f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        facePlayer();
    }

    void facePlayer()
    {
        Vector3 turretPosition = transform.position;
        Vector3 playerPosition = player.transform.position;
        float turretCurrentRotationZ = transform.eulerAngles.z;

        // Determining angle of rotation
        float turretTargetRotationDegrees = Mathf.Rad2Deg * Mathf.Atan2( ( turretPosition.y - playerPosition.y) , ( turretPosition.x - playerPosition.x) ) + degOffset;
        Debug.Log(turretTargetRotationDegrees);
        float newAngle = Mathf.MoveTowardsAngle(turretCurrentRotationZ, turretTargetRotationDegrees, rotationSpeedDeg * Time.deltaTime);
        Debug.Log(newAngle);
        transform.rotation = Quaternion.Euler( 0, 0, newAngle );
    }
}
