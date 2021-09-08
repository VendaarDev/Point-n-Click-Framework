using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Custom Data/Item Database")]
public class ItemDatabase : ScriptableObject
{
  [SerializeField] List<Item> items = new List<Item>();
  [SerializeField] List<string> itemNames = new List<string>();

  public List<string> ItemNames {get { return itemNames;} }

  public void AddItem(Item item)
  {
       items.Add(item);
       itemNames.Add("");
 }

 public Item GetItem(int id)
 {
     for (int i= 0; i < items.Count; i++)
     {
          if (items[i].ItemId == id)
          {
               return items[i];
          }
     }
     return null;
 }
}
