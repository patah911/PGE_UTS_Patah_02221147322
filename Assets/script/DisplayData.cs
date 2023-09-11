using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayData : MonoBehaviour
{
    public TextMeshProUGUI LabelScore;
    // Start is called before the first frame update
    void Start()
    {
        LabelScore.text = "score="+GameData.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
