// Abstract class for interactable objects.
// Probably wont need it to be honest it could probably be simplified to just a script that checks for a collider and then checks for a tag or layer mask.
// but i did it anyway because why not, maybe it will be useful if the game gets a bit bigger and more complex.
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();
}
