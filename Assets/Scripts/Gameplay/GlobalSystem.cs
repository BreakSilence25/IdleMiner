using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GlobalSystem : MonoBehaviour
{
    public Text totalGoldDisplay;
    public Text mineShaftStorage;
    public Text elevatorStorage;

    public Button buyMineshaftManager;
    public Button buyElevatorManager;
    public Button buyRefineryManager;

    public MineShaft mineShaft;
    public Elevator elevator;
    public Refinery refinery;

    public static float totalGold;
    public static float StorageMineshaft; //{get {return StorageMineshaft; } set {StorageMineshaft = value;}}
    public static float StorageElevator;  //{ get { return StorageElevator; } set { StorageElevator = value;}}

    public float managerCost;
    public float managerCostMultiplier = 1.8f;

    void Awake()
    {
        managerCost = 50f;
        buyMineshaftManager.interactable = false;
        buyElevatorManager.interactable = false;
        buyRefineryManager.interactable = false;
    }

    void FixedUpdate()
    {
        //Display gold amount in boxes
        totalGoldDisplay.GetComponent<Text>().text = string.Format("Total Gold: {0:#0.0}", totalGold);
        mineShaftStorage.GetComponent<Text>().text = string.Format("Stored Gold: {0:#0.0}", StorageMineshaft);
        elevatorStorage.GetComponent<Text>().text = string.Format("Stored Gold: {0:#0.0}", StorageElevator);


        //Enable Managerbuttons
        if (managerCost <= totalGold && !mineShaft.hasManager)
        {
            buyMineshaftManager.interactable = true;
        }
        else if(managerCost <= totalGold && !elevator.hasManager)
        {
            buyElevatorManager.interactable = true;
        }
        else if(managerCost <= totalGold && !refinery.hasManager)
        {
            buyRefineryManager.interactable = true;
        }

    }

    public void RemoveGold()
    {
        totalGold -= managerCost;
        managerCost *= managerCostMultiplier;
    }

}