using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test
{
    private Purgatory v;

    [SetUp] public void SetUp()
    {
        GameObject vGO = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Purgatory"));
        v = vGO.GetComponent<Purgatory>();
    }

    [TearDown] public void TearDown() => Object.Destroy(v.gameObject);

    [UnityTest] public IEnumerator AsteroidsMoveDown()
    {
        Spawner spawner = v.spawner;
        GameObject ass = spawner.SpawnAssteroid();

        float initialY = ass.transform.position.y;

        yield return new WaitForSeconds(0.1f);

        Assert.Less(ass.transform.position.y, initialY);
    }

    [UnityTest] public IEnumerator GameOverOccursOnAssCollision()
    {
        Spawner spawner = v.spawner;
        GameObject ass = spawner.SpawnAssteroid();

        Shit shit = v.GetShit();
        GameObject fan = shit.gameObject;

        ass.transform.position = fan.transform.position;

        Time.timeScale = 1;
        yield return null;
        if (Time.timeScale == 0) Time.timeScale = 1;
        yield return new WaitForSeconds(0.1f);

        Assert.True(v.isGameOver);
    }

    [UnityTest] public IEnumerator NewGameStartsOnButton()
    {
        v.isGameOver = true;
        v.NewGame();
        yield return null;
        Assert.False(v.isGameOver);
    }

    [UnityTest] public IEnumerator LazerAccends()
    {
        Shit shit = v.GetShit();
        GameObject fan = shit.gameObject;
        GameObject lazer = shit.SpawnLazer();
        float initialY = lazer.transform.position.y;
        yield return new WaitForSeconds(0.1f);
        Assert.Greater(lazer.transform.position.y, initialY);
    }

    [UnityTest] public IEnumerator LazerDestroyesAss()
    {
        Shit shit = v.GetShit();
        GameObject fan = shit.gameObject;
        GameObject lazer = shit.SpawnLazer();
        Spawner spawner = v.spawner;
        GameObject ass = spawner.SpawnAssteroid();
        lazer.transform.position = ass.transform.position;
        yield return new WaitForSeconds(0.1f);
        UnityEngine.Assertions.Assert.IsNull(ass);
    }
}