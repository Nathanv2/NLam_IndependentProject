using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Animator animPlayer;

    // Start is called before the first frame update
    void Start()
    {
        animPlayer = GetComponent<Animator>();
        animPlayer.SetTrigger("isTrigger");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
