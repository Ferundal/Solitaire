using UnityEngine;

namespace TableViev
{
    public interface ISpawnManager
    {
        public GameObject CreateObject(GameObject gameObject, Transform transform);
    }
}
