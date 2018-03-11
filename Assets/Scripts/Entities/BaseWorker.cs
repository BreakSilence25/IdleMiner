using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BaseWorker : MonoBehaviour
{
    public GlobalSystem gs;

    public Button taskButton;
    public Slider taskProgressBar;
    public Button managerButton;

    public float maxLoad;
    public float workSpeed;
    public float moveSpeed;

    public float currentGoldAmount;
    public bool isWorking;
    public bool hasManager;
    public bool isMineshaft;


    protected virtual void Start()
    {
        isWorking = false;
        hasManager = false;
    }

    protected virtual void ClickEvent()
    {
        isWorking = true;
        taskButton.interactable = false;

        if (currentGoldAmount <= maxLoad && isWorking && isMineshaft)
        {
            InvokeRepeating("WorkingTask", 1.0f, 1.0f);
        }
        else if (currentGoldAmount <= maxLoad && isWorking)
        {
            WorkingTask();
        }

    }

    protected virtual void WorkingTask()
    {
        currentGoldAmount += workSpeed;
        taskProgressBar.value = CalculateProgress();
    }

    protected virtual void ReturnToStorage()
    {
        //--GlobalSystem.StorageType += currentGoldAmount;
        //CancelInvoke("WorkingTask");
        currentGoldAmount = 0f;
        taskProgressBar.value = 0f;       
        isWorking = false;
        if (hasManager)
        {
            Invoke("ClickEvent", moveSpeed);
        }
        else
            StartCoroutine(ReturnStartPos());
    }

    float CalculateProgress()
    {
        return currentGoldAmount / maxLoad;
    }

    public IEnumerator ReturnStartPos()
    {
        yield return new WaitForSeconds(moveSpeed);
        taskButton.interactable = true;
    }

    public void GetManaged()
    {
        hasManager = true;
        managerButton.interactable = false;
        gs.RemoveGold();
    }
}
