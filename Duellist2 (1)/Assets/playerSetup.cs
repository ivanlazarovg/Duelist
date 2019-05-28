
using UnityEngine;
using UnityEngine.Networking;

public class playerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componetsToDisable;

    Camera sceneCamera;

    void start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componetsToDisable.Length; i++)
            {
                componetsToDisable[i].enabled = true;
            }
        }
        else
        {
            sceneCamera = Camera.main;
            if(sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
            
        }

    }

    void OnDisable() => sceneCamera.gameObject.SetActive(true);
}
