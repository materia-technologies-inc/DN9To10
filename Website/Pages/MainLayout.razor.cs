using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using System.Threading.Tasks;

namespace ComponentLibrary;

public partial class MainLayout
{
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;
    [Inject] private IJSRuntime JSRuntime { get; set; } = default!;

}
