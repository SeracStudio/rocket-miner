using Photon.Pun;
using UnityEngine;

public class NetworkBehaviour : MonoBehaviour
{
    public bool isMine;

    private PhotonView objectNetworkView;

    private void Awake()
    {
        objectNetworkView = GetComponent<PhotonView>();

        isMine = objectNetworkView.IsMine;
    }

    public void TriggerRPC(string RPC)
    {
        objectNetworkView.RPC(RPC, RpcTarget.All);
    }

    public void TriggerRPC(string RPC, RpcTarget target)
    {
        objectNetworkView.RPC(RPC, target);
    }

    public void TriggerRPC(string RPC, RpcTarget target, params object[] args)
    {
        objectNetworkView.RPC(RPC, target, args);
    }

    [PunRPC]
    public void Destroy()
    {
        if (isMine)
            PhotonNetwork.Destroy(gameObject);
    }
}
