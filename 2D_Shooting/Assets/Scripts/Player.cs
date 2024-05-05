using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("プレイヤーの移動限界範囲")]
    [SerializeField]
    Vector2 left_down = new Vector2(-9f, -4.7f);

    [SerializeField]
    Vector2 right_top = new Vector2(9f, 4.7f);

    [Header("移動速度")]
    [SerializeField]
    float const_speed = 4f;

    [Header("射撃間隔")]
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

        Vector3 position = transform.position + vel * Time.deltaTime * speed;

        position.x = Mathf.Clamp(position.x, left_down.x, right_top.x);
        position.y = Mathf.Clamp(position.y, left_down.y, right_top.y);

        transform.position = position;
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
