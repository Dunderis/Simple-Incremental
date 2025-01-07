using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Second : MonoBehaviour
{
    public bool bought = false;
    
    int point;
    int price = 10;
    public TextMeshProUGUI points;
    public Button bitton;
    // Start is called before the first frame update
    void Start()
    {
        
        bitton.interactable = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        point = int.Parse(points.text);
        if(point == price && bought == false)
        {
            bitton.interactable = true;
        }
       
    }
    
    public void OnButtonClick()
    {
        bought = !bought;
        bitton.interactable = false ;
        points.text = (int.Parse(points.text) - price).ToString();
    }
}
