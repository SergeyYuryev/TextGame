using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableText : MonoBehaviour, IPointerClickHandler
{
    public UIController controller;
    public void OnPointerClick(PointerEventData eventData)
    {
        var text = GetComponent<TextMeshProUGUI>();

        if(eventData.button == PointerEventData.InputButton.Left)
        {
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);

            if(linkIndex >= 0)
            {
                var linkinfo = text.textInfo.linkInfo[linkIndex];

                var linkid = linkinfo.GetLinkID();

                if(controller != null)
                {
                    controller.TransitToNextState(linkid);
                }
            }
            else
            {
                controller.SpeetTyping = 0;
            }

        }
    }

    
}
