using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvaManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _seedInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadSeed()
    {
        //Debug.Log();
        int seed = 0;

        try
        {
            seed = int.Parse(_seedInput.text);
        }catch (Exception e) { }

        Debug.Log(GameManager.getGameManager());
        GameManager.getGameManager().InitGameManager(seed);
    }

   
}
