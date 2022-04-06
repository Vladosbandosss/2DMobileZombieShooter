using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieGoal
{
    PLAYER,
    FENCE
}

public enum GameGoal
{
    KILLZOMBIE,
    WALKTOGOALSTEPS,
    DEFENDFANCE,
    TIMERCOUNTDOWN,
    GAMEOVER
}

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [HideInInspector] 
    public bool bulletAndBulFXCreated,rocketBulCreated;

    [HideInInspector] 
    public bool playerAlive,fenceDestroyed;

    public ZombieGoal zombieGoal = ZombieGoal.PLAYER;

    public GameGoal gameGoal = GameGoal.DEFENDFANCE;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnDisable()
    {
        instance = null;
    }

    private void Start()
    {
        playerAlive = true;
    }
}
