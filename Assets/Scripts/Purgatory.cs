using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Text = UnityEngine.UI.Text;
public class Purgatory : MonoBehaviour
{
    public int score = 0;
    public bool isGameOver = false;
    public Spawner spawner;
    [SerializeField] private GameObject shit;
    [SerializeField] private GameObject start;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text titleText;
    private static Purgatory v;
    private void Start()
    {
        v = this;
        titleText.enabled = true;
        gameOverText.enabled = false;
        scoreText.enabled = false;
        start.SetActive(true);
    }
    public static void GameOver()
    {
        /*GameObject clone[] = GameObject.FindGameObjectsWithTag("Lazer");
        if (clone != null)
        {
            Destroy(clone);
        }
        foreach (var item in collection)
        {

        }*/
        v.titleText.enabled = true;
        v.start.SetActive(true);
        v.isGameOver = true;
        v.spawner.StopSpawning();
        v.shit.GetComponent<Shit>().Explode();
        v.gameOverText.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void NewGame()
    {
        isGameOver = false;
        titleText.enabled = false;
        start.SetActive(false);
        shit.transform.position = new Vector2(0, -3.25f);
        // shit.transform.eulerAngles = new Vector2(90, 180);
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        scoreText.enabled = true;
        spawner.BeginSpawning();
        shit.GetComponent<Shit>().RepairShit();
        spawner.ClearAssteroids();
        gameOverText.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
    public static void AssteroidDestroyed()
    {
        v.score++;
        v.scoreText.text = "Score: " + v.score.ToString();
    }
    public Shit GetShit()
    {
        return shit.GetComponent<Shit>();
    }
}