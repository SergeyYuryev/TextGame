using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> Items;
  

    public Workflow Workflow;

    internal void AddItem(Item itemToGive)
    {
        Items.Add(itemToGive);
    }

    public bool HasItem(Item item)
    {
        return Items.Any(x => x.Id == item.Id);
    }

    internal Item GetItem(string id)
    {
        return Items.FirstOrDefault(x => x.Id == id);
    }
}
