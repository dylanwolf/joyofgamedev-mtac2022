using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float Speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Speed * Time.deltaTime, 0, 0);

        if (transform.position.x < -Camera.main.orthographicSize * Camera.main.aspect)
        {
            Destroy(this.gameObject);
        }
    }

    void PlayerBulletHit()
    {
        Destroy(this.gameObject);
    }

    void PlayerShipHit(PlayerShip ship)
    {
        Destroy(ship.gameObject);
    }
}
