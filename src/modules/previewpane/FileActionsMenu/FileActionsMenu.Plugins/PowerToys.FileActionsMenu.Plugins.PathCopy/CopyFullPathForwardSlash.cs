﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Windows;
using FileActionsMenu.Interfaces;
using FileActionsMenu.Ui.Helpers;
using Microsoft.UI.Xaml.Controls;
using RoutedEventArgs = Microsoft.UI.Xaml.RoutedEventArgs;

namespace PowerToys.FileActionsMenu.Plugins.PathCopy
{
    internal sealed class CopyFullPathForwardSlash : IActionAndRequestCheckedMenuItems
    {
        private string[]? _selectedItems;
        private CheckedMenuItemsDictionary? _checkedMenuItemsDictionary;

        public string[] SelectedItems { get => _selectedItems.GetOrArgumentNullException(); set => _selectedItems = value; }

        public string Title => "Copy full path (/)";

        public IAction.ItemType Type => IAction.ItemType.SingleItem;

        public IAction[]? SubMenuItems => null;

        public int Category => 0;

        public IconElement? Icon => null;

        public bool IsVisible => true;

        public CheckedMenuItemsDictionary CheckedMenuItemsDictionary { get => _checkedMenuItemsDictionary.GetOrArgumentNullException(); set => _checkedMenuItemsDictionary = value; }

        public Task Execute(object sender, RoutedEventArgs e)
        {
            if (SelectedItems[0].EndsWith(".lnk", StringComparison.InvariantCultureIgnoreCase) && CheckedMenuItemsDictionary["f2544fd5-13f7-4d52-b7b4-00a3c70923e6"].First(checkedMenuItems => ((ToggleMenuFlyoutItem)checkedMenuItems.Item1).IsChecked).Item2 is ResolveShortcut)
            {
                SelectedItems[0] = ShortcutHelper.GetFullPathFromShortcut(SelectedItems[0]);
            }

            Clipboard.SetText(SelectedItems[0].Replace("\\", "/"));
            return Task.CompletedTask;
        }
    }
}