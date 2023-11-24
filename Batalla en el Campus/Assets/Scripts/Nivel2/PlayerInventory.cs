using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
  public int NumberOdDiamonds { get; private set; }
    public UnityEvent<PlayerInventory> OnDiamondColled;
  
    public void DiamondCollected()
    {
        NumberOdDiamonds++;
        OnDiamondColled.Invoke(this);
    }
    
}
