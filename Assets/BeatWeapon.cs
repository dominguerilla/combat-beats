using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the animation of a Beat Weapon according to the BeatWeaponDefinition assigned to it.
/// </summary>
public class BeatWeapon : MonoBehaviour
{
    public BeatWeaponDefinition weapon;
    
    // 0 is lo aim
    // 1 is mid aim
    // 2 is hi aim
    public Vector3[] aimPositions;
    public Vector3[] aimEulerAngles;
    public Vector3[] attackPositions;
    public Vector3[] attackEulerAngles;

    Vector3 idlePosition;
    Vector3 idleRotation;

    // Start is called before the first frame update
    void Start()
    {
        idlePosition = transform.localPosition;   
        idleRotation = transform.localRotation.eulerAngles;
    }

    void MoveToPosition(Vector3[] positions, Vector3[] angles, POSITION pos, float speed=10f){
        switch(pos){
            case POSITION.HI:
                StartCoroutine(Move(positions[2], angles[2], speed));
                break;
            default:
                break;
        }
    }

    public void AimWeapon(POSITION pos){
        MoveToPosition(aimPositions, aimEulerAngles, pos);
    }

    public void ResetPosition(){
        StartCoroutine(Move(idlePosition, idleRotation, 100f));
    }

    IEnumerator Move(Vector3 targetPosition, Vector3 targetRotation, float speed){
        transform.localPosition = targetPosition;
        transform.localRotation = Quaternion.Euler(targetRotation);
        yield break;
        /*
        Vector3 convertedTargetPos = targetPosition;
        float step = speed * Time.deltaTime;
        while(Vector3.Distance(transform.localPosition, convertedTargetPos) > 0.01f){
            transform.localPosition = Vector3.MoveTowards(transform.position, convertedTargetPos, step);
            yield return null;
        }
        Debug.Log("New position: " + transform.localPosition + ", " + transform.position);
        */
    }



}
