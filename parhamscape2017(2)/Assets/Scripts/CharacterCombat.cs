using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

    CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    public void Attack(CharacterStats targetStats)
    {
        Debug.Log("DAMAGE2: " + (myStats.damage.GetValue()));
        targetStats.TakeDamage(myStats.damage.GetValue());
    }

}
