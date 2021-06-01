using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class gameData
{
    // Start is called before the first frame update
    public bool boolLockLEVEL1;
    public bool boolLockLEVEL2;
    public bool boolLockLEVEL3;
    public bool boolLockLEVEL4;
    public bool boolLockLEVEL5;
    public bool boolLockLEVEL6;

    //public int lastDungeonID;
    public gameData(levelsPanel game)
    {
        boolLockLEVEL1 = game.boolLockLEVEL1;
        boolLockLEVEL2 = game.boolLockLEVEL2;
        boolLockLEVEL3 = game.boolLockLEVEL3;
        boolLockLEVEL4 = game.boolLockLEVEL4;
        boolLockLEVEL5 = game.boolLockLEVEL5;
        boolLockLEVEL6 = game.boolLockLEVEL6;

       // lastDungeonID = game.lastDungeonID;
    }


}//////
