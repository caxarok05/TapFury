using Scripts.Infrastructure.States;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class WindowService : IWindowService
{
    private readonly IUIFactory _uiFactory;

    public WindowService(IUIFactory uiFactory)
    {
        _uiFactory = uiFactory;
    }
    public void Open(WindowId id)
    {
        switch (id)
        {
            case WindowId.Unknown:

                break;
            case WindowId.Pause:
                
                break;
            case WindowId.Finish:

                break;
        }
    }


}
