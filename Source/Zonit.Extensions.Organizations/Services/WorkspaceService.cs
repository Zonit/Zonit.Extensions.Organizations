namespace Zonit.Extensions.Organizations.Services;

internal class WorkspaceService : IWorkspaceProvider
{
    const string GrantedPermission = "All";
    const string GrantedRole = "Developer";

    readonly IWorkspaceManager _workspaceManager;
    OrganizationModel? _organization;

    public OrganizationModel? Organization => _organization;
    public event Action? OnChange;

    public WorkspaceService(IWorkspaceManager workspaceManager)
    {
        _workspaceManager = workspaceManager;
        _workspaceManager.OnChange += StateChanged;

        Initialize();
    }

    void Initialize()
    {
        _organization = _workspaceManager.Workspace?.Organization;
    }

    public void StateChanged()
    {
        Initialize();
        OnChange?.Invoke();
    }

    public bool IsPermission(string permission)
    {
        var workspace = _workspaceManager.Workspace;

        if (workspace is null)
            return false;

        if (workspace.Permissions.Contains(GrantedPermission, StringComparer.OrdinalIgnoreCase) || workspace.Permissions.Contains(permission, StringComparer.OrdinalIgnoreCase))
            return true;

        return false;
    }

    public bool IsRole(string role)
    {
        var workspace = _workspaceManager.Workspace;

        if (workspace is null)
            return false;

        if (workspace.Roles.Contains(GrantedRole, StringComparer.OrdinalIgnoreCase) || workspace.Roles.Contains(role, StringComparer.OrdinalIgnoreCase))
            return true;

        return false;
    }
}