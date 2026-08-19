using UnityEngine;
using System.Collections.Generic;

public class CollectionManager : MonoBehaviour
{
    public static CollectionManager Instance;

    private HashSet<string> photographedTargets =
        new HashSet<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            // Scene 切换时不要销毁
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterPhoto(string targetID)
    {
        if (string.IsNullOrEmpty(targetID))
            return;

        photographedTargets.Add(targetID);

        Debug.Log(
            "Collection unlocked: " + targetID
        );
    }

    public bool HasPhotographed(string targetID)
    {
        return photographedTargets.Contains(targetID);
    }

    public void ClearCollection()
    {
        photographedTargets.Clear();
    }
}
