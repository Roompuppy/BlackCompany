using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool isDelay;
    public float delayTime = 2f;
    private Rigidbody2D rigid2D;
    private GameObject waterpipe3;
    

    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (!isDelay)
            {
                isDelay = true;

                float x = Input.GetAxisRaw("Horizontal");
                float y = Input.GetAxisRaw("Vertical");

                transform.Translate(new Vector3(x, y, 0f));
                StartCoroutine(CountMoveDelay());
            }
        }

    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "waterpipe3")
            ObMove(collision.transform.position);
    }
    void ObMove(Vector2 targetpos)
    {
        float X_cpy = waterpipe3.GetComponent<Transform>().position.x;
        float Y_cpy = waterpipe3.GetComponent<Transform>().position.y;
        int dirc_x = waterpipe3.GetComponent<Transform>().position.x - targetpos.x > 0 ? 1 : -1;
        int dirc_y = waterpipe3.GetComponent<Transform>().position.y - targetpos.y > 0 ? 1 : -1;

        waterpipe3.GetComponent<Transform>().position = new Vector3(X_cpy + dirc_x, Y_cpy + dirc_y, 0f);
    }
    IEnumerator CountMoveDelay()
    {
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
    }
}
