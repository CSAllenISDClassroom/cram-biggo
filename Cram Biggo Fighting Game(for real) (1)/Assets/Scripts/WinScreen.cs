using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinScreen : MonoBehaviour
{
    public string which;
    public GameObject[] chars;
    // Start is called before the first frame update
    void Start()
    {
        int chosen = PlayerPrefs.GetInt(which);
        chars[chosen].SetActive(true);
    }
    public void playAgain()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
