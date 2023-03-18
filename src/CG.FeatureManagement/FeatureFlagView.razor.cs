
namespace Microsoft.FeatureManagement;

/// <summary>
/// This class is the code behind for the <see cref="FeatureFlagView"/>
/// component.
/// </summary>
public partial class FeatureFlagView
{
    // *******************************************************************
    // Fields.
    // *******************************************************************

    #region Fields

    /// <summary>
    /// This field indicates whether the feature is enabled, or not.
    /// </summary>
    internal protected bool _featureIsEnabled = false;

    #endregion

    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains the child content.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; } = null!;

    /// <summary>
    /// This property contains the name of the feature.
    /// </summary>
    [Parameter]
    public string FlagName { get; set; } = null!;

    /// <summary>
    /// This property contains the feature manager for this component.
    /// </summary>
    [Inject]
    public IFeatureManager FeatureManager { get; set; } = null!;

    #endregion

    // *******************************************************************
    // Protected methods.
    // *******************************************************************

    #region Protected methods

    /// <summary>
    /// This method is called to initialize the component.
    /// </summary>
    /// <returns>A task to perform the operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        // Was a feature name specified?
        if (string.IsNullOrEmpty(FlagName))
        {
            return;
        }

        // Is the feature enabled?
        _featureIsEnabled = await FeatureManager.IsEnabledAsync(
            FlagName
            ).ConfigureAwait(false);
    }

    #endregion
}
