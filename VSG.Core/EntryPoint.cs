﻿using System;
using ScriptPortal.Vegas;
using VSG.Core.Services;
using VSG.ViewModel;

public class EntryPoint
{
    public void FromVegas(Vegas vegas)
    {
        try
        {
            VSG.MainContainer.Vegas = vegas;
            vegas.UnloadScriptDomainOnScriptExit = true;
            RemoveElementService.RemoveElement(new VSG.ViewModel.ElementSteps.RemoveStep(
                new ElementSelector
                {
                    ElementMediaType = VSG.ViewModel.Enums.ElementMediaType.Audio,
                    ElementType = VSG.ViewModel.Enums.ElementType.Event,
                    SelectorType = VSG.ViewModel.Enums.SelectorType.ByName,
                    Name = "21"
                }
            ));

        }
        catch(Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error: " + ex.GetType().Name);
        }

    }
}