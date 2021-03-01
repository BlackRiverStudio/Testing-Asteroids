using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> assteroids = new List<GameObject>();
    [SerializeField] private GameObject assteroid1;
    [SerializeField] private GameObject assteroid2;
    [SerializeField] private GameObject assteroid3;
    [SerializeField] private GameObject assteroid4;
    public void BeginSpawning() => StartCoroutine("Spawn");
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.4f);
        SpawnAssteroid();
        StartCoroutine("Spawn");
    }
    public GameObject SpawnAssteroid()
    {
        int random = Random.Range(1, 5);
        var assteroid = random switch
        {
            1 => Instantiate(assteroid1),
            2 => Instantiate(assteroid2),
            3 => Instantiate(assteroid3),
            4 => Instantiate(assteroid4),
            _ => Instantiate(assteroid1),
        };
        assteroid.SetActive(true);
        float xPos = Random.Range(-8f, 8f);
        assteroid.transform.position = new Vector2(xPos, 7.35f);
        assteroids.Add(assteroid);
        return assteroid;
    }
    public void ClearAssteroids()
    {
        foreach (GameObject assteroid in assteroids) Destroy(assteroid);
        assteroids.Clear();
    }
    public void StopSpawning() => StopCoroutine("Spawn");
}