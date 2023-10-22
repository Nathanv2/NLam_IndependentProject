using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    private Animator animPlayer;
    // Start is called before the first frame update
    void Start()
    {
        animPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playanim()
    {
        animPlayer.SetBool("isTrigger", true);
        Debug.Log("djwoidjwa");
    }
}
