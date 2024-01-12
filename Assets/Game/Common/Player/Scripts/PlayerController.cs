using BlueGravity.Common.Items.BodyParts;
using BlueGravity.Common.Player;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerView view = null;

    public void ToggleInteraction(bool status)
    {
        view.ToggleInteraction(status);
    }

    public void TryRemovePart(BodyPartItemSO part)
    {
        view.RemovePart(part);
    }
}
