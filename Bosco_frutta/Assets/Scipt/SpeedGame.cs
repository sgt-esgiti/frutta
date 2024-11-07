using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class SpeedGame : MonoBehaviour
{
    public XROrigin xrOrigin;
    // Start is called before the first frame update
    void Start()
    {
        xrOrigin.GetComponent<DynamicMoveProvider>().moveSpeed = GameSingleton.instance.player.MovementSpeed;
    }
}
