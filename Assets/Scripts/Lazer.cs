using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private float lazerSpeed = 5f;
    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * lazerSpeed);
        if (transform.position.y > 10f) Destroy(gameObject);
        if (Time.timeScale < 0.5) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Assteroid>() != null)
        {
            Purgatory.AssteroidDestroyed();
            Destroy(gameObject);
            spawner.assteroids.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
