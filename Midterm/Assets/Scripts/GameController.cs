using UnityEngine;

public class GameController : MonoBehaviour {
    public enum GameStageEnum {
        Align,
        Intro,
        Game,
        Outro
    }

    //DialogManager dialogManager;
    public GameStageEnum gameStage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        gameStage = GameStageEnum.Align;
        InitializeAlignStage();
    }

    public void ProgressToNextState() {
        if (gameStage == GameStageEnum.Align) {
            gameStage = GameStageEnum.Intro;
            InitializeIntroStage();
        } else if (gameStage == GameStageEnum.Intro) {
            gameStage = GameStageEnum.Game;
            InitializeGameStage();
        } else if (gameStage == GameStageEnum.Game) {
            gameStage = GameStageEnum.Outro;
            InitializeOutroStage();
        }
    }

    private void InitializeAlignStage() {

    }

    private void InitializeIntroStage() {

    }
    
    private void InitializeGameStage() {

    }

    private void InitializeOutroStage() {

    }
}
