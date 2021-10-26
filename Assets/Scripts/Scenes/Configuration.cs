using TMPro;

public class Configuration : BaseVrScene
{
    public TextMeshProUGUI FilePath;
    public TextMeshProUGUI LevelsAmount;
    public TextMeshProUGUI PlayerViewMaxDistance;
    public TextMeshProUGUI PlayerVelocity;
    public TextMeshProUGUI PlatformVelocity;
    public TextMeshProUGUI SpectatorButton;

    void Start()
    {
        ResetValues();
    }

    public void ChangeSpectatorMode()
    {
        AcroboardConfiguration.SpectatorMode = !AcroboardConfiguration.SpectatorMode;
        ChangeSpectatorModeText(AcroboardConfiguration.SpectatorMode);
    }

    public void ResetConfigurations()
    {
        AcroboardConfiguration.Reset();
        ResetValues();
    }

    private void ResetValues()
    {
        FilePath.SetText(AcroboardConfiguration.FilesPath);
        LevelsAmount.SetText($"Quantidade de níveis: {AcroboardConfiguration.LevelsAmount}");
        PlayerViewMaxDistance.SetText($"Distância de visualização: {AcroboardConfiguration.PlayerViewMaxDistance}");
        PlayerVelocity.SetText($"Velocidade do jogador: {AcroboardConfiguration.PlayerVelocity}");
        PlatformVelocity.SetText($"Velocidade da plataforma: {AcroboardConfiguration.PlatformVelocity}");
        ChangeSpectatorModeText(AcroboardConfiguration.SpectatorMode);
    }

    public void Return()
    {
        LoaderManager.Load(GameScene.Main, true);
    }

    private void ChangeSpectatorModeText(bool active)
    {
        SpectatorButton.SetText($"Modo espectador: {(active ? "on" : "off")}");
    }
}
