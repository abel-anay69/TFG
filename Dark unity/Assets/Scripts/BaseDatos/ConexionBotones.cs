using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConexionBotones : MonoBehaviour
{
   [SerializeField] private GameObject m_registroUI = null;
   [SerializeField] private GameObject m_loginUI = null;
   [SerializeField] private Text m_text = null;

   [SerializeField] private InputField m_nombreUsuarioInput = null;
   [SerializeField] private InputField m_password = null;
   [SerializeField] private InputField m_reEnterPassword = null;

   private NetworkManager m_networkManager = null;

   private void Awake()
   {
       m_networkManager = GameObject.FindObjectOfType<NetworkManager>();
   }

   public void SubmitLogin()
   {
       //Hay que comprobar que ningun campo este vacio
       if(m_nombreUsuarioInput.text == "" || m_password.text == "" || m_reEnterPassword.text == "")
       {
           m_text.text = "Complete todos los campos";
           return;
       }
      //Las dos contraseñas tienen que ser iguales
      if(m_password.text == m_reEnterPassword.text)
      {
          m_text.text = "Procesando...";

          m_networkManager.CrearUsuario(m_nombreUsuarioInput.text, m_password.text, delegate(Response response)
          {
            m_text.text = response.messsage;
          });
      }
      else
      {
          m_text.text = "Las contraseñas no coinciden, vuelva a introducirla";
      }
   }

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

