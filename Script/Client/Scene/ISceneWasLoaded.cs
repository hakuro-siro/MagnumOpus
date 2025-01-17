using UnityEngine.EventSystems;


namespace Script.Client.Scene
{
    /// <summary>
    /// Scene 이동 System Handler 
    /// </summary>
    public interface ISceneWasLoaded : IEventSystemHandler
    {
        void OnSceneWasLoaded(object argument);
    }

}