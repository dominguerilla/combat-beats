using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum POSITION {
    LO,
    MED,
    HI
}

[CreateAssetMenu(fileName ="New Beat Weapon", menuName ="Beat Weapon Definition", order =0)]
public class BeatWeaponDefinition : ScriptableObject
{
    public string Name = "Beat Weapon";

    /// <summary>
    /// The number of beats to 'aim'/telegraph the attack before actually attacking.
    /// A value of 0 means this weapon will attack immediately.
    /// </summary>
    public int beatsToAim = 0;

    /// <summary>
    /// The number of beats after an attack that the attacker cannot act.
    /// </summary>
    public int beatCooldownAfterAttack = 1;
}
