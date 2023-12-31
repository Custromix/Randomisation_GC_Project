using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedTextAppear : MonoBehaviour
{

    [SerializeField]
    private TMP_Text _textMeshPro;

    public int _seed = 0;

    // Start is called before the first frame update
    void Start()
    {
        _textMeshPro.text = "Seed : " + _seed;
    }

    // Update is called once per frame
    void Update()
    {
        _textMeshPro.text = "Seed : " + _seed;
    }
}
