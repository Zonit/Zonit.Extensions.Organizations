using Microsoft.AspNetCore.Components;
using Zonit.Extensions.Organizations;

namespace Zonit.Extensions;

public sealed class ZonitOrganizationsExtension : ComponentBase, IDisposable
{
    [Inject]
    IWorkspaceManager Workspace { get; set; } = default!;

    [Inject]
    PersistentComponentState ApplicationState { get; set; } = default!;

    StateModel? State { get; set; }

    PersistingComponentStateSubscription persistingSubscription;

    protected override void OnInitialized()
    {
        persistingSubscription = ApplicationState.RegisterOnPersisting(PersistData);

        if (!ApplicationState.TryTakeFromJson<StateModel>("ZonitOrganizationsExtension", out var restored))
            State = Workspace.State;
        else
            State = restored!;

        if(State is not null)
            Workspace.Inicjalize(State);
    }

    private Task PersistData()
    {
        ApplicationState.PersistAsJson("ZonitOrganizationsExtension", State);

        return Task.CompletedTask;
    }

    public void Dispose()
        => persistingSubscription.Dispose();
}