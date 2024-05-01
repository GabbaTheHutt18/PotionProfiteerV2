using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class SpawnResources : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject common; // Object to spawn under common rarity (x8)
    [SerializeField] GameObject rare; // Object to spawn under rare rarity (x6)
    [SerializeField] GameObject epic; // Object to spawn under epic rarity (x4)
    [SerializeField] GameObject legendary; // Object to spawn under legendary rarity (x2)

    [SerializeField] int x_min; // Defines spawnbox - left edge
    [SerializeField] int x_max; // Defines spawnbox - right edge
    [SerializeField] int y_min; // Defines spawnbox - bottom edge
    [SerializeField] int y_max; // Defines spawnbox - top edge

    [SerializeField] Tilemap Tmap;

    void Start()
    {
        GameObject[] rarities = { common, rare, epic, legendary };
        int loop = 8; // amount to spawn each time (defines rarity)
        int index = 0; // index of selected element in rarities array

        for (int r = 0; r < 4; r++) // loops 4 times, one for each rarity.
        {
            for (int i = 0; i < loop; i++) // loops int 'loop' number of times, in which the selected object is spawned at a random location within the defined spawnbox.
            {
                int x = 0;
                int y = 0;
                bool valid = false;
                while (valid == false)
                {
                    x = Random.Range(x_min, x_max); // random location
                    y = Random.Range(y_min, y_max);
                    if (Tmap.HasTile(Tmap.WorldToCell(new Vector3(x, y, 0))))
                    {
                        Debug.Log("InValid tile - rerolling");
                    }
                    else
                    {
                        Debug.Log("Valid Tile");
                        valid = true;
                    }
                    
                }
                GameObject element = Instantiate(rarities[index], this.gameObject.transform); // spawns object
                element.transform.position = new Vector3(x, y, -1);
            }
            index++; // moves onto next rarity object
            loop = loop - 2;
        }
    }
}
