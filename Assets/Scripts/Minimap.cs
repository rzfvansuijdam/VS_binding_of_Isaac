using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    
    [Header("roomsGrid (left to right, top to bottom)")]
    [SerializeField] private Sprite[] rooms;

    [Header("MapGrid (left to right, top to bottom)")]
    [SerializeField] private Image[] grid;

    private void Start()
    {
        loadMap();
    }

    public void loadMap()
    {
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i].sprite = rooms[i];
        }
    }
}
