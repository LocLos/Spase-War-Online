using System;

[Serializable]
public class StateHealth
{
    public int CurrentHP;
    public int MaxHP;

    public void ResetHP()
    {
        CurrentHP = MaxHP;
    }
}
