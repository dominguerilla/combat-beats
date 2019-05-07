using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    public KeyCode beatCheck = KeyCode.Space;
    public Dancer dancer;
     
    void Update()
    {
        if(Input.GetKeyDown(beatCheck)){
            if(Metronome.instance.isOnBeat()){
                dancer.StartAttack(POSITION.HI);
            }
        }
    }
}
