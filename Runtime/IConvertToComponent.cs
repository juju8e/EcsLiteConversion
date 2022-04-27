using Leopotam.EcsLite;

namespace Juju8e.EcsLite.Conversion {
  public interface IConvertToComponent {
    void Convert(int entity, EcsWorld world);
  }
}
