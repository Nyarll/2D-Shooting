using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float const_speed = 4f;

    [SerializeField]
    float fire_interval = 1f;

    float interval_now = 0f;

    GameObject shot;

    // Start is called before the first frame update
    void Start()
    {
        shot = (GameObject)Resources.Load("Shot");
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Move();
    }

    void Move()
    {
        Vector3 vel = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        vel.Normalize();
        float speed = Input.GetKey(KeyCode.LeftShift) ? (const_speed / 2f) : const_speed;

        transform.position += vel * Time.deltaTime * speed;
    }

    void Fire()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(interval_now > (1f / fire_interval))
            {
                interval_now = 0f;
                GameObject shot_instance = (GameObject)Instantiate(shot, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                Shot shot_component = shot_instance.GetComponent<Shot>();
                shot_component.SetSpeed(8f);
                shot_component.SetDirection(Vector3.up);
            }
            interval_now += Time.deltaTime;
        }
    }
}
