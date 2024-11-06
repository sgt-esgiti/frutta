using System;

public class Upgrade
{

    // array di livelli
    public Level[] livello = new Level[6];

    // CONSTRUCTORS
    public Upgrade(Level[] newLevels)
    {
        this.Lv = 0;
        for (int i = 0; i<6; i++)
        {
            livello[i] = newLevels[i];
        }
    }

    public Upgrade(int lv, Level[] newLevels) {
        this.Lv = lv;
        for (int i = 0; i < 6; i++)
        {
            livello[i] = newLevels[i];
        }

    }

    //variables
    private int lv; //serve come indice array per sapere i costi e i valori dei livelli nel gioco
    public int Lv { 
        get { return lv; } 
        set {
            if (value < 0)
            {
                lv = 0;
            }
            else if (value > 5)
            {
                lv = 5;
            }
            else
            {
                lv = value;
            }
        } 
    }

}

