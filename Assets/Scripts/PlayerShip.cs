using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public float Speed = 10;
    public PlayerBullet BulletPrefab;

    public float ShootTimer = 0;
    public float ShootRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var movementX = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        var movementY = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        transform.Translate(movementX, movementY, 0);

        var pos = transform.position;
        pos.x = Mathf.Clamp(
            pos.x,
            -Camera.main.orthographicSize * Camera.main.aspect,
            Camera.main.orthographicSize * Camera.main.aspect
        );

        pos.y = Mathf.Clamp(
            pos.y,
            -Camera.main.orthographicSize,
            Camera.main.orthographicSize
        );
        transform.position = pos;

        if (ShootTimer <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                Instantiate(
                    BulletPrefab,
                    transform.position,
                    transform.localRotation
                );
                ShootTimer = ShootRate;
            }
        } else {
            ShootTimer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        collider.SendMessage("PlayerShipHit", this, SendMessageOptions.DontRequireReceiver);
    }
}
