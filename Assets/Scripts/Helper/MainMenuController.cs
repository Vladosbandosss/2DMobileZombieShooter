using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public GameObject characterSelectPanel;

   public void StartMissionOne()
   {
      SceneManager.LoadScene("GamePlay1");
   }
   public void StartMissionTwo()
   {
      SceneManager.LoadScene("GamePlay2");
   }
   public void StartMissionThree()
   {
      SceneManager.LoadScene("GamePlay3");
   }
   public void StartMissionFour()
   {
      SceneManager.LoadScene("GamePlay4");
   }
   
   

   public void OpenCharacterSelectPanel()
   {
      characterSelectPanel.SetActive(true);
   }
   
   public void CloseCharacterSelectPanel()
   {
      characterSelectPanel.SetActive(false);
   }
}
