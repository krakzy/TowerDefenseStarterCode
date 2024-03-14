
using UnityEngine; 
using UnityEngine.UIElements;  

public class TowerMenu : MonoBehaviour 

{ 

    private Button archerButton; 

    private Button swordButton; 

    private Button wizardButton; 

    private Button updateButton; 

    private Button destroyButton; 

 

    private VisualElement root; 

 

    void Start() 

    { 

        root = GetComponent<UIDocument>().rootVisualElement; 

 

        archerButton = root.Q<Button>("archer-button"); 

        swordButton = root.Q<Button>("sword-button"); 

        wizardButton = root.Q<Button>("wizard-button"); 

        updateButton = root.Q<Button>("button-upgrade"); 

        destroyButton = root.Q<Button>("button-destroy"); 

 

        if (archerButton != null) 

        { 

            archerButton.clicked += OnArcherButtonClicked; 

        } 

 

        if (swordButton != null) 

        { 

            swordButton.clicked += OnSwordButtonClicked; 

        } 

 

        if (wizardButton != null) 

        { 

            wizardButton.clicked += OnWizardButtonClicked; 

        } 

 

        if (updateButton != null) 

        { 

            updateButton.clicked += OnUpdateButtonClicked; 

        } 

 

        if (destroyButton != null) 

        { 

            destroyButton.clicked += OnDestroyButtonClicked; 

        } 

 

        root.visible = false; 

    } 

 

    private void OnArcherButtonClicked() 

    { 

 

    } 

 

    private void OnSwordButtonClicked() 

    { 

 

    } 

 

    private void OnWizardButtonClicked() 

    { 

 

    } 

 

    private void OnUpdateButtonClicked() 

    { 

 

    } 

 

    private void OnDestroyButtonClicked() 

    { 

 

    } 

 

    private void OnDestroy() 

    { 

        if (archerButton != null) 

        { 

            archerButton.clicked -= OnArcherButtonClicked; 

        } 

 

        if (swordButton != null) 

        { 

            swordButton.clicked -= OnSwordButtonClicked; 

        } 

 

        if (wizardButton != null) 

        { 

            wizardButton.clicked -= OnWizardButtonClicked; 

        } 

 

        if (updateButton != null) 

        { 

            updateButton.clicked -= OnUpdateButtonClicked; 

        } 

 

        if (destroyButton != null) 

        { 

            destroyButton.clicked -= OnArcherButtonClicked; 

        } 

    } 

} 

