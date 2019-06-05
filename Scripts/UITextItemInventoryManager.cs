using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextItemInventoryManager : MonoBehaviour {

    public InventoryLogicInteraction inventory;
    public Text UIItemText;

	public void OnPointerEnter(Image imagePointer)
    {
       PickObjectInteraction objectPointer = inventory.GetObject(imagePointer);
        if (objectPointer != null)
            UIItemText.text = objectPointer.getTextObject();
    }

    public void OnPointerExit()
    {
        if(UIItemText != null)
         UIItemText.text = "";
    }

    private void OnDisable()
    {
        OnPointerExit();
    }
}
