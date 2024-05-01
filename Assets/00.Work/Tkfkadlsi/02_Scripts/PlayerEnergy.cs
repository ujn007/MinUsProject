using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    public event Action PlayerTurnEnd;
    private int energy = 3;

    public void TurnStart(int newTurnEnergy)
    {
        TMananger.instance.CurrnetState = GameState.PlayerTurn;
        energy = newTurnEnergy;
    }

    public int GetEnergy()
    {
        return energy;
    }

    public void PlusEnergy(int plusEnergy)
    {
        energy += plusEnergy;
    }

    public void MinusEnergy(int value)
    {
        energy -= value;

        if(energy == 0)
        {
            TMananger.instance.CurrnetState = GameState.EnemyTurn;
            PlayerTurnEnd?.Invoke();
        }
    }
}
