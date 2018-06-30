using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInputGenerator : MonoBehaviour
{
    string input;
    float lastInputTime;
    int bias;
    string path = "Assets/Input/input.txt";
    // Use this for initialization
    void Start()
    {
        lastInputTime = Time.time;
        System.IO.File.WriteAllText(path, string.Empty);

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time - lastInputTime >= 5)
        {
            System.IO.File.WriteAllText(path, string.Empty);
            string input = string.Empty;
            bias = (int)(Random.value * 4);
            Debug.Log("bias = " + bias);
            for (int i = 1; i <= 300; i++)
            {
                int biasDetirmine = (int)(Random.value * 4);
                //Debug.Log("biasDetir = " + biasDetirmine);
                int nextInputCommand;
                if (biasDetirmine <= 1)
                {
                    nextInputCommand = bias;
                }
                else
                {
                    do
                    {
                        nextInputCommand = (int)(Random.value * 4);
                    } while (nextInputCommand == bias);
                }
                input = input + nextInputCommand;
            }
            //TODO
            Debug.Log(input);
            System.IO.File.WriteAllText(path, input);
            lastInputTime = Time.time;
        }

    }
}
