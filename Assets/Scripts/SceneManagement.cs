using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public Player player;
    private static SceneManagement instance;

    private void Awake()
    {
        // Ensure there is only one instance of the SceneManager object
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void LoadAndSet(string scene)
    {
        StartCoroutine(LoadSceneAndSetPosition(scene));
    }


public IEnumerator LoadSceneAndSetPosition(string scene)
    {

        // disable the player's renderer components
        DisableRenderersInPlayerChildren();

        SceneManager.LoadScene(scene);

        yield return new WaitForEndOfFrame();

        // set the player position depending on the scene
        Vector3 position = player.cubiclePosition;

        switch (scene)
        {
            case "StartCubicleScene":
                position = player.cubiclePosition;
                break;
            case "Main Office":
                position = player.mainOfficePosition; 
                break;

        }
        player.transform.position = position;

        // enable the renderer and collider component
        EnableRenderersInPlayerChildren();

    }

    private void DisableRenderersInPlayerChildren()
    {
        foreach (Transform child in player.transform)
        {
            SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();

            if (childRenderer != null)
            {
                childRenderer.enabled = false;
            }
        }
    }

    private void EnableRenderersInPlayerChildren()
    {
        foreach (Transform child in player.transform)
        {
            SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();

            if (childRenderer != null)
            {
                childRenderer.enabled = true;
            }
        }
    }




}
