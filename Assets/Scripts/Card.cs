using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
   public int idx = 0;
   public SpriteRenderer frontImage;
   public void Setting(int number)
   {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
   }

   public GameObject front;
   public GameObject back;
   public Animator anim;

   public void OpenCard()
   {
      anim.SetBool("isOpen", true);
      front.SetActive(true);
      back.SetActive(false);

      if(GameManager.Instance.firstCard == null)
      {
		   GameManager.Instance.firstCard = this;
      }
      else
      {
		   GameManager.Instance.secondCard = this;
         GameManager.Instance.CheckMatched();
      }
   }
   public void DestroyCard()
   {
		Invoke("DestoryCardInvoke", 1.0f);
   }

   void DestoryCardInvoke()
   {
		Destroy(gameObject);
   }

   public void CloseCard()
   {
		Invoke("CloseCardInvoke", 1.0f);
   }

   void CloseCardInvoke()
   {
		anim.SetBool("isOpen", false);
      front.SetActive(false);
      back.SetActive(true);
   }
   
}