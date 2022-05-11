using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int stocks;
    public float percent;
    public int opponent;
    public int own;
    public LayerMask layerMask;
    public Transform respawner;
    [SerializeField] public TextMeshProUGUI stockBox;
    // Update is called once per frame
    private void Update()
    {
        if (percent >= 150)
        {
            OnDeath();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (layerMask == (layerMask | (1 << other.transform.gameObject.layer)))
        {
            Debug.Log(stocks);
            OnDeath();
        }
    }
    public void OnDeath()
    {
        Debug.Log(stocks);
        stocks -= 1;
        stockBox.text = "Stocks: " + stocks.ToString();
        if (stocks <= 0)
        {
            PlayerPrefs.SetInt("win", opponent);
            PlayerPrefs.SetInt("lose", own);
            SceneManager.LoadScene(4, LoadSceneMode.Single);
        }
        else
        {
            this.transform.position = respawner.transform.position;
        }
    }

}
