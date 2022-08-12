using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAndShoot : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject gun;
    public GameObject player;
    public PlayerMove playerScript;
    private Vector3 target;
    public bool followingCrosshair = false;

    void Start()
    {
        Cursor.visible = false;
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        //
    }

    void FixedUpdate()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        gun = playerScript.instantiatedGun;
        
        if(gun != null)
        {
            Vector3 difference = target - gun.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            gun.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            /*if(rotationZ <= 90)
            {
                gun.transform.rotation = Quaternion.Euler(0f, 0, rotationZ);
            }
            else if (rotationZ >= 270)
            {
                gun.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            }
            if (rotationZ > 90 && rotationZ < 270)
            {
                //player.transform.Rotate(0f, 180f, 0f);
                player.transform.Rotate(0f, 180f, 0f);
            }*/
        }
        
        
    }
}
