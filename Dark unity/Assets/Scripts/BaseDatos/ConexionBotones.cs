using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConexionBotones : MonoBehaviour
{
   [SerializeField] private GameObject m_registroUI = null;
   [SerializeField] private GameObject m_loginUI = null;

    public void Showlogin()
    {
        m_registroUI. SetActive(false);
        m_loginUI.SetActive(true);
    }

    public void ShowRegistro()
    {
        m_registroUI.SetActive(true);
        m_loginUI.SetActive(false);
    }
}

