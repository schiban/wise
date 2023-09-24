using UnityEngine;
using UnityEngine.Playables;

public class StartTimeline : MonoBehaviour
{
    public PlayableDirector timeline;
    
    void Start()
    {
        Time.timeScale = 1;
        if (timeline != null)
        {
            timeline.time = 0;  // Reset the timeline to the beginning.
            timeline.Play();    // Start playing the timeline.
        }
    }
}