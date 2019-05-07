using UnityEngine;

public class Dancer : MonoBehaviour
{
    public BeatWeapon weapon;

    bool isAiming = false;
    int beatsLeftAiming = 0;

    private void Start() {
        Metronome.instance.OnTick.AddListener(Tick);   
    }

    void Tick(){
        if(isAiming){
            beatsLeftAiming--;
            if(beatsLeftAiming <= 0){
                isAiming = false;
                beatsLeftAiming = 0;
                // Attack!
                weapon.ResetPosition();
            }
        }
    }

    public void StartAttack(POSITION pos){
        isAiming = true;
        // TODO: should I be accessing this member of weapon directly?
        beatsLeftAiming = weapon.weapon.beatsToAim;
        weapon.AimWeapon(pos);
    }
}
