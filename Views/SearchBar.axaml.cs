using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace UserControlDemo.Views;

public partial class SearchBar : UserControl
{
    #region Watermark

    public static readonly StyledProperty<string>
        WaterMarkTextProperty = AvaloniaProperty.Register<SearchBar, string>(nameof(Watermark), "Search for something");

    public string Watermark
    {
        get => GetValue(WaterMarkTextProperty);
        set => SetValue(WaterMarkTextProperty, value);
    }

    #endregion
    #region ItemsSource

    public static readonly StyledProperty<IEnumerable?> ItemsSourceProperty =
        AvaloniaProperty.Register<SearchBar, IEnumerable?>(nameof(ItemsSource));

    public IEnumerable? ItemsSource
    {
        get => GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public ObservableCollection<string?> ResultsSorted { get; set; } = [];

    #endregion
    
    public SearchBar()
    {
        InitializeComponent();
    }


    private void TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is not TextBox textBox) return;
        SearchInList(textBox.Text ?? "");
    }
    
    private new void Loaded(object? sender, RoutedEventArgs e)
    {
        if (sender is not TextBox textBox) return;
        SearchInList(textBox.Text ?? "");
    }
    
    private void SearchInList(string query)
    {
        if (ItemsSource is null) return;
        
        ResultsSorted.Clear();
        var rawResults = new List<string>();
        
        foreach (var item in ItemsSource)
        {
            if (item is null) continue;
            var itemName = item.ToString()?.ToLowerInvariant();
            var queryLower = query.ToLowerInvariant();
            if (itemName?.Contains(queryLower) is true)
                rawResults.Add(item.ToString() ?? "");
        }

        var results = rawResults.OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToList();
        foreach (var result in results) ResultsSorted.Add(result);
    }
}