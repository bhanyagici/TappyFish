using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedalManager : MonoBehaviour
{
    public Sprite metalMedal, bronzeMedal, silverMedal, goldMedal;
    Image image;



    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        int gameScore = GameManager.gameScore;

       if (gameScore > 0 && gameScore <= 1)
        {
            image.sprite = metalMedal;
        }
        else if(gameScore > 1 && gameScore <= 2)
        {
            image.sprite = bronzeMedal;
        }
       else if (gameScore > 2 && gameScore <= 3)
        {
            image.sprite = silverMedal;
        }
       else if (gameScore > 3)
        {
            image.sprite = goldMedal;
        }
    }
}
