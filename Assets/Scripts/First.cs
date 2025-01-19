using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class First : MonoBehaviour
{
    public bool bought = false;
    public EventSystem eventSystem;
    double point;
    private int price = 1;
    public Button bitton;
    // Start is called before the first frame update
     void Start()
    {
        point = eventSystem.GetComponent<Calculations>().secretPoints;
        bitton.interactable = false;
        eventSystem.GetComponent<Calculations>().Repeat();
        
    }

    // Update is called once per frame
    void Update()
    {
        point = eventSystem.GetComponent<Calculations>().secretPoints;
        if(point >= price && bought == false)
        {
            bitton.interactable = true;
            
        }
        else
        {
            bitton.interactable = false;
        }
        print(point);
       
    }
    
    public void OnButtonClick()
    {
        bought = !bought;
        eventSystem.GetComponent<Calculations>().Repeat();
        bitton.interactable = false ;
        eventSystem.GetComponent<Calculations>().secretPoints = eventSystem.GetComponent<Calculations>().secretPoints - price;
        
    }
}
