﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ComponentLibrary;

public partial class Index
{
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private IJSRuntime JSRuntime { get; set; }

#if BLAZOR_SERVER
    private string BuildMode { get; set; } = "Server";
#else
    private string BuildMode { get; set; } = "WebAssembly";
#endif

    private string OSArchitecture { get; set; }
    private string OSDescription { get; set; }
    private string Runtime { get; set; }
    private string Version { get; set; }

    public Index()
    {
        OSArchitecture = RuntimeInformation.OSArchitecture.ToString();
        OSDescription = RuntimeInformation.OSDescription.ToString();
        Runtime = RuntimeInformation.FrameworkDescription.ToString();
    }



}
