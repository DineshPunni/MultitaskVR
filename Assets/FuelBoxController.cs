using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

public class FuelBoxController : MonoBehaviour {


    public List<GameObject> switches;
    public GameObject checkLight;

    public Text patternText;
    

    List<bool> handleValues = new List<bool>(new bool[] { false, false, false });
    List<bool> pattern = new List<bool>(new bool[] {false,true,false });


    string patterntext;



    public void ButtonPress()
    {
        for (int i = 0; i < switches.Count; i++)
        {


            LinearMapping lm =  switches[i].GetComponentInChildren<LinearMapping>();
          
            bool isOn = lm.value >= 0.5 ? true : false;
            handleValues[i] = isOn;
        }

        var isCorrect = CompareWithPattern();
        Color newColor = isCorrect == true ? Color.green : Color.red;
        checkLight.GetComponent<Renderer>().material.color = newColor;

    }

    bool CompareWithPattern()
    {
        for (int i = 0; i < handleValues.Count; i++)
        {
            if (handleValues[i] != pattern[i])
                return false;
        }

        return true;
    }

    public void CreateNewPattern()
    {

        patterntext = "";

        for (int i = 0; i < pattern.Count; i++)
        {
            var rand = UnityEngine.Random.Range(0.0f, 1.0f);
            if (rand >= 0.5f)
                pattern[i] = true;
            else
                pattern[i] = false;

            patterntext += pattern[i].ToString() + " ";

        }

        patternText.text = patterntext;

        Debug.Log(patterntext);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            CreateNewPattern();
    }
}
