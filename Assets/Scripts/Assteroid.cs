using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assteroid : MonoBehaviour
{
    public float speed = 1;
    private readonly float cunt = -5;
    private void Update() => Move();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Purgatory.GameOver();
            Destroy(gameObject);
        }
    }
    private void Move()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
        if (transform.position.y < cunt) Destroy(gameObject);
    }
}
