using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActions : Actions
{
   [SerializeField] ItemDatabase itemDatabase;
   [SerializeField] bool giveItem; //decides whether we are giving or receiving an item
   [SerializeField] int amount;
   [SerializeField] Actions[] yesActions, noActions;

   public int itemId;

   public Item CurrentItem { get; private set; }

   public ItemDatabase ItemDatabase {get { return itemDatabase;}}

   public void ChangeItem(Item item)
   {
        if(CurrentItem.ItemId == item.ItemId)
          return;

        if (itemDatabase != null)
          CurrentItem = Extensions.CopyItem(item);
   }

    public override void Act()
    {
       //  chedk if giveiTEM is true then give the item
          //check if we own the item
               //check if the item allowMultiple
                    //check how many items needed, give or substract our item
               //else give and remove the item
       //else receive the item

    }
}
