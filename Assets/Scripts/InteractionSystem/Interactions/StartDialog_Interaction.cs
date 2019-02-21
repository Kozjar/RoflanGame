using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog_Interaction : MonoBehaviour, IInteraction
{
    private OriginDialog dialog;
    // Start is called before the first frame update
    void Start()
    {
        dialog = gameObject.GetComponent<OriginDialog>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action()
    {
        dialog.startDialog();
    }
}
