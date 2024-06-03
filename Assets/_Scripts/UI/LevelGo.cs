using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGo : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Esc();
        }
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level-Fire1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level-Fire2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level-Fire3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level-Fire4");
    }
    public void Level5()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level6()
    {
        SceneManager.LoadScene("Level-Walkthrough1");
    }
    public void Level7()
    {
        SceneManager.LoadScene("Level-Walkthrough2");
    }
    public void Level8()
    {
        SceneManager.LoadScene("Level-Walkthrough3");
    }
    public void Level9()
    {
        SceneManager.LoadScene("Level-Walkthrough4");
    }
    public void Level10()
    {
        SceneManager.LoadScene("Level-Walkthrough5");
    }
    public void Level11()
    {
        SceneManager.LoadScene("Level-Shadow1");
    }
    public void Level12()
    {
        SceneManager.LoadScene("Level-Shadow2");
    }
    public void Level13()
    {
        SceneManager.LoadScene("Level-Shadow3");
    }
    public void Level14()
    {
        SceneManager.LoadScene("Level-Shadow4");
    }
    public void Level15()
    {
        SceneManager.LoadScene("Level-Shadow5");
    }
    public void Esc()
    {
        SceneManager.LoadScene("_Level-Menu");
    }
}
