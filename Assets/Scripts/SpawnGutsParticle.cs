using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGutsParticle : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject; 
    public void Spawn()
    {
        GameObject gameObject = Instantiate(_spawnObject);
        gameObject.transform.position = this.transform.position;
    }
}
