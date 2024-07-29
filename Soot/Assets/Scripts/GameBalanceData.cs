using System;
using System.Collections.Generic;

[Serializable]
public class GameBalanceData
{
    public List<Movement> Movement;
}

[Serializable]
public class Movement
{
    public float Speed;
    public float JumpForce;
    public float MaxJumpHeight;
    public float FallMultiplier;
}
