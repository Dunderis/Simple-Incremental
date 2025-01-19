using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Fifth : MonoBehaviour
{
    public bool bought = false;
    
    double point;
    int price = 30;
    public TextMeshProUGUI priceText;
    public Button bitton;
    public EventSystem eventSystem;
    // Start is called before the first frame update
    void Start()
    {
        
        bitton.interactable = false;
        priceText.text ="Price: "+ price.ToString();
        
        
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
       
    }
    
    public void OnButtonClick()
    {
        bought = !bought;
        bitton.interactable = false ;
        eventSystem.GetComponent<Calculations>().secretPoints = eventSystem.GetComponent<Calculations>().secretPoints - price;
    }
}
