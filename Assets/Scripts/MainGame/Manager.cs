using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{

    public List<GameObject> menus;

    private void Start() 
    {
        Global.Initialize();
        for (int i = 0; i < menus.Count; i++)
        {
            menus[i].GetComponent<OutfitChanger>().options = new List<BodyPart>();
        }
        for (int i = 0; i < Global.allBodyParts.Count; i++)
        {
            menus[(int)Global.allBodyParts[i].type].GetComponent<OutfitChanger>().options.Add(Global.allBodyParts[i]);
        }
        for (int i = 0; i < menus.Count; i++)
        {
            menus[i].GetComponent<OutfitChanger>().Initialize();
        }
    }

    public void SaveButton() {
        Global.Save();
    }

    public void LoadButton() {
        Global.Load();
    }

    public void CreateButon() {
        List<BodyPart> bps = new List<BodyPart>();
        for (int i = 0; i < menus.Count; i++)
        {
            bps.Add(menus[i].GetComponent<OutfitChanger>().currentPart);
        }
        Global.CreateOutfit(bps, (string)"BananaMan");
        Global.Save();
    }

    public void ResetButton() {
        Global.Reset();
    }

    public void RandomButton() {
        for (int i = 0; i < menus.Count; i++)
            menus[i].GetComponent<OutfitChanger>().Randomize();
    }

    public void GalleryButton() {
        SceneManager.LoadScene(1);
    }
}