using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public void Initialize(){
        Debug.Log(Global.allOutfits);
        Depopulate();
        Populate();
    }

    void Populate()
    {
        GameObject newObj;

        for (int i = 0; i < Global.allOutfits.Count; i++)
        {
            newObj = (GameObject)Instantiate(prefab, transform);
            Debug.Log(Global.allOutfits[i].outfitName);
            newObj.GetComponent<Preview>().changeName(Global.allOutfits[i].outfitName);
            newObj.GetComponent<Preview>().changeOutfit(Global.allOutfits[i].bodyParts);
        }
    }

    void Depopulate()
    {
        foreach(Transform child in this.transform)
            Destroy(child.gameObject);
    }

}
