using UnityEngine;
using System.Collections;

public class PlayerControlledTurret : MonoBehaviour
{

    public GameObject weapon_prefab;
    public GameObject[] barrel_hardpoints;
    public float turret_rotation_speed = 3f;
    public float shot_speed;
    int barrel_index = 0;
    public Transform firePoint;  // Single firing point
    public float fireRate = 2f; // Number of shots per second
    private float nextFireTime = 0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Turret no longer aims at cursor, so the following code is removed
        // This code will keep firing forward from the current rotation of the turret

        if ((Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space)) && barrel_hardpoints != null && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;

            GameObject bullet = (GameObject)Instantiate(weapon_prefab, barrel_hardpoints[barrel_index].transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * shot_speed);
            bullet.GetComponent<Projectile>().firing_ship = transform.parent.gameObject;

            // Cycle sequentially through the barrels in the barrel_hardpoints array
            barrel_index++;
            if (barrel_index >= barrel_hardpoints.Length)
                barrel_index = 0;
        }
    }
}
