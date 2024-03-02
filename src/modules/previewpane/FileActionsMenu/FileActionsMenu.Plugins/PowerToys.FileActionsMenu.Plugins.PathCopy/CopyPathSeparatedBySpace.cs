﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using FileActionsMenu.Interfaces;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace PowerToys.FileActionsMenu.Plugins.PathCopy
{
    internal sealed class CopyPathSeparatedBySpace : IAction
    {
        private string[]? _selectedItems;

        public string[] SelectedItems { get => _selectedItems ?? throw new ArgumentNullException(nameof(SelectedItems)); set => _selectedItems = value; }

        public string Title => "\" \"";

        public IAction.ItemType Type => IAction.ItemType.SingleItem;

        public IAction[]? SubMenuItems => null;

        public int Category => 0;

        public IconElement? Icon => null;

        public bool IsVisible => true;

        public Task Execute(object sender, RoutedEventArgs e)
        {
            CopyPathSeparatedBy.SeperateFilePathByDelimiterAndAddToClipboard(" ", SelectedItems);
            return Task.CompletedTask;
        }
    }
}