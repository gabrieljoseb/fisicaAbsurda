using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	public GameObject audioMenu, audioJogo;	



    void Update()
    {
        if(GeneralConfig.menuAtivado == true){
        	audioMenu.SetActive(true);
        	audioJogo.SetActive(false);
        }else{
        	audioJogo.SetActive(true);
        	audioMenu.SetActive(false);        	
        }
    }
}
