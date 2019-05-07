using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Metronome : MonoBehaviour
{
    static Metronome _instance;

    // TODO there's a better way to handle this...maybe create one instead of expecting one to already exist?
    // if it's created in that fashion, the metronome just won't be visible.
    public static Metronome instance{
        get{
            if(_instance == null) {
                _instance = FindObjectOfType<Metronome>();
            }
            return _instance;
        }
    }

    // beats per minute
    public float BPM = 105f;
    // how big the metronome gets when pulsing on a beat
    public float beatScalar = 2.0f;

    public UnityEvent OnTick;

    // how long before/after a beat that a player can still input.
    // half is before, half is after.
    [Range(0,1.0f)]
    public float gracePeriodPercentage = 0.5f;

    // this is set to True during the grace period after a tick, false otherwise
    bool isGrace;

    Vector3 originalScale;
    Vector3 newScale;
    void Start()
    {
        // I don't know if this math is right....
        float beatsPerSecond = BPM / 60f;
        float fourthBeatsPerSecond = beatsPerSecond / 4f;
        StartCoroutine(StartTicking(fourthBeatsPerSecond));
    }

    IEnumerator StartTicking(float beatsPerSecond){
        originalScale = transform.localScale;
        newScale = originalScale * beatScalar;
        float gracePeriod = beatsPerSecond * gracePeriodPercentage;
        float remainder = beatsPerSecond - gracePeriod;
        while (true){
            // grace period is active here!
            isGrace = true;
            Tick();
            yield return new WaitForSeconds(gracePeriod);
            
            // grace period no longer active.
            isGrace = false;
            yield return new WaitForSeconds(remainder);
        }
    }

    void Tick(){
        if(transform.localScale == originalScale){
            transform.localScale = newScale;
        }else{
            transform.localScale = originalScale;
        }
        OnTick.Invoke(); 
    }

    public bool isOnBeat(){
        return isGrace;
    }
}
