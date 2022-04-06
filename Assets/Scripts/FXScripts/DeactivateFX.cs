using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateFX : MonoBehaviour
{
   private float timeToDeactivate = 2f;
   
   private void OnEnable()
   {
      Invoke(nameof(DeactivateGO),timeToDeactivate);
   }
   
   private void DeactivateGO()
   {
      gameObject.SetActive(false);
   }
}
