using Leopotam.EcsLite;

namespace Juju8e.EcsLite.Conversion {
  public static class EcsSystemsHelper {
    private static EcsSystems _systems;

    public static void Init(EcsSystems systems) {
      _systems = systems;
    }

    public static EcsSystems GetSystems() {
      return _systems;
    }

    public static void Destroy() {
      _systems = null;
    }
  }
}
