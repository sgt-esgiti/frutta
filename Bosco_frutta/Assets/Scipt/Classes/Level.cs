using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Level
{
    public Level(int c, float v){
        Cost = c;
        Value = v;
    }

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
