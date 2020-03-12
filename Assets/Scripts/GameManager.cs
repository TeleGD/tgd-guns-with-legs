using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Start()
    {
        instance = this;    
    }

    public void EndRound()
    {
        StartCoroutine(DelayedEnd(3));
    }

    IEnumerator DelayedEnd(int i)
    {
        yield return new WaitForSeconds(i);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
