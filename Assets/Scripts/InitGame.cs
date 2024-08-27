using UnityEngine;
using UnityEngine.AddressableAssets;

public class InitGame : MonoBehaviour
{
    public AssetReference main;

    private void Awake()
    {
        Addressables.LoadSceneAsync(main);
    }
}
