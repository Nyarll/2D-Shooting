using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    private float speed = 1f;

    Vector3 direction = Vector3.up;

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
        AutoDestroy();
    }

    void AutoDestroy()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        
        // 領域外に出たら死ぬ
        if (x < (-15) || y < (-10) || x > (15) || y > (10))
        {
            Destroy(this.gameObject);
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
        this.direction.Normalize();
    }
}
