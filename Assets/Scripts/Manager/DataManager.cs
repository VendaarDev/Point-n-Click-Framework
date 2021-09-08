using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
     public static DataManager Instance {get; private set; }
     public Inventory Inventory { get { return inventory; } }

     [SerializeField] Inventory inventory;


     private void Awake()
     {
          if (Instance == null)
          {
               Instance = this;
               DontDestroyOnLoad(gameObject);
          }
          else
          {
               Destroy(gameObject);
          }
     }

}
