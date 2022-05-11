using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MakeCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform p1spawnPoint;
    public Transform p2spawnPoint;
    public Transform[] looks;
    public CountdownTimer timer;
    [SerializeField] public TextMeshProUGUI stocks1Box;
    [SerializeField] public TextMeshProUGUI stocks2Box;
    //public TMP_Text p1label;
    //public TMP_Text p2label;
    // Start is called before the first frame update
    void Start()
    {
        void changeMovements(GameObject player, KeyCode up, KeyCode down, KeyCode right, KeyCode left, KeyCode attack, KeyCode special, KeyCode jump) {
            PlayerMovement movement = player.GetComponent<PlayerMovement>();
            movement.up = up;
            movement.down = down;
            movement.right = right;
            movement.left = left;
            movement.attack = attack;
            movement.special = special;
            movement.jump = jump;
        }
        Debug.Log(PlayerPrefs.GetInt("player1"));
        int selectedCharacterp1 = PlayerPrefs.GetInt("player1");
        int selectedCharacterp2 = PlayerPrefs.GetInt("player2");
        int stocks = PlayerPrefs.GetInt("stocks");
        //int stocks = PlayerPrefs.GetInt("stocks");
        int time = PlayerPrefs.GetInt("time");
        GameObject p1prefab = characterPrefabs[selectedCharacterp1];
        GameObject p2prefab = characterPrefabs[selectedCharacterp2];
        GameObject p1clone = Instantiate(p1prefab, p1spawnPoint.position, Quaternion.identity);
        GameObject p2clone = Instantiate(p2prefab, p2spawnPoint.position, Quaternion.identity);
        timer.player1 = p1clone;
        timer.player2 = p2clone;
        p1clone.GetComponent<PlayerHealth>().stocks = stocks;
        p2clone.GetComponent<PlayerHealth>().stocks = stocks;
        p1clone.GetComponent<PlayerHealth>().stockBox = stocks1Box;
        p2clone.GetComponent<PlayerHealth>().stockBox = stocks2Box;
        stocks1Box.text = "Stocks: " + stocks.ToString();
        stocks2Box.text = "Stocks: " + stocks.ToString();
        timer.startingTime = time * 60;
        p1clone.GetComponent<PlayerHealth>().opponent = selectedCharacterp2;
        p1clone.GetComponent<PlayerHealth>().own = selectedCharacterp1;
        p2clone.GetComponent<PlayerHealth>().own = selectedCharacterp2;
        p2clone.GetComponent<PlayerHealth>().opponent = selectedCharacterp1;
        //timer.startingTime = time;
        //p1clone.AddComponent<Rigidbody>();
        //p2clone.AddComponent<Rigidbody>();
        changeMovements(p1clone, KeyCode.W, KeyCode.S, KeyCode.D, KeyCode.A, KeyCode.J, KeyCode.K, KeyCode.L);
        changeMovements(p2clone, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.Mouse0, KeyCode.Mouse1, KeyCode.Mouse2);
        //p1label.text = p1prefab.name;
        //p2label.text = p2prefab.name;
    }
}
