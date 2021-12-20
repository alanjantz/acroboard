using TMPro;

public class Configuration : BaseVrScene
{
    public TextMeshProUGUI FilePath;
    public TextMeshProUGUI LevelsAmount;
    public TextMeshProUGUI PlayerViewMaxDistance;
    public TextMeshProUGUI PlayerVelocity;
    public TextMeshProUGUI PlatformVelocity;
    public TextMeshProUGUI SpectatorButton;
    public TextMeshProUGUI TutorialOnStartButton;

    private const string ON = "on";
    private const string OFF = "off";

    void Start()
    {
        ResetValues();
    }

    public void ChangeSpectatorMode()
    {
        AcroboardConfiguration.SpectatorMode = !AcroboardConfiguration.SpectatorMode;
        ChangeSpectatorModeText(AcroboardConfiguration.SpectatorMode);
    }

    public void ChangeTutorialOnStartMode()
    {
        AcroboardConfiguration.Tutorial = !AcroboardConfiguration.Tutorial;
        ChangeTutorialOnStartText(AcroboardConfiguration.Tutorial);
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
        ChangeTutorialOnStartText(AcroboardConfiguration.Tutorial);
    }

    public void Return()
    {
        LoaderManager.Load(GameScene.Main, true);
    }

    private void ChangeSpectatorModeText(bool active)
    {
        SpectatorButton.SetText($"Modo espectador: {(active ? ON : OFF)}");
    }

    private void ChangeTutorialOnStartText(bool active)
    {
        TutorialOnStartButton.SetText($"Tutorial ao iniciar: {(active ? ON : OFF)}");
    }
}
