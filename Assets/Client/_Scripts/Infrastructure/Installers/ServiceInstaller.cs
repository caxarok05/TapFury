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
        BindWindowServise();
    }

    private void BindStateFactory() => Container.Bind<StateFactory>().AsSingle();
    private void BindGameFactory() => Container.BindInterfacesAndSelfTo<GameFactory>().AsSingle();
    private void BindUIFactory() => Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle();
    private void BindBossHpController() => Container.BindInterfacesAndSelfTo<BossHpHandler>().AsSingle();
    private void BindAssetProvider() => Container.BindInterfacesAndSelfTo<AssetProvider>().AsSingle();
    private void BindStaticData() => Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();
    private void BindWindowServise() => Container.BindInterfacesAndSelfTo<WindowService>().AsSingle();

}
