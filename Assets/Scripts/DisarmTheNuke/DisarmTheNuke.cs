﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisarmTheNuke : IMiniGame
{

    public EndStateManager WinState;


    public override void beginGame()
    {
        //Pong Begins
        Debug.Log(this.ToString() + " game Begin");
    }

    public override void initGame(MiniGameDificulty difficulty, GameManager gm)
    {
        WinState.init(gm); 
    }

    public override string ToString()
    {
        return "DisarmTheBomb Miau";
    }
}
