using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    public AssetReference scene1;

    public AssetReference scene2;

    public GameObject prefabImage;

    public static MainManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        OnLoadScene1SceneEvent(scene1);
    }

    //scene1....
    public async void OnLoadScene1SceneEvent(AssetReference scence1)
    {
        await LoadSceneTaskAdditive(scene1);
    }

    private async Awaitable LoadSceneTaskAdditive(AssetReference scence1)
    {
        
        var s = scence1.LoadSceneAsync(LoadSceneMode.Additive);
      
        await s.Task;
     
        if (s.Status == AsyncOperationStatus.Succeeded)
        {
          
            SceneManager.SetActiveScene(s.Result.Scene);
        }
    }

    //scene2....
    public async void OnLoadScene2SceneEvent()
    {
       
        await UnloadCurrentScene();
        
        await LoadSceneTaskAdditive(scene2);
    }

    private async Awaitable UnloadCurrentScene()
    {
        await SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    //MainManager Save

    public void Save()
    {
        ES3.Save(nameof(MainManager),this);
    }

    //MainManager Load
    public void Load()
    {
        ES3.Load(nameof(MainManager));
    }

}
