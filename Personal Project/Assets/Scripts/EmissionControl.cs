  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  
  public class EmissionControl : MonoBehaviour
  {
      public Material material;
      private float randomNumber;
  
      void Awake()
      {
          material.DisableKeyword("_EMISSION");
          randomNumber = Random.Range(0.7f, 1.5f);
      }
  
  
      private float time = 0f;
      private bool emit = false;

      void Update()
      {
          if (time >= randomNumber)
          {
              emit = !emit;
              if (emit)
                  material.EnableKeyword("_EMISSION");
              else
                  material.DisableKeyword("_EMISSION");
              time = 0f;
          }
  
          time += Time.deltaTime;
      }
  }
