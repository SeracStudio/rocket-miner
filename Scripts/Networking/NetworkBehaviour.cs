
using Photon.Pun;
using UnityEngine;

public class NetworkBehaviour : MonoBehaviourPunCallbacks
{
    public bool isMine;
    public bool isOnMaster;

    public PhotonView objectNetworkView;

    protected virtual void Awake()
    {
        objectNetworkView = GetComponent<PhotonView>();
        if (objectNetworkView == null) return;
        isMine = objectNetworkView.IsMine;
        isOnMaster = PhotonNetwork.IsMasterClient;
    }

    private void CheckPhotonView()
    {
        if (objectNetworkView == null)
        {
            objectNetworkView.GetComponent<PhotonView>();
        }
    }

    public void TriggerRPC(string RPC)
    {
        CheckPhotonView();
        objectNetworkView.RPC(RPC, RpcTarget.All);
    }

    public void TriggerRPC(string RPC, RpcTarget target)
    {
        CheckPhotonView();
        objectNetworkView.RPC(RPC, target);
    }

    public void TriggerRPC(string RPC, RpcTarget target, params object[] args)
    {
        CheckPhotonView();
        objectNetworkView.RPC(RPC, target, args);
    }

    [PunRPC]
    public void Destroy()
    {
        if (this == null) return;
        if (!isMine) return;

        PhotonNetwork.Destroy(gameObject);
    }
}
