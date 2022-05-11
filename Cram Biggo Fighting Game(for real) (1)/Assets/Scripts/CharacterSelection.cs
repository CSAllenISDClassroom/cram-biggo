using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selection = 0;
    public string player;
    // Start is called before the first frame update
    public void NextCharacter()
    {
        //makes previous selected character no longer appear
        characters[selection].SetActive(false);
        selection++;
        selection %= 3;
        //makes new character appear
        characters[selection].SetActive(true);
    }
    public void PreviousCharacter()
    {
        //makes previous selected character no longer appear
        characters[selection].SetActive(false);
        selection--;
        //checking if 0, if it is then go to last character in array
        if (selection < 0)
        {
            selection += characters.Length;
        }
        //setting new character active(making appear)
        characters[selection].SetActive(true);
    }
    // Starts game once chosen
    public void StartGame()
    {
        Debug.Log(player);
        PlayerPrefs.SetInt(player, selection);
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
