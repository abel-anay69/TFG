using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public GameObject bossPanel;
    public GameObject muros;
    
    public static BossUI instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bossPanel.SetActive(false);
        muros.SetActive(false);
    }

    public void ActivarBoss() //Al pasar por el RigidBody aparecera tanto el jefe como los muros para bloquear el camino
    {
        bossPanel.SetActive(true);
        muros.SetActive(true);
    }
}
