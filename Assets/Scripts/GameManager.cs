using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timeTxt;
    public GameObject endTxt;
    float time = 0.0f;

    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }
    void Start()
    {
		Time.timeScale = 1.0f;
    }

    public static GameManager Instance;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public Card firstCard;
    public Card secondCard;

    public int cardCount = 0;

    public void CheckMatched()
    {
        if(firstCard.idx == secondCard.idx)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
			if(cardCount == 0)
            {
		        endTxt.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }
}