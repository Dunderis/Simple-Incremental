using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Calculations : MonoBehaviour
{
    private float multi = 1;
    float preMulti;
    private int gen = 0;
    private float genSpeed = 5;
    private float final;
    public Button first;
    public Button second;
    public Button third;
    public TextMeshProUGUI points;
    public TextMeshProUGUI Cps;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(first.GetComponent<First>().bought == true)
        {
            gen = 1;
        }
        if(second.GetComponent<Second>().bought == true)
        {
            multi = 2;
            preMulti = multi;
        }
        if (third.GetComponent<Third>().bought == true)
        {
            genSpeed = 1;
        }
        if (third.GetComponent<Third>().bought == true && (int.Parse(points.text) >= 1))
        {
            float add;
            add = (int.Parse(points.text) / 100);
            multi = preMulti + add;
            print(add + " third up");

        }
        final = multi * gen;
        Cps.text = final.ToString() + " p/s";
    }

    void StartGen()
    {
        if (first.GetComponent<First>().bought == true && second.GetComponent<Second>().bought == false)
        {
            final = gen;
        }
        
       
            points.text =  (int.Parse(points.text)+final).ToString();
            


    }

    public void Repeat()
    {
        if (first.GetComponent<First>().bought == true && third.GetComponent<Third>().bought == false)
        {
            InvokeRepeating("StartGen", 0, genSpeed);
        }
        else if (third.GetComponent<Third>().bought == true)
        {
            genSpeed = 1;
            CancelInvoke("StartGen");
            InvokeRepeating("StartGen",0,genSpeed);
            
        }

    }
    

}
