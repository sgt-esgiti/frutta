public class Player
{
    // CONSTRUCTORS
    public Player()
    {
        MovementSpeed = 1;
        GamePoints = 0;
        TotalPoints = 0;
        PointsMultiplier = 1;
    }
    public Player(float points)
    {
        MovementSpeed = 1;
        GamePoints = 0;
        TotalPoints = points;
        PointsMultiplier = 1;
    }

    // VARIABLES
    private float movement_speed;
    private float game_points;
    private float total_points;
    private float points_multiplier;

    public float MovementSpeed
    {
        get { return movement_speed; }
        set
        {
            float min_speed = 1;
            float max_speed = 7;

            if (value < min_speed)
                movement_speed = min_speed;
            else if (value > max_speed)
                movement_speed = max_speed;
            else
                movement_speed = value;
        }
    }

    public float GamePoints
    {
        get { return game_points; }
        set
        {
            if (value < 0)
                game_points = 0;
            else
                game_points = value;
        }
    }

    public float TotalPoints
    {
        get { return total_points; }
        set
        {
            if (value < 0)
                total_points = 0;
            else
                total_points = value;
        }
    }

    public float PointsMultiplier
    {
        get { return points_multiplier; }
        set
        {
            if (value < 1)
                points_multiplier = 1;
            else
                points_multiplier = value;
        }
    }

    // METHODS
   
    //metodo per aggiungere punti alla fine di una partita di gioco
    public void AddPointsFinal() {
        TotalPoints += GamePoints;
    }

    public void AddGamePoints(float value){
        GamePoints += value * PointsMultiplier;
    }
}