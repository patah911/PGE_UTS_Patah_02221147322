using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcontroller : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 10f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Resetballcontroller();
}
    public void Resetballcontroller()
    {
        rigidbody.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        Invoke(nameof(SetRandomTrajectory), 1f);
    }
    private void SetRandomTrajectory()
    {
        Vector2 force = new Vector2();
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        rigidbody.AddForce(force.normalized * speed, ForceMode2D.Impulse);
    }
    // Update is called once per frame
        private void FixedUpdate()
        {
            rigidbody.velocity = rigidbody.velocity.normalized * speed;
        }

        }

