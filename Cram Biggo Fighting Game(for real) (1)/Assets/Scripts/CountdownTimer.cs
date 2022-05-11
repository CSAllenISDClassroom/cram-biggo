using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class CountdownTimer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    float currentTime;
    public float startingTime;
    [SerializeField] public TextMeshProUGUI textBox;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        int minutes = (int) (currentTime / 60);
        int seconds = (int) currentTime % 60;
        textBox.text = minutes.ToString() + ":" + seconds.ToString();
        if (currentTime < 0)
        {
            if (player2.GetComponent<PlayerHealth>().stocks > player1.GetComponent<PlayerHealth>().stocks)
            {
                player1.GetComponent<PlayerHealth>().stocks = 1;
                player1.GetComponent<PlayerHealth>().OnDeath();
            }
            else
            {
                player2.GetComponent<PlayerHealth>().stocks = 1;
                player2.GetComponent<PlayerHealth>().OnDeath();
            }

        }
    }
}
