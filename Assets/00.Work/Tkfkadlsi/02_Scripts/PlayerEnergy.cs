using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    private int energy;

    public void TurnStart(int newTurnEnergy)
    {
        energy = newTurnEnergy;
    }


}
