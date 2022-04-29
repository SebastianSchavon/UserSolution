﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace User_WPF.Core.Commands;

internal class RelayCommand : ICommand
{
    private Func<object, bool> _canExecute;
    private Action<object> _execute;

    // store parameter values 
    public object ParameterValue { get; set; }

    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested += value; }
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }


    public void Execute(object parameter)
    {
        ParameterValue = parameter;
        _execute(parameter);
    }
}
