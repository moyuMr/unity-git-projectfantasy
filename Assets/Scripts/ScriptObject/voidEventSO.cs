using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/VoidEventSO", order = 0)]
public class voidEventSO : ScriptableObject {
    public UnityAction OnEventRaised;

    public void RaiseEvent(){
        OnEventRaised?.Invoke();
    }
}