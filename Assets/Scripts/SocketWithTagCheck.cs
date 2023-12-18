using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketWithTagCheck : XRSocketInteractor
{
    public string[] targetTag;

    public override bool CanHover(XRBaseInteractable interactable)
    {
        if (base.CanHover(interactable))
        {
            foreach (string s in targetTag){
                if (MatchUsingTag(interactable))
                {
                    return true;
                }
            }
        }
        return false;

    }
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        if (base.CanHover(interactable))
        {
            foreach (string s in targetTag){
                if (MatchUsingTag(interactable))
                {
                    return true;
                }
            }
        }
        return false;

    }

private bool MatchUsingTag(XRBaseInteractable interactable)
{
    if (interactable.tag != null)
    {
        foreach (string s in targetTag){
            if (interactable.CompareTag(s))
            {
                return true;
            }
        }
    }
    return false;


}
}