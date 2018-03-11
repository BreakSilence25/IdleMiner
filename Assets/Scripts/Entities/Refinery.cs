using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Refinery : BaseWorker
{

    protected override void WorkingTask()
    {

        if (GlobalSystem.StorageElevator - maxLoad >= 0f && isWorking)
        {
            GlobalSystem.StorageElevator -= maxLoad;
            currentGoldAmount += maxLoad;
        }
        else //remove rest when storage less than maxLoad
        {
            currentGoldAmount += GlobalSystem.StorageElevator;
            GlobalSystem.StorageElevator = 0f;
        }
        ReturnToStorage();
    }

    protected override void ReturnToStorage()
    {
        GlobalSystem.totalGold += currentGoldAmount;
        base.ReturnToStorage();
    }
}
