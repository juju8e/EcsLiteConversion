using Leopotam.EcsLite;
using UnityEngine;

namespace Juju8e.EcsLite.Conversion {
  public sealed class ConvertToEntitySystem : IEcsPreInitSystem, IEcsDestroySystem {
    public void PreInit(EcsSystems systems) {
      foreach (var convertToEntity in Object.FindObjectsOfType<ConvertToEntity>()) {
        convertToEntity.Convert(systems);
      }
      EcsSystemsHelper.Init(systems);
    }

    public void Destroy(EcsSystems systems) {
      EcsSystemsHelper.Destroy();
    }
  }
}
