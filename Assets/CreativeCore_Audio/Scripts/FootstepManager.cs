using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FootstepManager : MonoBehaviour
{
    public List<AudioClip> grassSteps = new List<AudioClip>();
    public List<AudioClip> waterSteps = new List<AudioClip>();
    public List<AudioClip> wallSteps = new List<AudioClip>();

    private enum Surface { grass, water, wall};
    private Surface surface;

    private List<AudioClip> currentList;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();            
    }

    public void PlayStep ()
    {
        AudioClip clip = currentList[Random.Range(0, currentList.Count)];
        source.PlayOneShot(clip);
    }

    private void SelectStepList ()
    {
        switch (surface)
        {
            case Surface.grass:
                currentList = grassSteps;
                break;
            case Surface.water:
                currentList = waterSteps;
                break;
            case Surface.wall:
                currentList = wallSteps;
                break;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Grass")
        {
            surface = Surface.grass;
        }

        if (hit.transform.tag == "Water")
        {
            surface = Surface.water;
        }

        if (hit.transform.tag == "Wall")
        {
            surface = Surface.wall;
        }

        SelectStepList();
        
    }

}
