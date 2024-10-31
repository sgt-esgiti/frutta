public class Fruit {
    // CONSTRUCTOR
    public Fruit() {}

    // VARIABLES
    private float points;

    public float Points {
        get {return points;}
        set {
            if (value < 1)
            {
                points = 1;
            }
            else
            {
                points = value;
            }
        }
    }
}