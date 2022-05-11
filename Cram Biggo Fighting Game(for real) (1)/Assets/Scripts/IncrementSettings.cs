using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class IncrementSettings : MonoBehaviour
{
    public int number;
    public string adder;
    public string thing;
    [SerializeField] public TextMeshProUGUI textBox;
    // Start is called before the first frame update
   

    // Update is called once per frame
    public void Increase()
    {
        number++;
        if (number > 100)
        {
            number = 100;
        }
        textBox.text = number.ToString() + adder;
    }
    public void Decrease()
    {
        number--;
        if (number < 1)
        {
            number = 1;
        }
        textBox.text = number.ToString() + adder;
    }
    public void GoToCharacterSelection()
    {
        PlayerPrefs.SetInt(thing, number);
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}

