using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class First : MonoBehaviour
{
    bool bought = false;
    int gen = 1;
    int point;
    int price = 1;
    public TextMeshProUGUI points;
    public Button bitton;
    // Start is called before the first frame update
     void Start()
    {
        point = int.Parse(points.text);
        bitton.interactable = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(point == price && bought == false)
        {
            bitton.interactable = true;
        }
       
    }
    public void Generate()
    {
        points.text =  (int.Parse(points.text)+gen).ToString();
        
        
    }
    public void Bought(bool bom)
    {
        if (bom == true)
        {
            InvokeRepeating("Generate", 0, 1);
        }
    }
    public void OnButtonClick()
    {
        bought = !bought;
        Bought(bought);
        bitton.interactable = false ;
        points.text = (int.Parse(points.text) - price).ToString();
    }
}
