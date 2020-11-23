using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private const int V = 0;
    [SerializeField]
    private Transform barrelTip;

    int ballsLeft = 10;
    private int ballsPerShot = 1;
    bool hasFired = false;

    [SerializeField]
    private GameObject bullet;

    private Vector2 lookDirection;
    private float lookAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hasFired = false;

        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        if (Input.GetMouseButtonDown(0) && ballsLeft <= 0) return;


        if (Input.GetMouseButtonDown(0) && ballsLeft > 0)
        {
            FireBullet();
            hasFired = true;
        }

        if (hasFired)
        {
            ballsLeft -= ballsPerShot;
        }
    }

    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(bullet, barrelTip.position, barrelTip.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = barrelTip.up * 10f;
    }
}
