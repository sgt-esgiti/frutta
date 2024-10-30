public class Player {
    // CONSTRUCTORS
    private int movement_speed;
    private int game_points;
    private int total_points;
    private int points_multiplier;

    public int MovementSpeed {
        get {return speed;}
        set {
            int min_speed = 1;
            int max_speed = 7;
    
            if (value < min_speed)
                movement_speed = min_speed;
            else if (value > max_speed)
                movement_speed = max_speed;
            else
                movement_speed = value;
        }
    }

    public int GamePoints {
        get {return game_points;}
        set {
            if (value < 0)
                game_points = 0;
            else
                game_points = value;
        }
    }

    public int TotalPoints {
        get {return total_points;}
        set {
            if (value < 0)
                total_points = 0;
            else
                total_points = value;
        }
    }

    public int PointsMultiplier {
        get {return points_multiplier;}
        set {
            if (value < 1)
                points_multiplier = 1;
            else
                points_multiplier = value;
        }
    }

    // METHODS
    public void AddPoints() {
        TotalPoints += GamePoints;
    }
}