using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
   public GameObject[] tilePrefabs;
   public float zSpwan = 0;
   public float  panjangJalur = 31;
   public int jumlahTile = 10; 
   private List<GameObject> tileAktif = new List<GameObject>();
   public Transform playerTransform;


    void Start()
    {
        for(int i = 0; i < jumlahTile; i++) 
        {
            if (i == 0)
                SpawnJalur(0);
            else
                SpawnJalur(Random.Range(0, tilePrefabs.Length));
        }
    }

 
    void Update()
    {
        if (playerTransform.position.z -35 > zSpwan - (jumlahTile * panjangJalur))
        {
            SpawnJalur(Random.Range(0, tilePrefabs.Length));
            HapusTile();
        }
    }

    public void SpawnJalur (int tileIndex) 
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpwan, transform.rotation);   
        tileAktif.Add(go);
        zSpwan += panjangJalur; 
    }

    private void HapusTile () 
    {
        Destroy(tileAktif[0]);
        tileAktif.RemoveAt(0);    
    }
}
