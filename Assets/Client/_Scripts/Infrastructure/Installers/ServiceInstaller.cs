using Scripts.Infrastructure.AssetManagement;
using Scripts.Infrastructure.Factory;
using Scripts.Infrastructure.States;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindStateFactory();
        BindBossHpController();
        BindGameFactory();
        BindAssetProvider();
        BindUIFactory();
        BindStaticData();
    }

    private void BindStateFactory() => Container.Bind<StateFactory>().AsSingle();
    private void BindGameFactory() => Container.BindInterfacesAndSelfTo<GameFactory>().AsSingle();
    private void BindUIFactory() => Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle();
    private void BindBossHpController() => Container.BindInterfacesAndSelfTo<BossHpController>().AsSingle();
    private void BindAssetProvider() => Container.BindInterfacesAndSelfTo<AssetProvider>().AsSingle();
    private void BindStaticData() => Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();

}
