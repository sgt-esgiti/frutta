using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public Level(){}

    private int cost;
    public int Cost
    {
        get { return cost; }
        set
        {
            if (value < 0)
            {
                cost = 0;
            }
            else
            {
                cost = value;
            }
        }
    }
    private float value;
    public float Value
    {
        get { return value; }
        set
        {
            if (value < 0)
            {
                this.value = 0;
            }
            else
            {
                this.value = value;
            }
        }
    }
}
