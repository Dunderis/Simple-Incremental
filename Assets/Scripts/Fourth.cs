using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Fourth : MonoBehaviour
{
    public bool bought = false;
    
    double point;
    float price = 15;
    public EventSystem eventSystem;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI BuyingTimes;
    private int max = 10;
    public int buying = 0;
    public Button bitton;
    // Start is called before the first frame update
    void Start()
    {
        bitton.interactable = false;
       priceText.text = "Price: " + price;
       BuyingTimes.text = buying.ToString()+ "/"+max.ToString();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        point = eventSystem.GetComponent<Calculations>().secretPoints;
        if(point >= price  && buying < max)
        {
            bitton.interactable = true;
            
        }
        else
        {
            bitton.interactable = false;
        }
        priceText.text = "Price: " + price.ToString("F2");
        BuyingTimes.text = buying.ToString()+ "/"+max.ToString();
       
    }
    
    public void OnButtonClick()
    {
        bought = true;
        bitton.interactable = false ;
        eventSystem.GetComponent<Calculations>().secretPoints = eventSystem.GetComponent<Calculations>().secretPoints - price;
        buying += 1;
        price = price * 1.1f;
    }
}
