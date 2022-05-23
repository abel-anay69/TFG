using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public GameObject bossPanel;
    public GameObject muros;
    public GameObject ganarImg;
    
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
        ganarImg.SetActive(false);
    }

    public void ActivarBoss() //Al pasar por el RigidBody aparecera tanto el jefe como los muros para bloquear el camino
    {
        bossPanel.SetActive(true);
        muros.SetActive(true);
    }

    public void DesactivarBoss()
    {
        bossPanel.SetActive(false);

        
        StartCoroutine(BossDerrotado());
    }

    IEnumerator BossDerrotado()
    {
        var velocity = JugadorMovimineto.instance.GetComponent<Rigidbody2D>().velocity;

        Vector2 originalSpeed = velocity;
        velocity = new Vector2(0, velocity.y);
        JugadorMovimineto.instance.enabled = false;
        yield return new WaitForSeconds(5);
        JugadorMovimineto.instance.enabled = true;
        velocity = originalSpeed;
        StartCoroutine(ResetPanel());  
    }

    IEnumerator ResetPanel()
    {
        yield return new WaitForSeconds(0.5f);

        AudioManager.instance.fondo.Stop();
        AudioManager.instance.PlayAudio(AudioManager.instance.victoria);

        Time.timeScale = 0;
        ganarImg.SetActive(true);
    }
}
