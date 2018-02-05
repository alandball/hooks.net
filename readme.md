# hooks.net
Run .NET code from GIT hooks

### Hook interfaces

| Hook name | Interface |
| --------- | ---------------------- |
| pre-commit| IPreCommitHook		 |

```csharp
public class GitHookHandler : IPreCommitHook
{
    public void OnPreCommit()
    {
        //Pre commit actions
    }
}
```