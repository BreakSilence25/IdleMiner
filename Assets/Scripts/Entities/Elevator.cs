using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Elevator : BaseWorker
{

    protected override void WorkingTask()
    {

        if (GlobalSystem.StorageMineshaft - maxLoad >= 0f && isWorking)
        {
            GlobalSystem.StorageMineshaft -= maxLoad;
            currentGoldAmount += maxLoad;
        }
        else //remove rest when storage less than maxLoad
        {
            currentGoldAmount += GlobalSystem.StorageMineshaft;
            GlobalSystem.StorageMineshaft = 0f;
        }
        ReturnToStorage();
    }

    protected override void ReturnToStorage()
    {
        GlobalSystem.StorageElevator += currentGoldAmount;
        base.ReturnToStorage();

    }

}
