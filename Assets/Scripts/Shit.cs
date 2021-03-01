using System.Collections;
using UnityEngine;
public class Shit : MonoBehaviour
{
    public bool isDead = false;
    public float speed = 1f;
    public bool canShoot = true;

    [SerializeField] private SpriteRenderer sprite, wing;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject lazer;
    [SerializeField] private Transform tip;

    private float minX = -8f;
    private float maxX = 8f;
    #region this region
    #region second region
    //hi
    #endregion
    private void Update()
    {
        if (!isDead)
        {
            if (Input.GetKey(KeyCode.Space) && canShoot) ShootLazer();
            if (Input.GetKey(KeyCode.LeftArrow)) MoveLeft();
            if (Input.GetKey(KeyCode.RightArrow)) MoveRight();
        }
        else return;
    }
    #endregion
    #region shooty shooty
    public void ShootLazer() => StartCoroutine("Shoot");
    IEnumerator Shoot()
    {
        canShoot = false;
        GameObject lazerShot = SpawnLazer();
        lazerShot.transform.position = tip.position;
        yield return new WaitForSeconds(0.4f);
        canShoot = true;
    }
    public GameObject SpawnLazer()
    {
        GameObject newLazer = Instantiate(lazer);
        newLazer.SetActive(true);
        return newLazer;
    }
    #endregion
    #region movy movy
    public void MoveLeft()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        if (transform.position.x < minX) transform.position = new Vector2(minX, -3.25f);
    }
    public void MoveRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        if (transform.position.x > maxX) transform.position = new Vector3(maxX, -3.25f);
    }
    #endregion
    #region why the fuck is this programmed like this
    public void Explode()
    {
        sprite.enabled = false;
        wing.enabled = false;
        explosion.SetActive(true);
        isDead = true;
    }
    public void RepairShit()
    {
        sprite.enabled = true;
        wing.enabled = true;
        explosion.SetActive(false);
        isDead = false;
    }
    #endregion
}