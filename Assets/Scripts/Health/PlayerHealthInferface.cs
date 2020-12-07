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

    [SerializeField] private int _emptySpritesAfterZeroHearts;
    [SerializeField] private float _fullHeartAfterAmountOfHealth;

    public void UpdateUI(float health)
    {
        int emptySprites = 0;
        int currentHealth = Mathf.RoundToInt(health);
        //place the hearts
        for (int i = 0; i < sprites.Length; i++)
        {
            if (currentHealth >= _fullHeartAfterAmountOfHealth)
            {
                //full heart
                sprites[i].sprite = fullHeart;
                currentHealth -= 25;
                continue;
            }

            if (currentHealth >= 0)
            {
                //half heart
                sprites[i].sprite = HalfHeart;
                currentHealth -= 25;
                continue;
            }
            //has less health.. so we make it empty heart.. 
            emptySprites++;
            if( emptySprites > _emptySpritesAfterZeroHearts)
            {
                sprites[i].sprite = emptySprite;
                continue;
            }
            sprites[i].sprite = emptyHeart;
            currentHealth -= 25;
        }
    }
}