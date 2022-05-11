using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersusment : MonoBehaviour
{
	public GameObject theFlash;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(theFlash, transform.position, transform.rotation);
    }
}
