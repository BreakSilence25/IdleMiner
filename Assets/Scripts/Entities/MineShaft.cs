using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MineShaft : BaseWorker
{ 

	void FixedUpdate ()
    {
        if (currentGoldAmount >= maxLoad)
        {
            CancelInvoke("WorkingTask");
            ReturnToStorage();
        }       
    }

    protected override void ReturnToStorage()
    {
        GlobalSystem.StorageMineshaft += currentGoldAmount;
        base.ReturnToStorage();
    }

}
