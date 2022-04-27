using Leopotam.EcsLite;
using UnityEngine;

namespace Juju8e.EcsLite.Conversion {
  [RequireComponent(typeof(ConvertToEntity))]
  [DisallowMultipleComponent]
  public abstract class ComponentProvider<T> : MonoBehaviour, IConvertToComponent where T : struct {
    [SerializeField] protected T value;

    public void Convert(int entity, EcsWorld world) {
      var pool = world.GetPool<T>();
      if (pool.Has(entity)) {
        pool.Del(entity);
      }
      pool.Add(entity) = value;
    }
  }
}
