namespace Zonit.Extensions.Organizations.Repositories;

internal class WorkspaceRepository(IUserOrganizationManager _userWorkspace) : IWorkspaceManager
{
    public event Action? OnChange;

    StateModel? _state;

    public WorkspaceModel? Workspace => _state?.Workspace; 
    public IReadOnlyCollection<OrganizationModel>? Organizations => _state?.Organizations;
    public StateModel? State => _state;

    public void Inicjalize(StateModel model)
        => _state = model;

    public async Task<StateModel> InicjalizeAsync()
    {
        return _state = new StateModel
        {
            Workspace = await _userWorkspace.InicjalizeAsync(),
            Organizations = await _userWorkspace.GetOrganizationsAsync()
        };
    }
    
    public async Task SwitchOrganizationAsync(Guid organizationId)
    {
        if (_state is null)
            return;

        _state.Workspace = await _userWorkspace.SwitchOrganizationAsync(organizationId);
        StateChanged();
    }

    public void StateChanged()
        => OnChange?.Invoke();
}
