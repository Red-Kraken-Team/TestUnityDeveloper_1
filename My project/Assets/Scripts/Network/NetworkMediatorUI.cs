using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkMediatorUI : MonoBehaviour
{
    [SerializeField] private Button _startHost;
    [SerializeField] private Button _startServer;
    [SerializeField] private Button _startClient;

    [SerializeField] private TextMeshProUGUI _status;
    #region PUBLIC

    #endregion

    #region PRIVATE
    private void Awake()
    {
        _startHost.onClick.AddListener(StartHost);
        _startServer.onClick.AddListener(StartServer);
        _startClient.onClick.AddListener(StartClient);

        NetworkManager.Singleton.OnServerStarted += DisableButtons;
        NetworkManager.Singleton.OnServerStarted += DisplayState;
        NetworkManager.Singleton.OnClientStarted += DisableButtons;
    }

    private void StartHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    private void StartServer()
    {
        NetworkManager.Singleton.StartServer();

    }

    private void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }

    private void DisableButtons()
    {
        _startHost.gameObject.SetActive(false);
        _startClient.gameObject.SetActive(false);
        _startServer.gameObject.SetActive(false);
    }

    private void DisplayState()
    {
        if (NetworkManager.Singleton.IsServer)
            _status.text = $"THIS IS A SERVER"; 
    }
   
    #endregion
}
