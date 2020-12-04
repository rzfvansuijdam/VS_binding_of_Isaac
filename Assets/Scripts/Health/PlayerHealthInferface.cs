using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthInferface : MonoBehaviour
{
    //sprites
    public Sprite fullHeart;

    public Sprite HalfHeart;
    public Sprite emptyHeart;
    public Sprite emptySprite;
    public Image[] sprites;

    //testing var
    public float health = 75;

    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        int amountOfHearts = Mathf.RoundToInt(health / 25);
        float currentHealth = health;
        //place the hearts
        for (int i = 0; i < sprites.Length; i++)
        {
            if (currentHealth / 25 >= 1)
            {
                //full heart
                sprites[i].gameObject.GetComponent<Image>().sprite = fullHeart;
                currentHealth -= 25;
            }
            else if (currentHealth / 25 > 0)
            {
                //half heart
                sprites[i].gameObject.GetComponent<Image>().sprite = HalfHeart;
                currentHealth -= 25;
            }
            else
            {
                //the end the player has no more hearts so place 3 more empty if possible an remove others..
                sprites[i].gameObject.GetComponent<Image>().sprite = emptyHeart;

                for (int j = i; j < sprites.Length; j++)
                {
                    sprites[j].sprite = emptySprite;
                }
            }
        }
    }
}