using Leopotam.EcsLite;
using UnityEngine;

namespace Juju8e.EcsLite.Conversion {
  [DisallowMultipleComponent]
  public class ConvertToEntity : MonoBehaviour {
    [SerializeField] private ConvertToEntityMode convertMode;
    [SerializeField] private string worldName;

    private EcsPackedEntity _packedEntity;
    private EcsWorld _world;
    private bool _processed;

    private void Awake() {
      var systems = EcsSystemsHelper.GetSystems();
      if (systems != null && !_processed) {
        Convert(systems);
      }
    }

    public void Convert(EcsSystems systems) {
      _world = systems.GetWorld(worldName == "" ? null : worldName);
      var entity = _world.NewEntity();
      foreach (var convertToEntityComponents in GetComponents<Component>()) {
        if (convertToEntityComponents is IConvertToComponent convertToComponent) {
          convertToComponent.Convert(entity, _world);
          Destroy(convertToEntityComponents);
        }
      }
      _processed = true;
      switch (convertMode) {
        case ConvertToEntityMode.ConvertAndInject:
          Destroy(this);
          break;
        case ConvertToEntityMode.ConvertAndDestroy:
          Destroy(gameObject);
          break;
        case ConvertToEntityMode.ConvertAndSave:
          _packedEntity = _world.PackEntity(entity);
          break;
      }
    }

    public ConvertToEntityMode GetConvertMode() {
      return convertMode;
    }

    public string GetWorldName() {
      return worldName;
    }

    public bool TryGetEntity(out int entity) {
      return _packedEntity.Unpack(_world, out entity);
    }

    public bool TryGetWorld(out EcsWorld world) {
      world = _world;
      return world != null;
    }
  }
}
